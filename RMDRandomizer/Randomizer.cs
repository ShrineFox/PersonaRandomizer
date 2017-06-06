using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDRandomizer
{
    class Randomizer
    {
        public static List<string> Add(List<string> rmdList, string modelPath)
        {
            foreach (string file in Directory.GetFiles(modelPath, "*.RMD*", System.IO.SearchOption.AllDirectories))
            {
                rmdList.Add(file);
            }
            return rmdList;
        }


        public static List<string> GetP4RMDs()
        {
            List<string> RMDFiles = new List<string>();
            Console.Write("Path to Persona 4 data/MODEL directory: ");
            RMDFiles = Randomizer.Add(RMDFiles, Console.ReadLine());
            Console.Write("Path to Persona 4 data/FIELD/RMD directory: ");
            RMDFiles = Randomizer.Add(RMDFiles, Console.ReadLine());
            Console.Write("Path to Persona 4 btl/MODEL_BTL directory: ");
            RMDFiles = Randomizer.Add(RMDFiles, Console.ReadLine());
            return RMDFiles;
        }

        public static List<string> GetP3RMDs()
        {
            List<string> RMDFiles = new List<string>();
            Console.Write("Path to Persona 3 btl/MODEL directory: ");
            RMDFiles = Randomizer.Add(RMDFiles, Console.ReadLine());
            Console.Write("Path to Persona 3 data/FIELD/RMD directory: ");
            RMDFiles = Randomizer.Add(RMDFiles, Console.ReadLine());
            return RMDFiles;
        }

        public static List<string> P4Dirs(string outputDir)
        {
            List<string> dirList = new List<string>() { $"{outputDir}\\P4 RANDOMIZED", $"{outputDir}\\P4 RANDOMIZED\\MODEL", $"{outputDir}\\P4 RANDOMIZED\\FIELD", $"{outputDir}\\P4 RANDOMIZED\\FIELD\\RMD",
                                                        $"{outputDir}\\P4 RANDOMIZED\\MODEL\\FACILITYP", $"{outputDir}\\P4 RANDOMIZED\\MODEL\\FIELD", $"{outputDir}\\P4 RANDOMIZED\\MODEL\\NPC",
                                                        $"{outputDir}\\P4 RANDOMIZED\\MODEL\\NPC2", $"{outputDir}\\P4 RANDOMIZED\\MODEL\\SYMBOL", $"{outputDir}\\P4 RANDOMIZED\\MODEL\\WEAPON",
                                                        $"{outputDir}\\P4 RANDOMIZED\\MODEL_BTL\\PERSONA" };
            return dirList;
        }

        public static List<string> P3Dirs(string outputDir)
        {
            List<string> dirList = new List<string>() { $"{outputDir}\\P3 RANDOMIZED", $"{outputDir}\\P3 RANDOMIZED\\MODEL", $"{outputDir}\\P3 RANDOMIZED\\FIELD", $"{outputDir}\\P3 RANDOMIZED\\MODEL\\FACILITYP",
                                                        $"{outputDir}\\P3 RANDOMIZED\\MODEL\\FIELD", $"{outputDir}\\P3 RANDOMIZED\\MODEL\\NPC", $"{outputDir}\\P3 RANDOMIZED\\MODEL\\PERSONA", $"{outputDir}\\P3 RANDOMIZED\\MODEL\\SYMBOL",
                                                        $"{outputDir}\\P3 RANDOMIZED\\MODEL\\WEAPON", $"{outputDir}\\P3 RANDOMIZED\\FIELD\\RMD" };
            return dirList;
        }



        public static void CreateDirs(List<string> dirList, string outputDir)
        {
            foreach (string dir in dirList)
            {
                if (Directory.Exists(dir))
                {
                    try
                    {
                        Directory.Delete(dir, true);
                    }
                    catch
                    {
                        Console.WriteLine($"Close or backup any files in \"{outputDir}\" that are still in use and try again.");
                    }
                }
                Directory.CreateDirectory(dir);
                }
        }

        public static List<string> GetADX(string bgmDir)
        {
            List<string> adxFiles = new List<string>();
            foreach (string file in Directory.GetFiles(bgmDir, "*.ADX*", System.IO.SearchOption.AllDirectories))
            {
                adxFiles.Add(file);
            }
            return adxFiles;
        }

    }
}
