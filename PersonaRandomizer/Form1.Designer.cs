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
            this.lbl_Game = new System.Windows.Forms.Label();
            this.radio_P3FES = new System.Windows.Forms.RadioButton();
            this.radio_P4 = new System.Windows.Forms.RadioButton();
            this.lbl_Mode = new System.Windows.Forms.Label();
            this.combobox_Mode = new System.Windows.Forms.ComboBox();
            this.txt_Input = new System.Windows.Forms.TextBox();
            this.lbl_InputFolder = new System.Windows.Forms.Label();
            this.lbl_OutputFolder = new System.Windows.Forms.Label();
            this.txt_Output = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btn_Randomize
            // 
            this.btn_Randomize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btn_Randomize.Location = new System.Drawing.Point(183, 13);
            this.btn_Randomize.Name = "btn_Randomize";
            this.btn_Randomize.Size = new System.Drawing.Size(89, 75);
            this.btn_Randomize.TabIndex = 0;
            this.btn_Randomize.Text = "Randomize";
            this.btn_Randomize.UseVisualStyleBackColor = true;
            this.btn_Randomize.Click += new System.EventHandler(this.btn_Randomize_Click);
            // 
            // lbl_Game
            // 
            this.lbl_Game.AutoSize = true;
            this.lbl_Game.Location = new System.Drawing.Point(13, 13);
            this.lbl_Game.Name = "lbl_Game";
            this.lbl_Game.Size = new System.Drawing.Size(35, 13);
            this.lbl_Game.TabIndex = 1;
            this.lbl_Game.Text = "Game";
            // 
            // radio_P3FES
            // 
            this.radio_P3FES.AutoSize = true;
            this.radio_P3FES.Checked = true;
            this.radio_P3FES.Location = new System.Drawing.Point(16, 30);
            this.radio_P3FES.Name = "radio_P3FES";
            this.radio_P3FES.Size = new System.Drawing.Size(61, 17);
            this.radio_P3FES.TabIndex = 3;
            this.radio_P3FES.TabStop = true;
            this.radio_P3FES.Text = "P3 FES";
            this.radio_P3FES.UseVisualStyleBackColor = true;
            this.radio_P3FES.Click += new System.EventHandler(this.radio_P3FES_Click);
            // 
            // radio_P4
            // 
            this.radio_P4.AutoSize = true;
            this.radio_P4.Location = new System.Drawing.Point(97, 30);
            this.radio_P4.Name = "radio_P4";
            this.radio_P4.Size = new System.Drawing.Size(38, 17);
            this.radio_P4.TabIndex = 4;
            this.radio_P4.Text = "P4";
            this.radio_P4.UseVisualStyleBackColor = true;
            this.radio_P4.Click += new System.EventHandler(this.radio_P4_Click);
            // 
            // lbl_Mode
            // 
            this.lbl_Mode.AutoSize = true;
            this.lbl_Mode.Location = new System.Drawing.Point(13, 50);
            this.lbl_Mode.Name = "lbl_Mode";
            this.lbl_Mode.Size = new System.Drawing.Size(34, 13);
            this.lbl_Mode.TabIndex = 5;
            this.lbl_Mode.Text = "Mode";
            // 
            // combobox_Mode
            // 
            this.combobox_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_Mode.FormattingEnabled = true;
            this.combobox_Mode.Location = new System.Drawing.Point(16, 67);
            this.combobox_Mode.Name = "combobox_Mode";
            this.combobox_Mode.Size = new System.Drawing.Size(161, 21);
            this.combobox_Mode.TabIndex = 6;
            this.combobox_Mode.DataSourceChanged += new System.EventHandler(this.combobox_Mode_DataSourceChanged);
            // 
            // txt_Input
            // 
            this.txt_Input.Location = new System.Drawing.Point(12, 129);
            this.txt_Input.Name = "txt_Input";
            this.txt_Input.ReadOnly = true;
            this.txt_Input.Size = new System.Drawing.Size(260, 20);
            this.txt_Input.TabIndex = 2;
            this.txt_Input.Click += new System.EventHandler(this.txt_Input_Click);
            // 
            // lbl_InputFolder
            // 
            this.lbl_InputFolder.AutoSize = true;
            this.lbl_InputFolder.Location = new System.Drawing.Point(9, 113);
            this.lbl_InputFolder.Name = "lbl_InputFolder";
            this.lbl_InputFolder.Size = new System.Drawing.Size(63, 13);
            this.lbl_InputFolder.TabIndex = 7;
            this.lbl_InputFolder.Text = "Input Folder";
            // 
            // lbl_OutputFolder
            // 
            this.lbl_OutputFolder.AutoSize = true;
            this.lbl_OutputFolder.Location = new System.Drawing.Point(9, 163);
            this.lbl_OutputFolder.Name = "lbl_OutputFolder";
            this.lbl_OutputFolder.Size = new System.Drawing.Size(71, 13);
            this.lbl_OutputFolder.TabIndex = 9;
            this.lbl_OutputFolder.Text = "Output Folder";
            // 
            // txt_Output
            // 
            this.txt_Output.Location = new System.Drawing.Point(12, 179);
            this.txt_Output.Name = "txt_Output";
            this.txt_Output.ReadOnly = true;
            this.txt_Output.Size = new System.Drawing.Size(260, 20);
            this.txt_Output.TabIndex = 8;
            this.txt_Output.Click += new System.EventHandler(this.txt_Output_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 211);
            this.Controls.Add(this.lbl_OutputFolder);
            this.Controls.Add(this.txt_Output);
            this.Controls.Add(this.lbl_InputFolder);
            this.Controls.Add(this.combobox_Mode);
            this.Controls.Add(this.lbl_Mode);
            this.Controls.Add(this.radio_P4);
            this.Controls.Add(this.radio_P3FES);
            this.Controls.Add(this.txt_Input);
            this.Controls.Add(this.lbl_Game);
            this.Controls.Add(this.btn_Randomize);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 250);
            this.MinimumSize = new System.Drawing.Size(300, 250);
            this.Name = "MainForm";
            this.Text = "PersonaRandomizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Randomize;
        private System.Windows.Forms.Label lbl_Game;
        private System.Windows.Forms.RadioButton radio_P3FES;
        private System.Windows.Forms.RadioButton radio_P4;
        private System.Windows.Forms.Label lbl_Mode;
        private System.Windows.Forms.ComboBox combobox_Mode;
        private System.Windows.Forms.TextBox txt_Input;
        private System.Windows.Forms.Label lbl_InputFolder;
        private System.Windows.Forms.Label lbl_OutputFolder;
        private System.Windows.Forms.TextBox txt_Output;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

