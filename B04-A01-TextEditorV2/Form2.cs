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
    public partial class suchDialog : Form
    {
        public suchDialog()
        {
            InitializeComponent();
        }        
        public int x = 0;
        public int i = 0;
        public bool o = false;
        public bool l = false;
        public string s = "";
        public bool h = false;
        public bool t = false;
        public bool m = false;
        public string word
        {
            get { return s; }
            set { s = value; }
        }
        public int length
        {
            get { return i; }
            set { i = value; }
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        } 
        public bool O
        {
            get { return o; }
            set { o = value; }
        }
        public bool L
        {
            get { return l; }
            set { l = value; }
        }       
        public bool T
        {
            get { return t; }
            set { t = value; }
        }       
                
        private void suchDialog_FormClosing(object sender, FormClosingEventArgs e)
        {              
            e.Cancel = true;
            this.Hide();            
        }        
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked)
            {
                x = 0;                 
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                x = 1;
                
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s = textBox1.Text;
            i = textBox1.Text.Length;
            FormProvider.rd.textBox1.Text = s;
            if (textBox1.Text !="")
            search.Enabled = true;

            else
            search.Enabled = false;   
                    
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked)            
            o = true;
            
            else  
            o = false; 
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox2.Checked)
                l = true;
            else
                l = false;
        }
        private void abbr_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void search_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                t = true;
        }
    }
}
