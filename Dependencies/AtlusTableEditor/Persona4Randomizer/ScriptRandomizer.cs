using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using AtlusScriptLib;
using TGELib.IO;
using System.Linq;

namespace AtlusRandomizer
{
    public static class ScriptRandomizer
    {
        public static void RandomizeScriptsInBIN(string path)
        {
            using (var reader = new EndianBinaryReader(File.OpenRead(path), Endianness.LittleEndian))
            using (var writer = new EndianBinaryWriter(File.Create(path + ".randomized"), Endianness.LittleEndian))
            {
                while (reader.Position != reader.BaseStream.Length)
                {
                    // read source entry fields
                    var fileName = reader.ReadString(StringBinaryFormat.FixedLength, 0xFC);
                    int fileSize = reader.ReadInt32();
                    var fileBytes = reader.ReadBytes(fileSize);
                    reader.Position = AlignmentHelper.Align(reader.Position, 64);

                    // transform bytes depending on the extension
                    if (fileName.EndsWith("bmd"))
                    {
                        fileBytes = RandomizeMessageScript(fileBytes);
                    }
                    else if (fileName.EndsWith("bf"))
                    {
                        fileBytes = RandomizeFlowScript(fileBytes);
                    }

                    // write output entry fields
                    writer.Write(fileName, StringBinaryFormat.FixedLength, 0xFC);
                    writer.Write(fileBytes.Length);
                    writer.Write(fileBytes);
                    writer.Position = AlignmentHelper.Align(writer.Position, 64);
                }
            }
        }

        public static void RandomizeScriptsInPM1(string path)
        {
            using (var reader = new EndianBinaryReader(File.OpenRead(path), Endianness.LittleEndian))
            using (var writer = new EndianBinaryWriter(File.Create(path + ".randomized"), Endianness.LittleEndian))
            {
                reader.SeekCurrent(0x50);
                int type = reader.ReadInt32();
                int size = reader.ReadInt32();
                int count = reader.ReadInt32();
                int address = reader.ReadInt32();

                if (type != 6 || count == 0 || count == 2)
                    return;

                reader.SeekBegin(address);
                var bytes = RandomizeMessageScript(reader.ReadBytes(size));
                int remainingBytes = (int)(reader.BaseStreamLength - reader.Position);

                reader.SeekBegin(0);
                if (bytes.Length <= size)
                {
                    writer.Write(reader.ReadBytes(address));
                    writer.Write(bytes);
                    for (int i = 0; i < size - bytes.Length; i++)
                        writer.Write((byte) 0);
                    reader.SeekCurrent(size);
                    writer.Write(reader.ReadBytes(remainingBytes));
                }
                else
                {
                    // write source bytes up until message script header fields
                    writer.Write(reader.ReadBytes(0x50));

                    // write message script fields
                    writer.Write(6);
                    writer.Write(bytes.Length);
                    writer.Write(1);
                    writer.Write((int)reader.BaseStreamLength);

                    // seek past original fields
                    reader.SeekCurrent(0x10);

                    // write source bytes up until end of file
                    remainingBytes = (int)(reader.BaseStreamLength - reader.Position);;
                    writer.Write(reader.ReadBytes(remainingBytes));

                    // append the new script to the file
                    writer.Write(bytes);
                }
            }
        }

        public static void RandomizeScriptsInBVP(string path)
        {
            using (var reader = new EndianBinaryReader(File.OpenRead(path), Endianness.LittleEndian))
            using (var writer = new EndianBinaryWriter(File.OpenWrite(path + ".randomized"), Endianness.LittleEndian))
            {
                // read first entry
                int flags = reader.ReadInt32();
                int address = reader.ReadInt32();
                int size = reader.ReadInt32();

                int firstAddress = address;
                int nextAddress = firstAddress;

                while (reader.Position < firstAddress)
                {
                    // read & randomize message script
                    reader.EnqueuePosition();
                    reader.SeekBegin(address);
                    var bytes = RandomizeMessageScript(reader.ReadBytes(size));
                    reader.SeekBegin(reader.DequeuePosition());

                    // write new entry
                    writer.Write(flags);
                    writer.Write(nextAddress);
                    writer.Write(bytes.Length);

                    // write new message script
                    writer.EnqueuePosition();
                    writer.SeekBegin(nextAddress);
                    writer.Write(bytes);

                    // write padding
                    for (int i = 0; i < AlignmentHelper.GetAlignedDifference(writer.Position, 16); i++)
                        writer.Write((byte) 0);

                    nextAddress = (int)writer.Position;

                    writer.SeekBegin(writer.DequeuePosition());

                    // read next entry
                    flags = reader.ReadInt32();
                    address = reader.ReadInt32();
                    size = reader.ReadInt32();
                }
            }
        }

        public static void RandomizeFlowScript(string path)
        {
            var flowScript = FlowScript.FromFile(path);
            RandomizeFlowScript(flowScript);
            flowScript.ToFile(path + ".randomized");
        }

        public static byte[] RandomizeFlowScript(byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                return ((MemoryStream)RandomizeFlowScript(stream)).ToArray();
            }
        }

        public static Stream RandomizeFlowScript(Stream stream)
        {
            var flowScript = FlowScript.FromStream(stream, true);

            if (flowScript.MessageScript == null)
                return stream;

            RandomizeMessageScript(flowScript.MessageScript);

            return flowScript.ToStream();
        }

        public static void RandomizeFlowScript(FlowScript script)
        {
            if (script.MessageScript == null)
                return;

            RandomizeMessageScript(script.MessageScript);
        }

        public static void RandomizeMessageScript(string path)
        {
            var messageScript = MessageScript.FromFile(path);
            RandomizeMessageScript(messageScript);
            messageScript.ToFile(path + ".randomized");
        }

        public static byte[] RandomizeMessageScript(byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                return ((MemoryStream)RandomizeMessageScript(stream)).ToArray();
            }
        }

        public static Stream RandomizeMessageScript(Stream stream)
        {
            var messageScript = MessageScript.FromStream(stream, true);
            RandomizeMessageScript(messageScript);

            return messageScript.ToStream();
        }

        public static void RandomizeMessageScript(MessageScript messageScript)
        {
            foreach (var message in messageScript.Messages)
            {
                foreach (var line in message.Lines)
                {
                    for (int k = 0; k < line.Tokens.Count; k++)
                    {
                        switch (line.Tokens[k].Type)
                        {
                            case MessageScriptTokenType.Text:
                                var textToken = (MessageScriptTextToken)line.Tokens[k];
                                line.Tokens[k] = new MessageScriptTextToken(Translator.Translate(textToken.Text));
                                break;
                        }
                    }
                }
            }
        }

        public static void FixScriptsInBIN(string path, string originalPath)
        {
            using (var reader = new EndianBinaryReader(File.OpenRead(path), Endianness.LittleEndian))
            using (var writer = new EndianBinaryWriter(File.Create(path + ".Fixd"), Endianness.LittleEndian))
            using (var originalReader = new EndianBinaryReader(File.OpenRead(originalPath), Endianness.LittleEndian))
            {
                while (reader.Position != reader.BaseStream.Length)
                {
                    // read source entry fields
                    var fileName = reader.ReadString(StringBinaryFormat.FixedLength, 0xFC);
                    int fileSize = reader.ReadInt32();
                    var fileBytes = reader.ReadBytes(fileSize);
                    reader.Position = AlignmentHelper.Align(reader.Position, 64);

                    originalReader.SeekCurrent(0xFC);
                    int originalFileSize = originalReader.ReadInt32();
                    var originalFileBytes = originalReader.ReadBytes(originalFileSize);

                    // transform bytes depending on the extension
                    if (fileName.EndsWith("bmd"))
                    {
                        fileBytes = FixMessageScript(fileBytes, originalFileBytes);
                    }
                    else if (fileName.EndsWith("bf"))
                    {
                        fileBytes = FixFlowScript(fileBytes, originalFileBytes);
                    }

                    originalReader.Position = AlignmentHelper.Align(originalReader.Position, 64);

                    // write output entry fields
                    writer.Write(fileName, StringBinaryFormat.FixedLength, 0xFC);
                    writer.Write(fileBytes.Length);
                    writer.Write(fileBytes);
                    writer.Position = AlignmentHelper.Align(writer.Position, 64);
                }
            }
        }

        public static void FixScriptsInPM1(string path, string originalPath)
        {
            using (var reader = new EndianBinaryReader(File.OpenRead(path), Endianness.LittleEndian))
            using (var writer = new EndianBinaryWriter(File.Create(path + ".Fixd"), Endianness.LittleEndian))
            using (var originalReader = new EndianBinaryReader(File.OpenRead(originalPath), Endianness.LittleEndian))
            {
                reader.SeekCurrent(0x50);
                int type = reader.ReadInt32();
                int size = reader.ReadInt32();
                int count = reader.ReadInt32();
                int address = reader.ReadInt32();

                originalReader.SeekCurrent(0x54);
                int originalSize = originalReader.ReadInt32();
                int originalCount = originalReader.ReadInt32();
                int originalAddress = originalReader.ReadInt32();

                if (type != 6 || count == 0 || count == 2)
                    return;

                reader.SeekBegin(address);
                originalReader.SeekBegin(originalAddress);

                var bytes = FixMessageScript(reader.ReadBytes(size), originalReader.ReadBytes(originalSize));
                int remainingBytes = (int)(reader.BaseStreamLength - reader.Position);

                reader.SeekBegin(0);
                if (bytes.Length <= size)
                {
                    writer.Write(reader.ReadBytes(address));
                    writer.Write(bytes);
                    for (int i = 0; i < size - bytes.Length; i++)
                        writer.Write((byte)0);
                    reader.SeekCurrent(size);
                    writer.Write(reader.ReadBytes(remainingBytes));
                }
                else
                {
                    // write source bytes up until message script header fields
                    writer.Write(reader.ReadBytes(0x50));

                    // write message script fields
                    writer.Write(6);
                    writer.Write(bytes.Length);
                    writer.Write(1);
                    writer.Write((int)reader.BaseStreamLength);

                    // seek past original fields
                    reader.SeekCurrent(0x10);

                    // write source bytes up until end of file
                    remainingBytes = (int)(reader.BaseStreamLength - reader.Position); ;
                    writer.Write(reader.ReadBytes(remainingBytes));

                    // append the new script to the file
                    writer.Write(bytes);
                }
            }
        }

        public static void FixScriptsInBVP(string path, string originalPath)
        {
            /*
            using (var reader = new EndianBinaryReader(File.OpenRead(path), Endianness.LittleEndian))
            using (var writer = new EndianBinaryWriter(File.OpenWrite(path + ".extension"), Endianness.LittleEndian))
            using (var originalReader = new EndianBinaryReader(File.OpenRead(originalPath), Endianness.LittleEndian))
            {
                // read first entry
                int flags = reader.ReadInt32();
                int address = reader.ReadInt32();
                int size = reader.ReadInt32();

                int firstAddress = address;
                int nextAddress = firstAddress;

                while (reader.Position < firstAddress)
                {
                    // read & Fix message script
                    reader.EnqueuePosition();
                    reader.SeekBegin(address);
                    var bytes = FixMessageScript(reader.ReadBytes(size));
                    reader.SeekBegin(reader.DequeuePosition());

                    // write new entry
                    writer.Write(flags);
                    writer.Write(nextAddress);
                    writer.Write(bytes.Length);

                    // write new message script
                    writer.EnqueuePosition();
                    writer.SeekBegin(nextAddress);
                    writer.Write(bytes);

                    // write padding
                    for (int i = 0; i < AlignmentHelper.GetAlignedDifference(writer.Position, 16); i++)
                        writer.Write((byte)0);

                    nextAddress = (int)writer.Position;

                    writer.SeekBegin(writer.DequeuePosition());

                    // read next entry
                    flags = reader.ReadInt32();
                    address = reader.ReadInt32();
                    size = reader.ReadInt32();
                }
            }
            */
        }

        public static void FixFlowScript(string path, string originalPath)
        {
            var flowScript = FlowScript.FromFile(path);
            var originalFlowScript = FlowScript.FromFile(originalPath);
            FixFlowScript(flowScript, originalFlowScript);
            flowScript.ToFile(path + ".Fixd");
        }

        public static byte[] FixFlowScript(byte[] data, byte[] originalData)
        {
            using (var stream = new MemoryStream(data))
            using (var originalStream = new MemoryStream(originalData))
            {
                return ((MemoryStream)FixFlowScript(stream, originalStream)).ToArray();
            }
        }

        public static Stream FixFlowScript(Stream stream,Stream originalStream)
        {
            var flowScript = FlowScript.FromStream(stream, true);
            var originalFlowScript = FlowScript.FromStream(originalStream, true);

            if (flowScript.MessageScript == null)
                return stream;

            FixMessageScript(flowScript.MessageScript, originalFlowScript.MessageScript);

            return flowScript.ToStream();
        }

        public static void FixFlowScript(FlowScript script, FlowScript originalScript)
        {
            if (script.MessageScript == null)
                return;

            FixMessageScript(script.MessageScript, originalScript.MessageScript);
        }

        public static void FixMessageScript(string path, string originalPath)
        {
            var messageScript = MessageScript.FromFile(path);
            var originalMessageScript = MessageScript.FromFile(originalPath);
            FixMessageScript(messageScript, originalMessageScript);
            messageScript.ToFile(path + ".Fixd");
        }

        public static byte[] FixMessageScript(byte[] data, byte[] originalData)
        {
            using (var stream = new MemoryStream(data))
            using (var originalStream = new MemoryStream(originalData))
            {
                return ((MemoryStream)FixMessageScript(stream, originalStream)).ToArray();
            }
        }

        public static Stream FixMessageScript(Stream stream, Stream originalStream)
        {
            var messageScript = MessageScript.FromStream(stream, true);
            var originalMessageScript = MessageScript.FromStream(originalStream, true);

            FixMessageScript(messageScript, originalMessageScript);

            return messageScript.ToStream();
        }

        public static void FixMessageScript(MessageScript script, MessageScript originalScript)
        {
            for (var i = 0; i < script.Messages.Count; i++)
            {
                for (var j = 0; j < script.Messages[i].Lines.Count; j++)
                {
                    var line = script.Messages[i].Lines[j];
                    var originalLine = originalScript.Messages[i].Lines[j];

                    if (script.Messages[i].Type == MessageScriptMessageType.Dialogue)
                    {
                        var dialogueMessage = (MessageScriptDialogueMessage)script.Messages[i];

                        if (dialogueMessage.Speaker != null && dialogueMessage.Speaker.Type == MessageScriptDialogueMessageSpeakerType.Named)
                        {
                            var speaker = (MessageScriptDialogueMessageNamedSpeaker)((MessageScriptDialogueMessage)script.Messages[i]).Speaker;

                            for (var index = 0; index < speaker.Name.Tokens.Count; index++)
                            {
                                IMessageScriptLineToken token = speaker.Name.Tokens[index];

                                if (token.Type == MessageScriptTokenType.Text)
                                {
                                    var textToken = (MessageScriptTextToken)token;
                                    var sentences = textToken.Text.Split('\n');

                                    var lineEndIndices = new List<int>();
                                    for (int k = 0; k < textToken.Text.Length; k++)
                                    {
                                        if (textToken.Text[k] == '\n')
                                            lineEndIndices.Add(k);
                                    }

                                    var newText = string.Empty;
                                    int originalTextIndex = 0;

                                    for (int k = 0; k < sentences.Length; k++)
                                    {
                                        if (lineEndIndices.Contains(originalTextIndex))
                                            newText += "\n";

                                        if (sentences[k] == "Junpei")
                                            newText += "Juntair";
                                        else
                                            newText += Translator.Translate(sentences[k]);

                                        originalTextIndex += sentences[k].Length;

                                        if (lineEndIndices.Contains(originalTextIndex))
                                            newText += "\n";
                                    }

                                    speaker.Name.Tokens[index] = new MessageScriptTextToken(newText);
                                }
                            }
                        }
                    }

                    for (int k = 0; k < line.Tokens.Count; k++)
                    {
                        switch (originalLine.Tokens[k].Type)
                        {
                            case MessageScriptTokenType.Text:

                                // somehow some text tokens are gone..?
                                if (line.Tokens[k].Type != MessageScriptTokenType.Text)
                                {
                                    line.Tokens.Insert(k, originalLine.Tokens[k]);
                                    continue;
                                }

                                var textToken = (MessageScriptTextToken) line.Tokens[k];
                                var originalTextToken = (MessageScriptTextToken) originalLine.Tokens[k];

                                // fix html special characters
                                var fixedText = WebUtility.HtmlDecode(textToken.Text);

                                // fix missing line ending depending on whether or not the original had it
                                if (originalTextToken.Text.EndsWith("\n") && !fixedText.EndsWith("\n"))
                                {
                                    fixedText += "\n";
                                }

                                // fix double line endings
                                if (fixedText.EndsWith("\n\n"))
                                    fixedText = fixedText.Remove(fixedText.Length - 1, 1);

                                // fix newline at beginning
                                if (fixedText.Length != 1)
                                {
                                    if (fixedText.StartsWith("\n"))
                                    {
                                        fixedText = fixedText.Remove(0, 1);
                                    }
                                    else if (fixedText.StartsWith(" \n"))
                                    {
                                        fixedText = fixedText.Remove(0, 2);
                                    }
                                }

                                if (k != 0 && line.Tokens[k - 1].Type == MessageScriptTokenType.Function)
                                {
                                    var functionToken = (MessageScriptFunctionToken)line.Tokens[k - 1];

                                    // inline speaker name
                                    if (functionToken.FunctionTableIndex == 1 && functionToken.FunctionIndex == 15)
                                    {
                                        fixedText = " \n" + fixedText;
                                    }
                                }

                                line.Tokens[k] = new MessageScriptTextToken(fixedText);
                                break;
                        }
                    }
                }
            }
        }
    }
}
