using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDRandomizer
{
    class Program
    {
        static void Main(string[] args)
        {
            bool validSelection = false;
            while (validSelection == false)
            {
                Console.WriteLine("Select a mode:\np4 rmd - Persona 4 RMD shuffle\np3 rmd - Persona 3 FES RMD Shuffle\np4 adx- P4 ADX shuffle\np3 adx- P3 ADX shuffle");
                string selection = Console.ReadLine().ToUpper();
                if (selection == "P4 RMD") { P4Randomized(); validSelection = true; }
                if (selection == "P3 RMD") { P3Randomized(); validSelection = true; }
                if (selection == "P4 ADX")
                {
                    bool isP4 = true;
                    Console.Write("Output directory: ");
                    string outputDir = Console.ReadLine();
                    Randomizer.ADX(outputDir, isP4);
                    validSelection = true;
                }
                if (selection == "P3 ADX")
                {
                    bool isP4 = false;
                    Console.Write("Output directory: ");
                    string outputDir = Console.ReadLine();
                    Randomizer.ADX(outputDir, isP4);
                    validSelection = true;
                }
                else { Console.Clear(); }
            }

            Console.WriteLine("Everything has been randomized successfully!");
            Console.ReadKey();
        }

        static void P4Randomized()
        {
            List<string> RMDFiles = Randomizer.GetP4RMDs();
            Console.Write("Output directory: ");
            string outputDir = Console.ReadLine();

            bool validSelection = false;
            while (validSelection == false)
            {
                Console.Write("Would you like to include RMDs from Persona 3? (y/n): ");
                string selection = Console.ReadLine().ToUpper();
                if (selection == "Y") {
                    validSelection = true;
                    RMDFiles.AddRange(Randomizer.GetP3RMDs());
                }
                if (selection == "N") { validSelection = true; }
                else { Console.Clear(); }
            }

            Console.WriteLine("---------------------------------");
            Console.WriteLine("RMD Count: " + RMDFiles.Count());

            Random rng = new Random();
            string[] RandomizedRMDFiles = RMDFiles.ToArray().OrderBy(x => rng.Next()).ToArray();

            List<string> dirListP4 = Randomizer.P4Dirs(outputDir);
            
            Randomizer.CreateDirs(dirListP4, outputDir);

            //FACILITYP
            for (int i = 0; i < 256; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"{dirListP4[4]}\\{newFileName}");
            }
            Console.WriteLine("FACILITYP randomized");
            //FIELD
            for (int i = 256; i < 283; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"{dirListP4[5]}\\{newFileName}");
            }
            Console.WriteLine("FIELD randomized");
            //NPC
            for (int i = 283; i < 1183; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"{dirListP4[6]}\\{newFileName}");
            }
            Console.WriteLine("NPC randomized");
            //NPC2
            for (int i = 1183; i < 1820; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"{dirListP4[7]}\\{newFileName}");
            }
            Console.WriteLine("NPC2 randomized");
            //SYMBOL
            for (int i = 1820; i < 1825; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"{dirListP4[8]}\\{newFileName}");
            }
            Console.WriteLine("SYMBOL randomized");
            //WEAPON
            for (int i = 1826; i < 2157; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"{dirListP4[9]}\\{newFileName}");
            }
            Console.WriteLine("WEAPON randomized");
            //FIELD RMD
            for (int i = 2157; i < 2532; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"{dirListP4[3]}\\{newFileName}");
            }
            Console.WriteLine("FIELD/RMD randomized");
            //PERSONA
            for (int i = 2532; i < 2788; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"{dirListP4[10]}\\{newFileName}");
            }
            Console.WriteLine("PERSONA randomized\nRMDs successfully randomized!\n---------------------------------");

            validSelection = false;
            while (validSelection == false)
            {
                Console.WriteLine("Would you like to randomize BGM ADX files? (y/n): ");
                string selection = Console.ReadLine().ToUpper();
                if (selection == "Y")
                {
                    bool isP4 = true;
                    validSelection = true;
                    Randomizer.ADX(outputDir, isP4);
                }
                if (selection == "N") { validSelection = true; }
            }
        }

        static void P3Randomized()
        {
            List<string> RMDFiles = Randomizer.GetP3RMDs();
            Console.Write("Output directory: ");
            string outputDir = Console.ReadLine();

            bool validSelection = false;
            while (validSelection == false)
            {
                Console.Write("Would you like to include RMDs from Persona 4? (y/n): ");
                string selection = Console.ReadLine().ToUpper();
                if (selection == "Y")
                {
                    validSelection = true;
                    RMDFiles.AddRange(Randomizer.GetP4RMDs());
                }
                if (selection == "N") { validSelection = true; }
                else { Console.Clear(); }
            }

            Console.WriteLine("---------------------------------");
            Console.WriteLine("RMD Count: " + RMDFiles.Count());

            Random rng = new Random();
            string[] RandomizedRMDFiles = RMDFiles.ToArray().OrderBy(x => rng.Next()).ToArray();

            List<string> dirListP3 = Randomizer.P3Dirs(outputDir);
            Randomizer.CreateDirs(dirListP3, outputDir);

            //FACILITYP
            for (int i = 0; i < 256; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"{dirListP3[3]}\\{newFileName}");
            }
            Console.WriteLine("FACILITYP randomized");
            //FIELD
            for (int i = 256; i < 277; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"{dirListP3[4]}\\{newFileName}");
            }
            Console.WriteLine("FIELD randomized");
            //NPC
            for (int i = 277; i < 1348; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"{dirListP3[5]}\\{newFileName}");
            }
            Console.WriteLine("NPC randomized");
            //PERSONA
            for (int i = 1348; i < 1604; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"{dirListP3[6]}\\{newFileName}");
            }
            Console.WriteLine("PERSONA randomized");
            //SYMBOL
            for (int i = 1604; i < 1635; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"{dirListP3[7]}\\{newFileName}");
            }
            Console.WriteLine("SYMBOL randomized");
            //WEAPON
            for (int i = 1635; i < 2404; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"{dirListP3[8]}\\{newFileName}");
            }
            Console.WriteLine("WEAPON randomized");
            //FIELD RMD
            for (int i = 2404; i < 3217; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"{dirListP3[9]}\\{newFileName}");
            }
            Console.WriteLine("FIELD/RMD randomized\nRMDs successfully randomized!\n---------------------------------");

            validSelection = false;
            while (validSelection == false)
            {
                Console.WriteLine("Would you like to randomize BGM ADX files? (y/n): ");
                string selection = Console.ReadLine().ToUpper();
                if (selection == "Y")
                {
                    bool isP4 = false;
                    validSelection = true;
                    Randomizer.ADX(outputDir, isP4);
                }
                if (selection == "N") { validSelection = true; }
            }
        }
    }
}
