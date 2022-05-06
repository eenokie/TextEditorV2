using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B04_A01_TextEditorV2
{
    public partial class replaceDialog : Form
    {
        public replaceDialog()
        {
            InitializeComponent();        
        }
        bool t = false;
        public bool T
        {
            get { return t; }
            set { t = value; }
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        private void abbr_Click(object sender, EventArgs e)
        {
            FormProvider.sd.
            Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FormProvider.sd.word = textBox1.Text;
            FormProvider.sd.length = textBox1.Text.Length;
            FormProvider.sd.textBox1.Text = textBox1.Text;
            if (textBox1.Text != "")
            {
                search.Enabled = true;
                replace.Enabled = true;
                replaceall.Enabled = true;
            }
            else
            {
                search.Enabled = false;
                replace.Enabled = false;
                replaceall.Enabled = false;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                FormProvider.sd.O = true;

            else
                FormProvider.sd.O = false;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                FormProvider.sd.L = true;
            else
                FormProvider.sd.L = false;
        }      
        private void search_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                t = true;
        }
        private void replace_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                t = true;
        }
        private void replaceall_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                t = true;
        }
    }
}
