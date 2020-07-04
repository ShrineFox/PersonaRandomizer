using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using AtlusScriptLib;
using AtlusTableLib.Serialization;
using TGELib.Reflection;
using GoogleTranslateNet;
using TGELib.CLI;
using TGELib.IO;
using System.Net;

namespace AtlusRandomizer
{
    internal class Program
    {
        private static int sActiveWorkerThreadCount = 0;

        private static void Main(string[] args)
        {
            //Persona3FesTableRandomizer.Randomize(@"E:\Games\PS2\Persona Modding\PROJECTS\P3 DIAMOND\tbl", new bool[] { true, true });

            //ScriptRandomizer.RandomizeScriptsInPM1(
            //    @"D:\Modding\Persona 3 & 4\Persona3\CVM_DATA\EVENT\E080\E080_001.PM1");

            /*
            foreach (var path in Directory.EnumerateFiles("Input", "*.*", SearchOption.AllDirectories))
            {
                if (path.EndsWith("randomized") || File.Exists(path + ".randomized"))
                    continue;

                if (path.EndsWith("bin", StringComparison.InvariantCultureIgnoreCase) ||
                    path.EndsWith("pak", StringComparison.InvariantCultureIgnoreCase) ||
                    path.EndsWith("pac", StringComparison.InvariantCultureIgnoreCase))
                {
                    AssignWorkerThread(ScriptRandomizer.RandomizeScriptsInBIN, path);
                }
                else if (path.EndsWith("pm1", StringComparison.InvariantCultureIgnoreCase))
                {
                    AssignWorkerThread(ScriptRandomizer.RandomizeScriptsInPM1, path);
                }
                else if (path.EndsWith("bmd", StringComparison.InvariantCultureIgnoreCase))
                {
                    AssignWorkerThread(ScriptRandomizer.RandomizeMessageScript, path);
                }
                else if (path.EndsWith("bf", StringComparison.InvariantCultureIgnoreCase))
                {
                    AssignWorkerThread(ScriptRandomizer.RandomizeFlowScript, path);
                }
                else if (path.EndsWith("bvp", StringComparison.InvariantCultureIgnoreCase))
                {
                    AssignWorkerThread(ScriptRandomizer.RandomizeScriptsInBVP, path);
                }
            }
            */

            /*
            foreach (var path in Directory.EnumerateFiles("Input", "*.*", SearchOption.AllDirectories))
            {
                var originalPath = @"D:\Modding\Persona 3 & 4\Persona3\CVM_DATA\" + path.Substring(6);

                if (path.EndsWith("bin", StringComparison.InvariantCultureIgnoreCase) ||
                    path.EndsWith("pak", StringComparison.InvariantCultureIgnoreCase) ||
                    path.EndsWith("pac", StringComparison.InvariantCultureIgnoreCase))
                {
                    AssignWorkerThread(ScriptRandomizer.FixScriptsInBIN, path, originalPath);
                }
                else if (path.EndsWith("pm1", StringComparison.InvariantCultureIgnoreCase))
                {
                    AssignWorkerThread(ScriptRandomizer.FixScriptsInPM1, path, originalPath);
                }
                else if (path.EndsWith("bmd", StringComparison.InvariantCultureIgnoreCase))
                {
                    AssignWorkerThread(ScriptRandomizer.FixMessageScript, path, originalPath);
                }
                else if (path.EndsWith("bf", StringComparison.InvariantCultureIgnoreCase))
                {
                    AssignWorkerThread(ScriptRandomizer.FixFlowScript, path, originalPath);
                }
            }
            */

            while (sActiveWorkerThreadCount > 0)
                Thread.Sleep(1000);

            //Console.ReadKey();
        }

        private static void AssignWorkerThread(Action<string, string> action, string path, string originalPath)
        {
            var name = Path.GetFileName(path);
            Console.WriteLine($"Begin randomizing {name}");
            action(path, originalPath);
            Console.WriteLine($"Done randomizing {name}");
           
            /*
            ThreadPool.QueueUserWorkItem((state) =>
            {
                sActiveWorkerThreadCount++;
                var tuple = (Tuple<string, string>)state;
                var name = Path.GetFileName(tuple.Item1);

                Console.WriteLine($"Begin randomizing {name}");
                action(tuple.Item1, tuple.Item2);
                Console.WriteLine($"Done randomizing {name}");

                sActiveWorkerThreadCount--;

            }, Tuple.Create(path, originalPath));
            */
        }
    }
}
