using System.Collections.Generic;

namespace PersonaRandomizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_RandomizeFiles = new System.Windows.Forms.Button();
            this.txt_InputFolder = new System.Windows.Forms.TextBox();
            this.txt_ModFolder = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl_RandomizeType = new System.Windows.Forms.TabControl();
            this.tabPage_Files = new System.Windows.Forms.TabPage();
            this.tlp_RandomizeFiles = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_InputFolder = new System.Windows.Forms.GroupBox();
            this.lbl_InputFolder = new System.Windows.Forms.Label();
            this.groupBox_ModFolder = new System.Windows.Forms.GroupBox();
            this.lbl_ModFolder = new System.Windows.Forms.Label();
            this.groupBox_FilesToRandomize = new System.Windows.Forms.GroupBox();
            this.checkedListBox_FilesToRandomize = new System.Windows.Forms.CheckedListBox();
            this.lbl_Usage = new System.Windows.Forms.Label();
            this.tabPage_Tables = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_TranslateEngine = new System.Windows.Forms.GroupBox();
            this.comboBox_TranslateEngine = new System.Windows.Forms.ComboBox();
            this.groupBox_TranslateLanguages = new System.Windows.Forms.GroupBox();
            this.txt_TranslateLanguages = new System.Windows.Forms.TextBox();
            this.groupBox_TBLsFolder = new System.Windows.Forms.GroupBox();
            this.txt_TblFolder = new System.Windows.Forms.TextBox();
            this.checkedListBox_Tables = new System.Windows.Forms.CheckedListBox();
            this.groupBox_ExcludedUnits = new System.Windows.Forms.GroupBox();
            this.txtBox_ExcludedUnits = new System.Windows.Forms.TextBox();
            this.btn_RandomizeTBLs = new System.Windows.Forms.Button();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.comboBox_Game = new System.Windows.Forms.ComboBox();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_Game = new System.Windows.Forms.GroupBox();
            this.tabControl_RandomizeType.SuspendLayout();
            this.tabPage_Files.SuspendLayout();
            this.tlp_RandomizeFiles.SuspendLayout();
            this.groupBox_InputFolder.SuspendLayout();
            this.groupBox_ModFolder.SuspendLayout();
            this.groupBox_FilesToRandomize.SuspendLayout();
            this.tabPage_Tables.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox_TranslateEngine.SuspendLayout();
            this.groupBox_TranslateLanguages.SuspendLayout();
            this.groupBox_TBLsFolder.SuspendLayout();
            this.groupBox_ExcludedUnits.SuspendLayout();
            this.tlp_Main.SuspendLayout();
            this.groupBox_Game.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_RandomizeFiles
            // 
            this.btn_RandomizeFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_RandomizeFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btn_RandomizeFiles.Location = new System.Drawing.Point(371, 198);
            this.btn_RandomizeFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btn_RandomizeFiles.Name = "btn_RandomizeFiles";
            this.btn_RandomizeFiles.Size = new System.Drawing.Size(360, 92);
            this.btn_RandomizeFiles.TabIndex = 0;
            this.btn_RandomizeFiles.Text = "Randomize Files";
            this.btn_RandomizeFiles.UseVisualStyleBackColor = true;
            this.btn_RandomizeFiles.Click += new System.EventHandler(this.btn_RandomizeFiles_Click);
            // 
            // txt_InputFolder
            // 
            this.txt_InputFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_InputFolder.Location = new System.Drawing.Point(3, 18);
            this.txt_InputFolder.Margin = new System.Windows.Forms.Padding(4);
            this.txt_InputFolder.Name = "txt_InputFolder";
            this.txt_InputFolder.ReadOnly = true;
            this.txt_InputFolder.Size = new System.Drawing.Size(356, 22);
            this.txt_InputFolder.TabIndex = 2;
            this.txt_InputFolder.Click += new System.EventHandler(this.txt_InputFolder_Click);
            // 
            // txt_ModFolder
            // 
            this.txt_ModFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ModFolder.Location = new System.Drawing.Point(3, 18);
            this.txt_ModFolder.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ModFolder.Name = "txt_ModFolder";
            this.txt_ModFolder.ReadOnly = true;
            this.txt_ModFolder.Size = new System.Drawing.Size(356, 22);
            this.txt_ModFolder.TabIndex = 8;
            this.txt_ModFolder.Click += new System.EventHandler(this.txt_ModFolder_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            // 
            // tabControl_RandomizeType
            // 
            this.tlp_Main.SetColumnSpan(this.tabControl_RandomizeType, 2);
            this.tabControl_RandomizeType.Controls.Add(this.tabPage_Files);
            this.tabControl_RandomizeType.Controls.Add(this.tabPage_Tables);
            this.tabControl_RandomizeType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_RandomizeType.Location = new System.Drawing.Point(3, 61);
            this.tabControl_RandomizeType.Name = "tabControl_RandomizeType";
            this.tabControl_RandomizeType.SelectedIndex = 0;
            this.tabControl_RandomizeType.Size = new System.Drawing.Size(749, 329);
            this.tabControl_RandomizeType.TabIndex = 10;
            // 
            // tabPage_Files
            // 
            this.tabPage_Files.Controls.Add(this.tlp_RandomizeFiles);
            this.tabPage_Files.Controls.Add(this.lbl_Usage);
            this.tabPage_Files.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Files.Name = "tabPage_Files";
            this.tabPage_Files.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Files.Size = new System.Drawing.Size(741, 300);
            this.tabPage_Files.TabIndex = 0;
            this.tabPage_Files.Text = "Files";
            this.tabPage_Files.UseVisualStyleBackColor = true;
            // 
            // tlp_RandomizeFiles
            // 
            this.tlp_RandomizeFiles.ColumnCount = 2;
            this.tlp_RandomizeFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_RandomizeFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_RandomizeFiles.Controls.Add(this.groupBox_InputFolder, 1, 0);
            this.tlp_RandomizeFiles.Controls.Add(this.btn_RandomizeFiles, 1, 2);
            this.tlp_RandomizeFiles.Controls.Add(this.groupBox_ModFolder, 1, 1);
            this.tlp_RandomizeFiles.Controls.Add(this.groupBox_FilesToRandomize, 0, 0);
            this.tlp_RandomizeFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_RandomizeFiles.Location = new System.Drawing.Point(3, 3);
            this.tlp_RandomizeFiles.Name = "tlp_RandomizeFiles";
            this.tlp_RandomizeFiles.RowCount = 3;
            this.tlp_RandomizeFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_RandomizeFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_RandomizeFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_RandomizeFiles.Size = new System.Drawing.Size(735, 294);
            this.tlp_RandomizeFiles.TabIndex = 11;
            // 
            // groupBox_InputFolder
            // 
            this.groupBox_InputFolder.Controls.Add(this.lbl_InputFolder);
            this.groupBox_InputFolder.Controls.Add(this.txt_InputFolder);
            this.groupBox_InputFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_InputFolder.Location = new System.Drawing.Point(370, 3);
            this.groupBox_InputFolder.Name = "groupBox_InputFolder";
            this.groupBox_InputFolder.Size = new System.Drawing.Size(362, 91);
            this.groupBox_InputFolder.TabIndex = 0;
            this.groupBox_InputFolder.TabStop = false;
            this.groupBox_InputFolder.Text = "Input Files Folder";
            // 
            // lbl_InputFolder
            // 
            this.lbl_InputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_InputFolder.AutoSize = true;
            this.lbl_InputFolder.Location = new System.Drawing.Point(7, 54);
            this.lbl_InputFolder.Name = "lbl_InputFolder";
            this.lbl_InputFolder.Size = new System.Drawing.Size(220, 32);
            this.lbl_InputFolder.TabIndex = 3;
            this.lbl_InputFolder.Text = "Folder/subfolders containing \r\nRMD, ADX etc. files to copy + shuffle\r\n";
            // 
            // groupBox_ModFolder
            // 
            this.groupBox_ModFolder.Controls.Add(this.lbl_ModFolder);
            this.groupBox_ModFolder.Controls.Add(this.txt_ModFolder);
            this.groupBox_ModFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_ModFolder.Location = new System.Drawing.Point(370, 100);
            this.groupBox_ModFolder.Name = "groupBox_ModFolder";
            this.groupBox_ModFolder.Size = new System.Drawing.Size(362, 91);
            this.groupBox_ModFolder.TabIndex = 1;
            this.groupBox_ModFolder.TabStop = false;
            this.groupBox_ModFolder.Text = "Mod Folder";
            // 
            // lbl_ModFolder
            // 
            this.lbl_ModFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ModFolder.AutoSize = true;
            this.lbl_ModFolder.Location = new System.Drawing.Point(7, 56);
            this.lbl_ModFolder.Name = "lbl_ModFolder";
            this.lbl_ModFolder.Size = new System.Drawing.Size(146, 32);
            this.lbl_ModFolder.TabIndex = 9;
            this.lbl_ModFolder.Text = "Root of output directory\r\ni.e. Aemulus mod folder\r\n";
            // 
            // groupBox_FilesToRandomize
            // 
            this.groupBox_FilesToRandomize.Controls.Add(this.checkedListBox_FilesToRandomize);
            this.groupBox_FilesToRandomize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_FilesToRandomize.Location = new System.Drawing.Point(3, 3);
            this.groupBox_FilesToRandomize.Name = "groupBox_FilesToRandomize";
            this.tlp_RandomizeFiles.SetRowSpan(this.groupBox_FilesToRandomize, 3);
            this.groupBox_FilesToRandomize.Size = new System.Drawing.Size(361, 288);
            this.groupBox_FilesToRandomize.TabIndex = 2;
            this.groupBox_FilesToRandomize.TabStop = false;
            this.groupBox_FilesToRandomize.Text = "Files to Randomize";
            // 
            // checkedListBox_FilesToRandomize
            // 
            this.checkedListBox_FilesToRandomize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_FilesToRandomize.FormattingEnabled = true;
            this.checkedListBox_FilesToRandomize.Location = new System.Drawing.Point(3, 18);
            this.checkedListBox_FilesToRandomize.Name = "checkedListBox_FilesToRandomize";
            this.checkedListBox_FilesToRandomize.Size = new System.Drawing.Size(355, 267);
            this.checkedListBox_FilesToRandomize.TabIndex = 18;
            // 
            // lbl_Usage
            // 
            this.lbl_Usage.AutoSize = true;
            this.lbl_Usage.Location = new System.Drawing.Point(7, 168);
            this.lbl_Usage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Usage.Name = "lbl_Usage";
            this.lbl_Usage.Size = new System.Drawing.Size(0, 16);
            this.lbl_Usage.TabIndex = 10;
            // 
            // tabPage_Tables
            // 
            this.tabPage_Tables.Controls.Add(this.tableLayoutPanel1);
            this.tabPage_Tables.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Tables.Name = "tabPage_Tables";
            this.tabPage_Tables.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Tables.Size = new System.Drawing.Size(741, 300);
            this.tabPage_Tables.TabIndex = 1;
            this.tabPage_Tables.Text = "Tables";
            this.tabPage_Tables.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox_TranslateEngine, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_TranslateLanguages, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_TBLsFolder, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkedListBox_Tables, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_ExcludedUnits, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_RandomizeTBLs, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(735, 294);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // groupBox_TranslateEngine
            // 
            this.groupBox_TranslateEngine.Controls.Add(this.comboBox_TranslateEngine);
            this.groupBox_TranslateEngine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_TranslateEngine.Location = new System.Drawing.Point(3, 222);
            this.groupBox_TranslateEngine.Name = "groupBox_TranslateEngine";
            this.groupBox_TranslateEngine.Size = new System.Drawing.Size(361, 69);
            this.groupBox_TranslateEngine.TabIndex = 19;
            this.groupBox_TranslateEngine.TabStop = false;
            this.groupBox_TranslateEngine.Text = "Translation Engine";
            // 
            // comboBox_TranslateEngine
            // 
            this.comboBox_TranslateEngine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_TranslateEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TranslateEngine.FormattingEnabled = true;
            this.comboBox_TranslateEngine.Items.AddRange(new object[] {
            "BingTranslate",
            "GoogleTranslate",
            "GoogleTranslate2",
            "MicrosoftAzureTranslator",
            "YandexTranslate"});
            this.comboBox_TranslateEngine.Location = new System.Drawing.Point(3, 18);
            this.comboBox_TranslateEngine.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_TranslateEngine.Name = "comboBox_TranslateEngine";
            this.comboBox_TranslateEngine.Size = new System.Drawing.Size(355, 24);
            this.comboBox_TranslateEngine.TabIndex = 10;
            // 
            // groupBox_TranslateLanguages
            // 
            this.groupBox_TranslateLanguages.Controls.Add(this.txt_TranslateLanguages);
            this.groupBox_TranslateLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_TranslateLanguages.Location = new System.Drawing.Point(370, 149);
            this.groupBox_TranslateLanguages.Name = "groupBox_TranslateLanguages";
            this.groupBox_TranslateLanguages.Size = new System.Drawing.Size(362, 67);
            this.groupBox_TranslateLanguages.TabIndex = 18;
            this.groupBox_TranslateLanguages.TabStop = false;
            this.groupBox_TranslateLanguages.Text = "Translate Languages";
            // 
            // txt_TranslateLanguages
            // 
            this.txt_TranslateLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_TranslateLanguages.Location = new System.Drawing.Point(3, 18);
            this.txt_TranslateLanguages.Margin = new System.Windows.Forms.Padding(4);
            this.txt_TranslateLanguages.Name = "txt_TranslateLanguages";
            this.txt_TranslateLanguages.Size = new System.Drawing.Size(356, 22);
            this.txt_TranslateLanguages.TabIndex = 18;
            this.txt_TranslateLanguages.Text = "ja, de, zh-TW, tr, sw, en";
            // 
            // groupBox_TBLsFolder
            // 
            this.groupBox_TBLsFolder.Controls.Add(this.txt_TblFolder);
            this.groupBox_TBLsFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_TBLsFolder.Location = new System.Drawing.Point(370, 3);
            this.groupBox_TBLsFolder.Name = "groupBox_TBLsFolder";
            this.groupBox_TBLsFolder.Size = new System.Drawing.Size(362, 67);
            this.groupBox_TBLsFolder.TabIndex = 0;
            this.groupBox_TBLsFolder.TabStop = false;
            this.groupBox_TBLsFolder.Text = "Extracted TBLs Folder";
            // 
            // txt_TblFolder
            // 
            this.txt_TblFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_TblFolder.Location = new System.Drawing.Point(3, 18);
            this.txt_TblFolder.Margin = new System.Windows.Forms.Padding(4);
            this.txt_TblFolder.Name = "txt_TblFolder";
            this.txt_TblFolder.ReadOnly = true;
            this.txt_TblFolder.Size = new System.Drawing.Size(356, 22);
            this.txt_TblFolder.TabIndex = 14;
            this.txt_TblFolder.Click += new System.EventHandler(this.txtBox_TableFolder_Click);
            // 
            // checkedListBox_Tables
            // 
            this.checkedListBox_Tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_Tables.FormattingEnabled = true;
            this.checkedListBox_Tables.Location = new System.Drawing.Point(3, 3);
            this.checkedListBox_Tables.Name = "checkedListBox_Tables";
            this.tableLayoutPanel1.SetRowSpan(this.checkedListBox_Tables, 3);
            this.checkedListBox_Tables.Size = new System.Drawing.Size(361, 213);
            this.checkedListBox_Tables.TabIndex = 16;
            // 
            // groupBox_ExcludedUnits
            // 
            this.groupBox_ExcludedUnits.Controls.Add(this.txtBox_ExcludedUnits);
            this.groupBox_ExcludedUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_ExcludedUnits.Location = new System.Drawing.Point(370, 76);
            this.groupBox_ExcludedUnits.Name = "groupBox_ExcludedUnits";
            this.groupBox_ExcludedUnits.Size = new System.Drawing.Size(362, 67);
            this.groupBox_ExcludedUnits.TabIndex = 1;
            this.groupBox_ExcludedUnits.TabStop = false;
            this.groupBox_ExcludedUnits.Text = "Excluded Unit IDs";
            // 
            // txtBox_ExcludedUnits
            // 
            this.txtBox_ExcludedUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBox_ExcludedUnits.Location = new System.Drawing.Point(3, 18);
            this.txtBox_ExcludedUnits.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_ExcludedUnits.Name = "txtBox_ExcludedUnits";
            this.txtBox_ExcludedUnits.Size = new System.Drawing.Size(356, 22);
            this.txtBox_ExcludedUnits.TabIndex = 18;
            // 
            // btn_RandomizeTBLs
            // 
            this.btn_RandomizeTBLs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btn_RandomizeTBLs.Location = new System.Drawing.Point(371, 223);
            this.btn_RandomizeTBLs.Margin = new System.Windows.Forms.Padding(4);
            this.btn_RandomizeTBLs.Name = "btn_RandomizeTBLs";
            this.btn_RandomizeTBLs.Size = new System.Drawing.Size(231, 62);
            this.btn_RandomizeTBLs.TabIndex = 17;
            this.btn_RandomizeTBLs.Text = "Randomize TBLs";
            this.btn_RandomizeTBLs.UseVisualStyleBackColor = true;
            this.btn_RandomizeTBLs.Click += new System.EventHandler(this.Btn_RandomizeTBLs_Click);
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Location = new System.Drawing.Point(16, 38);
            this.lbl_Status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(0, 16);
            this.lbl_Status.TabIndex = 13;
            // 
            // comboBox_Game
            // 
            this.comboBox_Game.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_Game.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Game.FormattingEnabled = true;
            this.comboBox_Game.Items.AddRange(new object[] {
            "Persona 3 FES",
            "Persona 4",
            "Persona 4 Golden",
            "Persona 5",
            "Persona 5 Royal"});
            this.comboBox_Game.Location = new System.Drawing.Point(3, 18);
            this.comboBox_Game.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Game.Name = "comboBox_Game";
            this.comboBox_Game.Size = new System.Drawing.Size(365, 24);
            this.comboBox_Game.TabIndex = 10;
            this.comboBox_Game.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Game_IndexChanged);
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 2;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Controls.Add(this.groupBox_Game, 0, 0);
            this.tlp_Main.Controls.Add(this.tabControl_RandomizeType, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tlp_Main.Size = new System.Drawing.Size(755, 393);
            this.tlp_Main.TabIndex = 14;
            // 
            // groupBox_Game
            // 
            this.groupBox_Game.Controls.Add(this.comboBox_Game);
            this.groupBox_Game.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Game.Location = new System.Drawing.Point(3, 3);
            this.groupBox_Game.Name = "groupBox_Game";
            this.groupBox_Game.Size = new System.Drawing.Size(371, 52);
            this.groupBox_Game.TabIndex = 0;
            this.groupBox_Game.TabStop = false;
            this.groupBox_Game.Text = "Game";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 393);
            this.Controls.Add(this.tlp_Main);
            this.Controls.Add(this.lbl_Status);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(400, 350);
            this.Name = "MainForm";
            this.Text = "PRandomizer 2.2";
            this.tabControl_RandomizeType.ResumeLayout(false);
            this.tabPage_Files.ResumeLayout(false);
            this.tabPage_Files.PerformLayout();
            this.tlp_RandomizeFiles.ResumeLayout(false);
            this.groupBox_InputFolder.ResumeLayout(false);
            this.groupBox_InputFolder.PerformLayout();
            this.groupBox_ModFolder.ResumeLayout(false);
            this.groupBox_ModFolder.PerformLayout();
            this.groupBox_FilesToRandomize.ResumeLayout(false);
            this.tabPage_Tables.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox_TranslateEngine.ResumeLayout(false);
            this.groupBox_TranslateLanguages.ResumeLayout(false);
            this.groupBox_TranslateLanguages.PerformLayout();
            this.groupBox_TBLsFolder.ResumeLayout(false);
            this.groupBox_TBLsFolder.PerformLayout();
            this.groupBox_ExcludedUnits.ResumeLayout(false);
            this.groupBox_ExcludedUnits.PerformLayout();
            this.tlp_Main.ResumeLayout(false);
            this.groupBox_Game.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_RandomizeFiles;
        private System.Windows.Forms.TextBox txt_InputFolder;
        private System.Windows.Forms.TextBox txt_ModFolder;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabControl_RandomizeType;
        private System.Windows.Forms.TabPage tabPage_Files;
        private System.Windows.Forms.TabPage tabPage_Tables;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.TextBox txt_TblFolder;
        private System.Windows.Forms.CheckedListBox checkedListBox_Tables;
        private System.Windows.Forms.ComboBox comboBox_Game;
        private System.Windows.Forms.Label lbl_Usage;
        private System.Windows.Forms.TextBox txtBox_ExcludedUnits;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.GroupBox groupBox_Game;
        private System.Windows.Forms.TableLayoutPanel tlp_RandomizeFiles;
        private System.Windows.Forms.GroupBox groupBox_InputFolder;
        private System.Windows.Forms.GroupBox groupBox_ModFolder;
        private System.Windows.Forms.GroupBox groupBox_FilesToRandomize;
        private System.Windows.Forms.CheckedListBox checkedListBox_FilesToRandomize;
        private System.Windows.Forms.Label lbl_InputFolder;
        private System.Windows.Forms.Label lbl_ModFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox_TBLsFolder;
        private System.Windows.Forms.Button btn_RandomizeTBLs;
        private System.Windows.Forms.GroupBox groupBox_ExcludedUnits;
        private System.Windows.Forms.GroupBox groupBox_TranslateLanguages;
        private System.Windows.Forms.TextBox txt_TranslateLanguages;
        private System.Windows.Forms.GroupBox groupBox_TranslateEngine;
        private System.Windows.Forms.ComboBox comboBox_TranslateEngine;
    }
}

