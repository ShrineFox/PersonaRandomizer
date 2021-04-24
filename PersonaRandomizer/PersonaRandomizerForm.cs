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
using AtlusRandomizer;

namespace PersonaRandomizer
{
    public partial class MainForm : Form
    {
        P3FileLists p3files = new P3FileLists();
        P4FileLists p4files = new P4FileLists();

        public string inputFolder;
        public string tableInput;
        public string outputFolder;
        public string game;

        public MainForm()
        {
            InitializeComponent();
            //Set game dropdown to default value
            comboBox_Game.SelectedIndex = 0;
            lbl_Usage.Text = "Usage: Extract contents from game folder\n matching \"Mode\" dropdown to Input Folder.";
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

        private void combobox_Mode_DataSourceChanged(object sender, EventArgs e)
        {
            //Set dropdownlist for what files to randomize back to default
            combobox_Mode.SelectedIndex = 0;
        }

        private void btn_Randomize_Click(object sender, EventArgs e)
        {
            //Randomize depending on controls currently shown
            #if !DEBUG
            try
            {
            #endif
                if (tabControl_RandomizeType.SelectedIndex == 0)
                    RandomizeFiles();
                else
                    RandomizeTables();
                lbl_Status.Text = "Done randomizing!";
            #if !DEBUG
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endif
        }

        private void RandomizeFiles()
        {
            lbl_Status.Text = "Randomizing file data...";
            Randomize randomize = new Randomize();
            int i = combobox_Mode.SelectedIndex;
            if (game == "Persona 3")
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
            else if (game == "Persona 4")
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

        private void RandomizeTables()
        {
            lbl_Status.Text = "Randomizing TBL data...";
            List<bool> options = new List<bool>();
            for (int i = 0; i < checkedListBox_Tables.Items.Count; i++)
                options.Add(ConvertCheckState(checkedListBox_Tables.GetItemCheckState(i)));

            switch(game)
            {
                case "Persona 3 FES":
                    Persona3FesTableRandomizer.Randomize(txtBox_TableInput.Text, options.ToArray(), checkBox_BossRush.Checked);
                    break;
                case "Persona 4":
                    Persona4TableRandomizer.Randomize(txtBox_TableInput.Text, options.ToArray(), false, checkBox_BossRush.Checked);
                    break;
                case "Persona 4 Golden":
                    Persona4TableRandomizer.Randomize(txtBox_TableInput.Text, options.ToArray(), true, checkBox_BossRush.Checked);
                    break;
                case "Persona 5":
                    if (options[0])
                        AtlusTableRandomizer.Program.Randomize(txtBox_TableInput.Text, checkBox_BossRush.Checked);
                    break;
            }
        }

        private void ComboBox_Game_IndexChanged(object sender, EventArgs e)
        {
            //Disable elements not compatible with specific games
            game = comboBox_Game.Text;
            lbl_Status.Text = "";
            combobox_Mode.DataSource = null;
            checkedListBox_Tables.Items.Clear();
            bool enableFiles = true;

            if (game != "Persona 3 FES" && game != "Persona 4")
                enableFiles = false;
            if (enableFiles)
            {
                combobox_Mode.DisplayMember = "Test";
                btn_Randomize.Enabled = true;
                combobox_Mode.Enabled = true;
                txt_Input.Enabled = true;
                txt_Output.Enabled = true;
            }
            else
            {
                lbl_Status.Text += $"Files not yet supported.";
                combobox_Mode.Enabled = false;
                txt_Input.Enabled = false;
                txt_Output.Enabled = false;
                if (tabControl_RandomizeType.SelectedIndex == 0)
                    btn_Randomize.Enabled = false;
            }
            //Set files dropdown for supported games
            if (game == "Persona 3 FES")
                combobox_Mode.DataSource = p3files.p3Dropdown;
            else if (game == "Persona 4")
                combobox_Mode.DataSource = p4files.p4Dropdown;
            //Repopulate Table tab
            if (game == "Persona 3 FES")
                foreach (var tableName in p3files.p3fesTables)
                    checkedListBox_Tables.Items.Insert(0,tableName);
            else if (game == "Persona 3")
                foreach (var tableName in p3files.p3Tables)
                    checkedListBox_Tables.Items.Insert(0, tableName);
            else if (game == "Persona 4" || game == "Persona 4 Golden")
                foreach (var tableName in p4files.p4Tables)
                    checkedListBox_Tables.Items.Insert(0, tableName);
            else if (game == "Persona 5")
                checkedListBox_Tables.Items.Insert(0, "ENCOUNT.TBL");
            //Change Table Input text depending on game
            if (game == "Persona 5")
            {
                lbl_TableInput.Text = "Path to ENCOUNT.TBL:";
                checkedListBox_Tables.SetItemChecked(0, true);
            }
            else
                lbl_TableInput.Text = "Extracted .TBLs Folder:";
        }

        private void txtBox_TableInput_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            if (game != "Persona 5")
                dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                tableInput = dialog.FileName;
                txtBox_TableInput.Text = tableInput;
            }
        }

        public static bool ConvertCheckState(CheckState state)
        {
            if (state == CheckState.Checked)
                return true;
            else
                return false;
        }

        private void RandomizeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Only allow randomizing P5/P4G tables and not files
            if (game == "Persona 5" || game == "Persona 4 Golden")
            {
                if (tabControl_RandomizeType.SelectedIndex != 0)
                    btn_Randomize.Enabled = true;
                else
                    btn_Randomize.Enabled = false;
            }
        }
    }
}
