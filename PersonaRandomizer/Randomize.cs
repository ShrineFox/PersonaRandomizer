using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;

namespace PersonaRandomizer
{
    public class Randomize
    {
        public void ADX(string inputFolder, string outputFolder, List<string> fileList)
        {
            List<string> adxFiles = new List<string>();
            try
            {
                foreach (string file in Directory.GetFiles(inputFolder, "*.ADX", System.IO.SearchOption.AllDirectories))
                {
                    long length = new FileInfo(file).Length;
                    if (length > 540672)
                    {
                        adxFiles.Add(file);
                    }
                }

                Randomize.Files(adxFiles, fileList, outputFolder);
            }
            catch
            {
                MessageBox.Show("Make sure you selected a valid input and output folder!","Something went wrong",MessageBoxButtons.OK);
            }
        }

        public void RMD(string inputFolder, string outputFolder, List<string> fileList)
        {
            try
            {
                List<string> rmdFiles = new List<string>(Directory.GetFiles(inputFolder, "*.RMD", System.IO.SearchOption.AllDirectories));
                Randomize.Files(rmdFiles, fileList, outputFolder);
            }
            catch
            {
                MessageBox.Show("Make sure you selected a valid input and output folder!", "Something went wrong", MessageBoxButtons.OK);
            }

        }

        public void BIN(string inputFolder, string outputFolder, List<string> fileList)
        {
            try
            {
                List<string> binFiles = new List<string>(Directory.GetFiles(inputFolder, "*.BIN", System.IO.SearchOption.AllDirectories));
                Randomize.Files(binFiles, fileList, outputFolder);
            }
            catch
            {
                MessageBox.Show("Make sure you selected a valid input and output folder!", "Something went wrong", MessageBoxButtons.OK);
            }

        }

        public static void Files(List<string> filteredFiles, List<string> fileList, string outputFolder)
        {

            Random rng = new Random();
            string[] randomizedFiles = filteredFiles.OrderBy(x => rng.Next()).ToArray();

            while (fileList.Count > randomizedFiles.Length)
            {
                List<string> newList = new List<string>();
                newList.AddRange(randomizedFiles);
                newList.AddRange(randomizedFiles);
                randomizedFiles = newList.ToArray();
            }

            for (int i = 0; i < fileList.Count; i++)
            {
                string newFileName = $"{outputFolder}\\{fileList[i].Split('\\').Last()}";

                if (File.Exists(newFileName))
                {
                    File.Delete(newFileName);
                }
                File.Copy(randomizedFiles[i], newFileName);
            }
        }
    }
}
