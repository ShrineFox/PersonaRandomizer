using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack;
using System.Threading;

namespace PersonaRandomizer
{
    public partial class MainForm : Form
    {
        P3FileLists p3files = new P3FileLists();
        P4FileLists p4files = new P4FileLists();

        public string inputFolder;
        public string outputFolder;

        public MainForm()
        {
            InitializeComponent();
            
            if (radio_P3FES.Checked == true)
            {
                combobox_Mode.DataSource = p3files.p3Dropdown;
            }
            else
            {
                combobox_Mode.DataSource = p4files.p4Dropdown;
            }
        }

        private void txt_Input_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                inputFolder = dialog.FileName;
                txt_Input.Text = inputFolder;
            }
        }

        private void txt_Output_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                outputFolder = dialog.FileName;
                txt_Output.Text = outputFolder;
            }
        }

        private void radio_P4_Click(object sender, EventArgs e)
        {
            combobox_Mode.DataSource = p4files.p4Dropdown;
        }

        private void radio_P3FES_Click(object sender, EventArgs e)
        {
            combobox_Mode.DataSource = p3files.p3Dropdown;
        }

        private void combobox_Mode_DataSourceChanged(object sender, EventArgs e)
        {
            combobox_Mode.SelectedIndex = 0;
        }

        private void btn_Randomize_Click(object sender, EventArgs e)
        {
            Randomize randomize = new Randomize();
            int i = combobox_Mode.SelectedIndex;
            if (radio_P3FES.Checked == true)
            {
                switch (i)
                {
                    case 0: //BGM
                        randomize.ADX(inputFolder, outputFolder, p3files.BGM);
                        break;
                    case 1: //BUSTUP
                        randomize.BIN(inputFolder, outputFolder, p3files.BUSTUP);
                        break;
                    case 2: //FIELD/RMD
                        randomize.RMD(inputFolder, outputFolder, p3files.FIELDRMD);
                        break;
                    case 3: //FACILITYP
                        randomize.RMD(inputFolder, outputFolder, p3files.FACILITYP);
                        break;
                    case 4: //FIELD
                        randomize.RMD(inputFolder, outputFolder, p3files.FIELD);
                        break;
                    case 5: //NPC
                        randomize.RMD(inputFolder, outputFolder, p3files.NPC);
                        break;
                    case 6: //PERSONA
                        randomize.RMD(inputFolder, outputFolder, p3files.PERSONA);
                        break;
                    case 7: //SYMBOL
                        randomize.RMD(inputFolder, outputFolder, p3files.SYMBOL);
                        break;
                    case 8: //WEAPON
                        randomize.RMD(inputFolder, outputFolder, p3files.WEAPON);
                        break;
                } 
            }
            else
            {
                switch (i)
                {
                    case 0: //BGM
                        randomize.ADX(inputFolder, outputFolder, p4files.BGM);
                        break;
                    case 1: //BUSTUP
                        randomize.BIN(inputFolder, outputFolder, p4files.BUSTUP);
                        break;
                    case 2: //FIELD/RMD
                        randomize.RMD(inputFolder, outputFolder, p4files.FIELDRMD);
                        break;
                    case 3: //FACILITYP
                        randomize.RMD(inputFolder, outputFolder, p4files.FACILITYP);
                        break;
                    case 4: //FIELD
                        randomize.RMD(inputFolder, outputFolder, p4files.FIELD);
                        break;
                    case 5: //NPC
                        randomize.RMD(inputFolder, outputFolder, p4files.NPC);
                        break;
                    case 6: //NPC2
                        randomize.RMD(inputFolder, outputFolder, p4files.NPC2);
                        break;
                    case 7: //SYMBOL
                        randomize.RMD(inputFolder, outputFolder, p4files.SYMBOL);
                        break;
                    case 8: //WEAPON
                        randomize.RMD(inputFolder, outputFolder, p4files.WEAPON);
                        break;
                    case 9: //WEAPON
                        randomize.RMD(inputFolder, outputFolder, p4files.PERSONA);
                        break;
                }
            }
        }

    }
}
