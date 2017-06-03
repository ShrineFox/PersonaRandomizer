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
            List<string> RMDFiles = new List<string>();
            List<string> PACFiles = new List<string>();
            Console.Write("Path to Persona 4 data/MODEL directory: ");
            string modelPath = Console.ReadLine();
            foreach (string file in Directory.GetFiles(modelPath, "*.RMD*", System.IO.SearchOption.AllDirectories))
            {
                RMDFiles.Add(file);
            }
            foreach (string file in Directory.GetFiles(modelPath, "*.PAC*", System.IO.SearchOption.AllDirectories))
            {
                PACFiles.Add(file);
            }
            Console.Write("Path to Persona 4 btl/MODEL_BTL directory: ");
            modelPath = Console.ReadLine();
            foreach (string file in Directory.GetFiles(modelPath, "*.RMD*", System.IO.SearchOption.AllDirectories))
            {
                RMDFiles.Add(file);
            }
            foreach (string file in Directory.GetFiles(modelPath, "*.PAC*", System.IO.SearchOption.AllDirectories))
            {
                PACFiles.Add(file);
            }

            Console.WriteLine("---------------------------------");
            Console.WriteLine("RMD Count: " + RMDFiles.Count());

            Random rng = new Random();
            string[] RandomizedRMDFiles = RMDFiles.ToArray().OrderBy(x => rng.Next()).ToArray();
            string[] RandomizedPACFiles = PACFiles.ToArray().OrderBy(x => rng.Next()).ToArray();

            Directory.CreateDirectory("MODEL");
            Directory.CreateDirectory("MODEL\\FACILITYP");
            Directory.CreateDirectory("MODEL\\FIELD");
            Directory.CreateDirectory("MODEL\\NPC");
            Directory.CreateDirectory("MODEL\\NPC2");
            Directory.CreateDirectory("MODEL\\PACK");
            Directory.CreateDirectory("MODEL\\SYMBOL");
            Directory.CreateDirectory("MODEL\\WEAPON");
            Directory.CreateDirectory("MODEL_BTL\\PERSONA");
            Directory.CreateDirectory("MODEL_BTL\\PACK");

            //FACILITYP
            for (int i = 0; i < 256; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"MODEL\\FACILITYP\\{newFileName}");
            }

            //FIELD
            for (int i = 256; i < 283; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"MODEL\\FIELD\\{newFileName}");
            }

            //NPC
            for (int i = 283; i < 1183; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"MODEL\\NPC\\{newFileName}");
            }

            //NPC2
            for (int i = 1183; i < 1820; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"MODEL\\NPC2\\{newFileName}");
            }

            //SYMBOL
            for (int i = 1820; i < 1825; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"MODEL\\SYMBOL\\{newFileName}");
            }

            //WEAPON
            for (int i = 1826; i < 2157; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"MODEL\\WEAPON\\{newFileName}");
            }

            //PERSONA
            for (int i = 2157; i < 2413; i++)
            {
                string newFileName = RMDFiles[i].Split('\\').Last();
                File.Copy(RandomizedRMDFiles[i], $"MODEL_BTL\\PERSONA\\{newFileName}");
            }

            Console.WriteLine("RMDs randomized successfully!");
            Console.WriteLine("PAC Count: " + PACFiles.Count());

            //ENEMY
            for (int i = 91; i < 427; i++)
            {
                string newFileName = PACFiles[i].Split('\\').Last();
                File.Copy(RandomizedPACFiles[i], $"MODEL_BTL\\PACK\\{newFileName}");
            }
            Console.WriteLine("PACs randomized successfully! Press any key to exit.");
            Console.ReadKey();
        }
    }
}
