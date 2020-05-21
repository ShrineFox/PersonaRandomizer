using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlusTableLib.Serialization
{
    public static class TextEncoding
    {
        public static ushort GetCharacterCode(char character)
        {
            if (character <= 0x7E)
            {
                return character;
            }
            else if (character >= 0x3041 && character <= 0x3093)
            {
                return (ushort)(0x5F + (character - 0x3041));
            }
            else if (character >= 0x30A1 && character <= 0xF6)
            {
                return (ushort) (0x83 + (character - 0x30A1));
            }
            else if (character >= 0x3001 && character <= 0x3002)
            {
                return (ushort) (0x109 + (character - 0x3001));
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static char GetCharacter(ushort characterCode)
        {
            int glyphIndex = GetGlyphIndex(characterCode);

            // 00 - 5E
            if (glyphIndex <= 0x5E)
            {
                return (char)(glyphIndex + 0x20);
            }

            // 5F - B2
            if (glyphIndex >= 0x5F && glyphIndex <= 0xB2)
            {
                return (char) (0x3041 + (glyphIndex - 0x5F));
            }

            // B3 - 108
            if (glyphIndex >= 0xB3 && glyphIndex <= 108)
            {
                return (char) (0x30A1 + (glyphIndex - 0xB3));
            }

            // 109 - 10A
            if (glyphIndex >= 0x109 && glyphIndex <= 0x10a)
            {
                return (char) (0x3001 + (glyphIndex - 0x109));
            }

            throw new NotImplementedException();
        }

        private static int GetGlyphIndex(ushort characterCode)
        {
            if (characterCode < 0x20)
                return 0;

            int index = characterCode - 0x20;

            if ((characterCode & 0xFF00) >= 0x80)
            {
                int shift = ((characterCode & 0xFF00) >> 8) - 0x80;
                index = (characterCode & 0x00FF) + (0x80 * shift);
            }

            return index;
        }
    }
}
