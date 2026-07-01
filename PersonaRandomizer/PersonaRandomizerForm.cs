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
        P5FileLists p5files = new P5FileLists();

        public string game;

        public MainForm()
        {
            InitializeComponent();

            //Set game dropdown to default value
            comboBox_Game.SelectedIndex = 0;
            //Set translation engine dropdown to default value
            comboBox_TranslateEngine.SelectedIndex = 0;
        }

        // Reusable function to choose folder for input/output
        private static string ChooseFolder()
        {
            string folderPath = "";
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                folderPath = dialog.FileName;
            }

            return folderPath;
        }

        private void txt_InputFolder_Click(object sender, EventArgs e)
        {
            txt_InputFolder.Text = ChooseFolder();
        }

        private void txt_ModFolder_Click(object sender, EventArgs e)
        {
            txt_ModFolder.Text = ChooseFolder();
        }

        private void txtBox_TableFolder_Click(object sender, EventArgs e)
        {
            txt_TblFolder.Text = ChooseFolder();
        }

        private void btn_RandomizeFiles_Click(object sender, EventArgs e)
        {
            RandomizeFiles();
            MessageBox.Show("Done randomizing files!");
        }

        private void RandomizeFiles()
        {
            List<string> options = new List<string>();
            foreach (var item in checkedListBox_FilesToRandomize.CheckedItems)
                options.Add(item.ToString());

            Randomize randomize = new Randomize();
            if (game == "Persona 3 FES" || game == "Persona 3")
            {
                if (options.Any(x => x.Equals("BGM.CVM")))
                    randomize.ADX(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "BGM"), p3files.BGM);
                if (options.Any(x => x.Equals("DATA.CVM/BUSTUP")))
                    randomize.BIN(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "DATA\\BUSTUP"), p3files.BUSTUP);
                if (options.Any(x => x.Equals("DATA.CVM/FIELD/RMD")))
                    randomize.RMD(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "DATA\\FIELD\\RMD"), p3files.FIELDRMD);
                if (options.Any(x => x.Equals("BTL.CVM/MODEL/FACILITYP")))
                    randomize.RMD(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "BTL\\MODEL\\FACILITYP"), p3files.FACILITYP);
                if (options.Any(x => x.Equals("BTL.CVM/MODEL/FIELD")))
                    randomize.RMD(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "BTL\\MODEL\\FIELD"), p3files.FIELD);
                if (options.Any(x => x.Equals("BTL.CVM/MODEL/NPC")))
                    randomize.RMD(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "BTL\\MODEL\\NPC"), p3files.NPC);
                if (options.Any(x => x.Equals("BTL.CVM/MODEL/PERSONA")))
                    randomize.RMD(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "BTL\\MODEL\\PERSONA"), p3files.PERSONA);
                if (options.Any(x => x.Equals("BTL.CVM/MODEL/SYMBOL")))
                    randomize.RMD(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "BTL\\MODEL\\SYMBOL"), p3files.SYMBOL);
                if (options.Any(x => x.Equals("BTL.CVM/MODEL/WEAPON")))
                   randomize.RMD(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "BTL\\MODEL\\WEAPON"), p3files.WEAPON);
                if (options.Any(x => x.Equals("BTL.CVM/MODEL/PACK")))
                    randomize.PAC(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "BTL\\MODEL\\PACK"), p3files.MODELPACK);
            }
            else if (game == "Persona 4")
            {
                if (options.Any(x => x.Equals("BGM.CVM")))
                    randomize.ADX(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "BGM"), p4files.BGM);
                if (options.Any(x => x.Equals("DATA.CVM/BUSTUP")))
                    randomize.BIN(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "DATA\\BUSTUP"), p4files.BUSTUP);
                if (options.Any(x => x.Equals("DATA.CVM/FIELD/RMD")))
                    randomize.RMD(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "DATA\\FIELD\\RMD"), p4files.FIELDRMD);
                if (options.Any(x => x.Equals("DATA.CVM/MODEL/FACILITYP")))
                    randomize.RMD(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "DATA\\MODEL\\FACILITYP"), p4files.FACILITYP);
                if (options.Any(x => x.Equals("DATA.CVM/MODEL/FIELD")))
                    randomize.RMD(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "DATA\\MODEL\\FIELD"), p4files.FIELD);
                if (options.Any(x => x.Equals("DATA.CVM/MODEL/NPC")))
                    randomize.RMD(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "DATA\\MODEL\\NPC"), p4files.NPC);
                if (options.Any(x => x.Equals("DATA.CVM/MODEL/NPC2")))
                    randomize.RMD(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "DATA\\MODEL\\NPC2"), p4files.NPC2);
                if (options.Any(x => x.Equals("DATA.CVM/MODEL/SYMBOL")))
                    randomize.RMD(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "DATA\\MODEL\\SYMBOL"), p4files.SYMBOL);
                if (options.Any(x => x.Equals("DATA.CVM/MODEL/WEAPON")))
                    randomize.RMD(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "DATA\\MODEL\\WEAPON"), p4files.WEAPON);
                if (options.Any(x => x.Equals("BTL.CVM/MODEL_BTL/PERSONA")))
                    randomize.RMD(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "BTL\\MODEL_BTL\\PERSONA"), p4files.PERSONA);
                if (options.Any(x => x.Equals("BTL.CVM/MODEL_BTL/PACK")))
                    randomize.PAC(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "BTL\\MODEL_BTL\\PACK"), p4files.MODELBTLPACK);
                if (options.Any(x => x.Equals("DATA.CVM/MODEL/PACK")))
                    randomize.PAC(txt_InputFolder.Text, Path.Combine(txt_ModFolder.Text, "DATA\\MODEL\\PACK"), p4files.MODELPACK);
            }
        }

        private void Btn_RandomizeTBLs_Click(object sender, EventArgs e)
        {
            SetupTranslator();
            RandomizeTables();
            MessageBox.Show("Done randomizing tables!");
        }

        private void SetupTranslator()
        {
            BadTranslator.languages = txt_TranslateLanguages.Text.Replace(" ","").Split(',');
            BadTranslator.translationEngine = comboBox_TranslateEngine.SelectedItem.ToString();
        }

        private void RandomizeTables()
        {
            List<string> options = new List<string>();
            foreach (var item in checkedListBox_Tables.CheckedItems)
                options.Add(item.ToString());

            switch(game)
            {
                case "Persona 3 FES":
                    Persona3FesTableRandomizer.Randomize(txt_TblFolder.Text, options, txt_ModFolder.Text);
                    break;
                case "Persona 4":
                    Persona4TableRandomizer.Randomize(txt_TblFolder.Text, options, false, txt_ModFolder.Text);
                    break;
                case "Persona 4 Golden":
                    Persona4TableRandomizer.Randomize(txt_TblFolder.Text, options, true, txt_ModFolder.Text);
                    break;
                case "Persona 5":
                case "Persona 5 Royal":
                    AtlusTableRandomizer.Program.Randomize(txt_TblFolder.Text, options, txt_ModFolder.Text, txtBox_ExcludedUnits.Text);
                    break;
            }
        }

        private void ComboBox_Game_IndexChanged(object sender, EventArgs e)
        {
            // Update game variable to selected game
            game = comboBox_Game.Text;

            // Clear checkedlistboxes of their options
            checkedListBox_FilesToRandomize.Items.Clear();
            checkedListBox_Tables.Items.Clear();

            //Repopulate checkbox choices in each tab
            switch(game)
            {
                case "Persona 3 FES":
                    foreach (var tableName in p3files.p3fesTables)
                        checkedListBox_Tables.Items.Insert(0, tableName);
                    foreach (var dirName in p3files.p3Dirs)
                        checkedListBox_FilesToRandomize.Items.Insert(0, dirName);
                    break;
                case "Persona 3":
                    foreach (var tableName in p3files.p3Tables)
                        checkedListBox_Tables.Items.Insert(0, tableName);
                    foreach (var dirName in p3files.p3Dirs)
                        checkedListBox_FilesToRandomize.Items.Insert(0, dirName);
                    break;
                case "Persona 4":
                    foreach (var tableName in p4files.p4Tables)
                        checkedListBox_Tables.Items.Insert(0, tableName);
                    foreach (var tableName in p4files.p4Dirs)
                        checkedListBox_FilesToRandomize.Items.Insert(0, tableName);
                    break;
                case "Persona 4 Golden":
                    foreach (var tableName in p4files.p4Tables)
                        checkedListBox_Tables.Items.Insert(0, tableName);
                    foreach (var tableName in p4files.p4gDirs)
                        checkedListBox_FilesToRandomize.Items.Insert(0, tableName);
                    break;
                case "Persona 5":
                case "Persona 5 Royal":
                    foreach (var tableName in p5files.p5Tables)
                        checkedListBox_Tables.Items.Insert(0, tableName);
                    foreach (var tableName in p5files.p5Dirs)
                        checkedListBox_FilesToRandomize.Items.Insert(0, tableName);
                    break;
                default:
                    break;
            }
        }

        public static bool ConvertCheckState(CheckState state)
        {
            if (state == CheckState.Checked)
                return true;
            else
                return false;
        }
    }
}
