namespace B04_A01_TextEditorV2
{
    partial class replaceDialog
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
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.replace = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.replaceall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 123);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(183, 19);
            this.checkBox2.TabIndex = 17;
            this.checkBox2.Text = "Am Ende von vorne beginnen";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 93);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(147, 19);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Groß-/Kleinschreibung";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "Suchen nach:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(70, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 23);
            this.textBox1.TabIndex = 12;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // search
            // 
            this.search.Enabled = false;
            this.search.Location = new System.Drawing.Point(292, 12);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(113, 23);
            this.search.TabIndex = 10;
            this.search.Text = "Suchen";
            this.search.UseVisualStyleBackColor = true;
            this.search.MouseDown += new System.Windows.Forms.MouseEventHandler(this.search_MouseDown_1);
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.Location = new System.Drawing.Point(11, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 32);
            this.label2.TabIndex = 19;
            this.label2.Text = "Ersetzen durch:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(70, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(209, 23);
            this.textBox2.TabIndex = 18;
            // 
            // replace
            // 
            this.replace.Enabled = false;
            this.replace.Location = new System.Drawing.Point(293, 47);
            this.replace.Name = "replace";
            this.replace.Size = new System.Drawing.Size(112, 23);
            this.replace.TabIndex = 20;
            this.replace.Text = "Ersetzen";
            this.replace.UseVisualStyleBackColor = true;
            this.replace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.replace_MouseDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(293, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Abbrechen";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // replaceall
            // 
            this.replaceall.Enabled = false;
            this.replaceall.Location = new System.Drawing.Point(292, 84);
            this.replaceall.Name = "replaceall";
            this.replaceall.Size = new System.Drawing.Size(113, 23);
            this.replaceall.TabIndex = 21;
            this.replaceall.Text = "Alle ersetzen";
            this.replaceall.UseVisualStyleBackColor = true;
            this.replaceall.MouseDown += new System.Windows.Forms.MouseEventHandler(this.replaceall_MouseDown);
            // 
            // replaceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 154);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.replaceall);
            this.Controls.Add(this.replace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.search);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "replaceDialog";
            this.ShowInTaskbar = false;
            this.Text = "Ersetzen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label label1;
        public TextBox textBox1;
        public Button search;
        private Label label2;
        public TextBox textBox2;
        private Button button2;
        public Button replaceall;
        public Button replace;
    }
}