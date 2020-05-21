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
            this.btn_Randomize = new System.Windows.Forms.Button();
            this.lbl_Mode = new System.Windows.Forms.Label();
            this.combobox_Mode = new System.Windows.Forms.ComboBox();
            this.txt_Input = new System.Windows.Forms.TextBox();
            this.lbl_InputFolder = new System.Windows.Forms.Label();
            this.lbl_OutputFolder = new System.Windows.Forms.Label();
            this.txt_Output = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl_RandomizeType = new System.Windows.Forms.TabControl();
            this.tabPage_Files = new System.Windows.Forms.TabPage();
            this.tabPage_Tables = new System.Windows.Forms.TabPage();
            this.checkBox_BossRush = new System.Windows.Forms.CheckBox();
            this.checkedListBox_Tables = new System.Windows.Forms.CheckedListBox();
            this.lbl_TableInput = new System.Windows.Forms.Label();
            this.txtBox_TableInput = new System.Windows.Forms.TextBox();
            this.lbl_Game = new System.Windows.Forms.Label();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.comboBox_Game = new System.Windows.Forms.ComboBox();
            this.lbl_Usage = new System.Windows.Forms.Label();
            this.tabControl_RandomizeType.SuspendLayout();
            this.tabPage_Files.SuspendLayout();
            this.tabPage_Tables.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Randomize
            // 
            this.btn_Randomize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btn_Randomize.Location = new System.Drawing.Point(238, 10);
            this.btn_Randomize.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Randomize.Name = "btn_Randomize";
            this.btn_Randomize.Size = new System.Drawing.Size(131, 47);
            this.btn_Randomize.TabIndex = 0;
            this.btn_Randomize.Text = "Randomize";
            this.btn_Randomize.UseVisualStyleBackColor = true;
            this.btn_Randomize.Click += new System.EventHandler(this.btn_Randomize_Click);
            // 
            // lbl_Mode
            // 
            this.lbl_Mode.AutoSize = true;
            this.lbl_Mode.Location = new System.Drawing.Point(7, 19);
            this.lbl_Mode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Mode.Name = "lbl_Mode";
            this.lbl_Mode.Size = new System.Drawing.Size(47, 17);
            this.lbl_Mode.TabIndex = 5;
            this.lbl_Mode.Text = "Mode:";
            // 
            // combobox_Mode
            // 
            this.combobox_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_Mode.FormattingEnabled = true;
            this.combobox_Mode.Location = new System.Drawing.Point(59, 16);
            this.combobox_Mode.Margin = new System.Windows.Forms.Padding(4);
            this.combobox_Mode.Name = "combobox_Mode";
            this.combobox_Mode.Size = new System.Drawing.Size(193, 24);
            this.combobox_Mode.TabIndex = 6;
            this.combobox_Mode.DataSourceChanged += new System.EventHandler(this.combobox_Mode_DataSourceChanged);
            // 
            // txt_Input
            // 
            this.txt_Input.Location = new System.Drawing.Point(10, 75);
            this.txt_Input.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Input.Name = "txt_Input";
            this.txt_Input.ReadOnly = true;
            this.txt_Input.Size = new System.Drawing.Size(313, 22);
            this.txt_Input.TabIndex = 2;
            this.txt_Input.Click += new System.EventHandler(this.txt_Input_Click);
            // 
            // lbl_InputFolder
            // 
            this.lbl_InputFolder.AutoSize = true;
            this.lbl_InputFolder.Location = new System.Drawing.Point(7, 54);
            this.lbl_InputFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_InputFolder.Name = "lbl_InputFolder";
            this.lbl_InputFolder.Size = new System.Drawing.Size(87, 17);
            this.lbl_InputFolder.TabIndex = 7;
            this.lbl_InputFolder.Text = "Input Folder:";
            // 
            // lbl_OutputFolder
            // 
            this.lbl_OutputFolder.AutoSize = true;
            this.lbl_OutputFolder.Location = new System.Drawing.Point(7, 113);
            this.lbl_OutputFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_OutputFolder.Name = "lbl_OutputFolder";
            this.lbl_OutputFolder.Size = new System.Drawing.Size(99, 17);
            this.lbl_OutputFolder.TabIndex = 9;
            this.lbl_OutputFolder.Text = "Output Folder:";
            // 
            // txt_Output
            // 
            this.txt_Output.Location = new System.Drawing.Point(10, 134);
            this.txt_Output.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Output.Name = "txt_Output";
            this.txt_Output.ReadOnly = true;
            this.txt_Output.Size = new System.Drawing.Size(313, 22);
            this.txt_Output.TabIndex = 8;
            this.txt_Output.Click += new System.EventHandler(this.txt_Output_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            // 
            // tabControl_RandomizeType
            // 
            this.tabControl_RandomizeType.Controls.Add(this.tabPage_Files);
            this.tabControl_RandomizeType.Controls.Add(this.tabPage_Tables);
            this.tabControl_RandomizeType.Location = new System.Drawing.Point(16, 64);
            this.tabControl_RandomizeType.Name = "tabControl_RandomizeType";
            this.tabControl_RandomizeType.SelectedIndex = 0;
            this.tabControl_RandomizeType.Size = new System.Drawing.Size(351, 238);
            this.tabControl_RandomizeType.TabIndex = 10;
            this.tabControl_RandomizeType.SelectedIndexChanged += new System.EventHandler(this.RandomizeType_SelectedIndexChanged);
            // 
            // tabPage_Files
            // 
            this.tabPage_Files.Controls.Add(this.lbl_Usage);
            this.tabPage_Files.Controls.Add(this.lbl_Mode);
            this.tabPage_Files.Controls.Add(this.txt_Output);
            this.tabPage_Files.Controls.Add(this.lbl_OutputFolder);
            this.tabPage_Files.Controls.Add(this.combobox_Mode);
            this.tabPage_Files.Controls.Add(this.lbl_InputFolder);
            this.tabPage_Files.Controls.Add(this.txt_Input);
            this.tabPage_Files.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Files.Name = "tabPage_Files";
            this.tabPage_Files.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Files.Size = new System.Drawing.Size(343, 209);
            this.tabPage_Files.TabIndex = 0;
            this.tabPage_Files.Text = "Files";
            this.tabPage_Files.UseVisualStyleBackColor = true;
            // 
            // tabPage_Tables
            // 
            this.tabPage_Tables.Controls.Add(this.checkBox_BossRush);
            this.tabPage_Tables.Controls.Add(this.checkedListBox_Tables);
            this.tabPage_Tables.Controls.Add(this.lbl_TableInput);
            this.tabPage_Tables.Controls.Add(this.txtBox_TableInput);
            this.tabPage_Tables.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Tables.Name = "tabPage_Tables";
            this.tabPage_Tables.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Tables.Size = new System.Drawing.Size(343, 209);
            this.tabPage_Tables.TabIndex = 1;
            this.tabPage_Tables.Text = "Tables";
            this.tabPage_Tables.UseVisualStyleBackColor = true;
            // 
            // checkBox_BossRush
            // 
            this.checkBox_BossRush.AccessibleDescription = "";
            this.checkBox_BossRush.AutoSize = true;
            this.checkBox_BossRush.Location = new System.Drawing.Point(229, 18);
            this.checkBox_BossRush.Name = "checkBox_BossRush";
            this.checkBox_BossRush.Size = new System.Drawing.Size(98, 21);
            this.checkBox_BossRush.TabIndex = 17;
            this.checkBox_BossRush.Text = "Boss Rush";
            this.checkBox_BossRush.UseVisualStyleBackColor = true;
            // 
            // checkedListBox_Tables
            // 
            this.checkedListBox_Tables.FormattingEnabled = true;
            this.checkedListBox_Tables.Location = new System.Drawing.Point(14, 70);
            this.checkedListBox_Tables.MultiColumn = true;
            this.checkedListBox_Tables.Name = "checkedListBox_Tables";
            this.checkedListBox_Tables.Size = new System.Drawing.Size(313, 140);
            this.checkedListBox_Tables.TabIndex = 16;
            // 
            // lbl_TableInput
            // 
            this.lbl_TableInput.AutoSize = true;
            this.lbl_TableInput.Location = new System.Drawing.Point(11, 20);
            this.lbl_TableInput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TableInput.Name = "lbl_TableInput";
            this.lbl_TableInput.Size = new System.Drawing.Size(156, 17);
            this.lbl_TableInput.TabIndex = 15;
            this.lbl_TableInput.Text = "Extracted .TBLs Folder:";
            // 
            // txtBox_TableInput
            // 
            this.txtBox_TableInput.Location = new System.Drawing.Point(14, 41);
            this.txtBox_TableInput.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_TableInput.Name = "txtBox_TableInput";
            this.txtBox_TableInput.ReadOnly = true;
            this.txtBox_TableInput.Size = new System.Drawing.Size(313, 22);
            this.txtBox_TableInput.TabIndex = 14;
            this.txtBox_TableInput.Click += new System.EventHandler(this.txtBox_TableInput_Click);
            // 
            // lbl_Game
            // 
            this.lbl_Game.AutoSize = true;
            this.lbl_Game.Location = new System.Drawing.Point(13, 13);
            this.lbl_Game.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Game.Name = "lbl_Game";
            this.lbl_Game.Size = new System.Drawing.Size(50, 17);
            this.lbl_Game.TabIndex = 10;
            this.lbl_Game.Text = "Game:";
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Location = new System.Drawing.Point(16, 38);
            this.lbl_Status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(0, 17);
            this.lbl_Status.TabIndex = 13;
            // 
            // comboBox_Game
            // 
            this.comboBox_Game.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Game.FormattingEnabled = true;
            this.comboBox_Game.Items.AddRange(new object[] {
            "Persona 3 FES",
            "Persona 4",
            "Persona 4 Golden",
            "Persona 5"});
            this.comboBox_Game.Location = new System.Drawing.Point(71, 10);
            this.comboBox_Game.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Game.Name = "comboBox_Game";
            this.comboBox_Game.Size = new System.Drawing.Size(159, 24);
            this.comboBox_Game.TabIndex = 10;
            this.comboBox_Game.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Game_IndexChanged);
            // 
            // lbl_Usage
            // 
            this.lbl_Usage.AutoSize = true;
            this.lbl_Usage.Location = new System.Drawing.Point(7, 168);
            this.lbl_Usage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Usage.Name = "lbl_Usage";
            this.lbl_Usage.Size = new System.Drawing.Size(0, 17);
            this.lbl_Usage.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 303);
            this.Controls.Add(this.comboBox_Game);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.lbl_Game);
            this.Controls.Add(this.tabControl_RandomizeType);
            this.Controls.Add(this.btn_Randomize);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(400, 350);
            this.MinimumSize = new System.Drawing.Size(400, 350);
            this.Name = "MainForm";
            this.Text = "PersonaRandomizer";
            this.tabControl_RandomizeType.ResumeLayout(false);
            this.tabPage_Files.ResumeLayout(false);
            this.tabPage_Files.PerformLayout();
            this.tabPage_Tables.ResumeLayout(false);
            this.tabPage_Tables.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Randomize;
        private System.Windows.Forms.Label lbl_Mode;
        private System.Windows.Forms.TextBox txt_Input;
        private System.Windows.Forms.Label lbl_InputFolder;
        private System.Windows.Forms.Label lbl_OutputFolder;
        private System.Windows.Forms.TextBox txt_Output;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabControl_RandomizeType;
        private System.Windows.Forms.TabPage tabPage_Files;
        private System.Windows.Forms.TabPage tabPage_Tables;
        private System.Windows.Forms.Label lbl_Game;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Label lbl_TableInput;
        private System.Windows.Forms.TextBox txtBox_TableInput;
        private System.Windows.Forms.CheckedListBox checkedListBox_Tables;
        private System.Windows.Forms.ComboBox comboBox_Game;
        public System.Windows.Forms.ComboBox combobox_Mode;
        private System.Windows.Forms.CheckBox checkBox_BossRush;
        private System.Windows.Forms.Label lbl_Usage;
    }
}

