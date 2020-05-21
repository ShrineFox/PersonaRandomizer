namespace AtlusRandomizer
{
    partial class TranslationDialog
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TranslationDialog));
            this.btn_Translate = new System.Windows.Forms.Button();
            this.textBox_Translate1 = new System.Windows.Forms.TextBox();
            this.lbl_Translate1 = new System.Windows.Forms.Label();
            this.textBox_Translate2 = new System.Windows.Forms.TextBox();
            this.textBox_Translate4 = new System.Windows.Forms.TextBox();
            this.lbl_Translate2 = new System.Windows.Forms.Label();
            this.textBox_Translate3 = new System.Windows.Forms.TextBox();
            this.lbl_TranslateHelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Translate
            // 
            this.btn_Translate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Translate.Location = new System.Drawing.Point(135, 168);
            this.btn_Translate.Name = "btn_Translate";
            this.btn_Translate.Size = new System.Drawing.Size(85, 30);
            this.btn_Translate.TabIndex = 0;
            this.btn_Translate.Text = "Translate";
            this.btn_Translate.UseVisualStyleBackColor = true;
            this.btn_Translate.Click += new System.EventHandler(this.btn_Translate_Click);
            // 
            // textBox_Translate1
            // 
            this.textBox_Translate1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox_Translate1.Location = new System.Drawing.Point(44, 84);
            this.textBox_Translate1.MaxLength = 2;
            this.textBox_Translate1.Name = "textBox_Translate1";
            this.textBox_Translate1.Size = new System.Drawing.Size(47, 22);
            this.textBox_Translate1.TabIndex = 1;
            this.textBox_Translate1.Text = "en";
            // 
            // lbl_Translate1
            // 
            this.lbl_Translate1.AutoSize = true;
            this.lbl_Translate1.Location = new System.Drawing.Point(97, 87);
            this.lbl_Translate1.Name = "lbl_Translate1";
            this.lbl_Translate1.Size = new System.Drawing.Size(24, 17);
            this.lbl_Translate1.TabIndex = 2;
            this.lbl_Translate1.Text = "=>";
            // 
            // textBox_Translate2
            // 
            this.textBox_Translate2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox_Translate2.Location = new System.Drawing.Point(127, 84);
            this.textBox_Translate2.MaxLength = 2;
            this.textBox_Translate2.Name = "textBox_Translate2";
            this.textBox_Translate2.Size = new System.Drawing.Size(47, 22);
            this.textBox_Translate2.TabIndex = 3;
            this.textBox_Translate2.Text = "ja";
            // 
            // textBox_Translate4
            // 
            this.textBox_Translate4.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox_Translate4.Location = new System.Drawing.Point(127, 112);
            this.textBox_Translate4.MaxLength = 2;
            this.textBox_Translate4.Name = "textBox_Translate4";
            this.textBox_Translate4.Size = new System.Drawing.Size(47, 22);
            this.textBox_Translate4.TabIndex = 6;
            this.textBox_Translate4.Text = "en";
            // 
            // lbl_Translate2
            // 
            this.lbl_Translate2.AutoSize = true;
            this.lbl_Translate2.Location = new System.Drawing.Point(97, 115);
            this.lbl_Translate2.Name = "lbl_Translate2";
            this.lbl_Translate2.Size = new System.Drawing.Size(24, 17);
            this.lbl_Translate2.TabIndex = 5;
            this.lbl_Translate2.Text = "=>";
            // 
            // textBox_Translate3
            // 
            this.textBox_Translate3.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox_Translate3.Location = new System.Drawing.Point(44, 112);
            this.textBox_Translate3.MaxLength = 2;
            this.textBox_Translate3.Name = "textBox_Translate3";
            this.textBox_Translate3.Size = new System.Drawing.Size(47, 22);
            this.textBox_Translate3.TabIndex = 4;
            this.textBox_Translate3.Text = "ja";
            // 
            // lbl_TranslateHelp
            // 
            this.lbl_TranslateHelp.AutoSize = true;
            this.lbl_TranslateHelp.Location = new System.Drawing.Point(12, 9);
            this.lbl_TranslateHelp.Name = "lbl_TranslateHelp";
            this.lbl_TranslateHelp.Size = new System.Drawing.Size(0, 17);
            this.lbl_TranslateHelp.TabIndex = 10;
            // 
            // TranslationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 203);
            this.Controls.Add(this.lbl_TranslateHelp);
            this.Controls.Add(this.textBox_Translate4);
            this.Controls.Add(this.lbl_Translate2);
            this.Controls.Add(this.textBox_Translate3);
            this.Controls.Add(this.textBox_Translate2);
            this.Controls.Add(this.lbl_Translate1);
            this.Controls.Add(this.textBox_Translate1);
            this.Controls.Add(this.btn_Translate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(250, 250);
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "TranslationDialog";
            this.Text = "Translate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Translate;
        public System.Windows.Forms.TextBox textBox_Translate1;
        private System.Windows.Forms.Label lbl_Translate1;
        public System.Windows.Forms.TextBox textBox_Translate2;
        public System.Windows.Forms.TextBox textBox_Translate4;
        private System.Windows.Forms.Label lbl_Translate2;
        public System.Windows.Forms.TextBox textBox_Translate3;
        private System.Windows.Forms.Label lbl_TranslateHelp;
    }
}