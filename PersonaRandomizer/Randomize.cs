using AtlusFileSystemLibrary;
using AtlusFileSystemLibrary.FileSystems.PAK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonaRandomizer
{
    public class Randomize
    {
        public void ADX(string inputFolder, string outputFolder, List<string> fileList)
        {
            if (!Directory.Exists(inputFolder))
                return;

            List<string> adxFiles = new List<string>();

            foreach (string file in Directory.GetFiles(inputFolder, "*.ADX", System.IO.SearchOption.AllDirectories))
            {
                long length = new FileInfo(file).Length;
                if (length > 540672)
                {
                    // Use file as randomized track if it's not silent/ambient
                    adxFiles.Add(file);
                }
            }

            ShuffleAndCopyFiles(adxFiles, fileList, outputFolder);
        }

        public void RMD(string inputFolder, string outputFolder, List<string> fileList)
        {
            if (!Directory.Exists(inputFolder))
                return;

            List<string> rmdFiles = new List<string>(Directory.GetFiles(inputFolder, "*.RMD", System.IO.SearchOption.AllDirectories));
            ShuffleAndCopyFiles(rmdFiles, fileList, outputFolder);
        }

        public void PAC(string inputFolder, string outputFolder, List<string> fileList)
        {
            if (!Directory.Exists(inputFolder))
                return;

            // Shufle all RMD files from input folder
            List<string> rmdFiles = new List<string>(Directory.GetFiles(inputFolder, "*.RMD", System.IO.SearchOption.AllDirectories));
            var shuffledFiles = ShuffleFiles(rmdFiles, fileList, outputFolder);
            
            // Create replacement PACs in output folder containing shuffled RMDs
            for (int i = 0; i < fileList.Count; i++)
            {
                PAKFileSystem pak = new PAKFileSystem();
                pak.AddFile(Path.GetFileNameWithoutExtension(fileList[i]) + ".RMD", rmdFiles[i], ConflictPolicy.Replace);

                string outPath = $"{outputFolder}\\{fileList[i].Split('\\').Last()}";
                pak.Save(Path.Combine(outPath, Path.GetFileName(fileList[i])));
                
            }
        }

        public void BIN(string inputFolder, string outputFolder, List<string> fileList)
        {
            if (!Directory.Exists(inputFolder))
                return;

            List<string> binFiles = new List<string>(Directory.GetFiles(inputFolder, "*.BIN", System.IO.SearchOption.AllDirectories));
            ShuffleAndCopyFiles(binFiles, fileList, outputFolder);
        }

        public static void ShuffleAndCopyFiles(List<string> filteredFiles, List<string> fileList, string outputFolder)
        {
            var shuffledFiles = ShuffleFiles(filteredFiles, fileList, outputFolder);
            CopyShuffledFiles(shuffledFiles, fileList, outputFolder);
        }

        public static string[] ShuffleFiles(List<string> filteredFiles, List<string> fileList, string outputFolder)
        {
            Random rng = new Random();
            string[] shuffledFiles = filteredFiles.OrderBy(x => rng.Next()).ToArray();

            while (fileList.Count > shuffledFiles.Length)
            {
                List<string> newList = new List<string>();
                newList.AddRange(shuffledFiles);
                newList.AddRange(shuffledFiles); // Copy list to itself to double the size, covering length of fileList entries
                shuffledFiles = newList.ToArray();
            }

            return shuffledFiles;
        }

        public static void CopyShuffledFiles(string[] shuffledFiles, List<string> fileList, string outputFolder)
        {
            Directory.CreateDirectory(outputFolder);

            for (int i = 0; i < fileList.Count; i++)
            {
                string newFileName = $"{outputFolder}\\{fileList[i].Split('\\').Last()}";
                File.Copy(shuffledFiles[i], newFileName, true);
            }
        }
    }
}
