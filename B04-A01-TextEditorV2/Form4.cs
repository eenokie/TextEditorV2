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
    public partial class changeLine : Form
    {
        public changeLine()
        {
            InitializeComponent();
        }
             
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) < Form1.CMP)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                var window = MessageBox.Show(
                "Die Zeilennummer ist größer als die Gesamtzahl der Zeilen.", "Fehler",
                MessageBoxButtons.OK);
                if (window == DialogResult.OK)
                {
                    textBox1.Text = Form1.TZ.ToString();
                }                  

                DialogResult = DialogResult.None;                 
            }
        }
    }
}
