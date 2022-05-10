namespace B04_A01_TextEditorV2
{
    using System.IO;
    using System.Runtime.InteropServices;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            checkOS();
            location();
            zoomfactor();
            encoding();
        }

        #region Variabeln
        int z = 0;
        int c = 0;
        int a = 0;
        int n = 0;
        int p = 0;
        int y = 0;
        bool d = false;
        bool q = false;
        bool k = false;
        bool g = false;
        bool w = false;
        bool bg = false;
        string s = "";
        string dbg = "";
        static int cmp = 0;
        static int tz = 0;
        public static int CMP
        {
            get { return cmp; }
            set { cmp = value; }
        }
        public static int TZ
        {
            get { return tz; }
            set { tz = value; }
        }
        #endregion        

        #region  Eigene Methoden   
        private void speichernUnter()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.DefaultExt = ".txt";
            sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(textBox1.Text);
                sw.Close();
                c = 1;
                s = sfd.FileName;
                a = 0;
            }
        }
        private void speichern(string s)
        {
            FileStream fs = new FileStream(s, FileMode.Open);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(textBox1.Text);
            sw.Close();
            MessageBox.Show("Datei erfolgreich gespeichert unter " + Environment.NewLine + s);
            a = 0;
        }
        private void oeffnen()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName == "")
            {
                MessageBox.Show("Keine Datei ausgewählt");
            }
            else
            {
                if (ofd.FileName == s)
                {
                    MessageBox.Show("Die Datei ist bereits geöffnet");
                }
                else { 
                textBox1.Text = "";
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    textBox1.Text += sr.ReadLine() + Environment.NewLine;
                }
                Text = "TextEditor - " + ofd.FileName;
                s = ofd.FileName;
                a = 0;
                fs.Close();
                }
            }
            encoding();
        }
        private bool warnung()
        {
            var window = MessageBox.Show(
            "Die Datei wurde nicht gespeichert. Jetzt speichern?", "Warnung",
            MessageBoxButtons.YesNoCancel);
            if (window == DialogResult.Yes)
            {
                switch (c)
                {
                    case 0:
                        speichernUnter();
                        break;

                    case 1:
                        speichern(s);
                        break;
                }
                return false;
            }
            else
            {
                if (window == DialogResult.No)
                {
                    return false;
                }
                else { return true; }
            }


        }
        private int getstart(List<int> arr)
        {
            switch (FormProvider.sd.X)
            {
                case 0:
                    if (!k)
                    {
                        int higher = arr.Max();
                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i] > p && arr[i] < higher)
                                higher = arr[i];
                        }
                        var minIndex = Enumerable.Range(1, arr.Count - 1)
                        .Aggregate(0, (seed, index) =>
                         Math.Abs(arr[index] - higher) < Math.Abs(arr[seed] - higher)
                                ? index
                                : seed);
                        n = minIndex - 1;
                        k = true;
                        return n;
                    }
                    break;

                case 1:
                    if (!k)
                    {
                        double lower = arr.Min();
                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i] < p && arr[i] > lower)
                                lower = arr[i];
                        }
                        var minIndex = Enumerable.Range(1, arr.Count - 1)
                        .Aggregate(0, (seed, index) =>
                         Math.Abs(arr[index] - lower) < Math.Abs(arr[seed] - lower)
                                ? index
                                : seed);
                        n = minIndex + 1;
                        k = true;
                        return n;
                    }
                    break;
            }
            return n;

        }
        public void suche()
        {

            List<int> arr = new List<int>();
            
            arr = textBox1.Text.AllIndexesOf(FormProvider.sd.word, !FormProvider.sd.O).ToList();
              
            if (arr.Count == 0)
            {
                FormProvider.sd.TopMost = false;
                MessageBox.Show(FormProvider.sd.word + " kann nicht gefunden werden.", "Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                switch (FormProvider.sd.X)
                {
                    case 0:
                        n = getstart(arr);
                        if (n < arr.Count - 1)
                        {
                            if (FormProvider.sd.L == false && z == 1)
                            {
                                textBox1.SelectionStart = arr[arr.Count - 1];
                                textBox1.SelectionLength = FormProvider.sd.length;
                                textBox1.Focus();
                                n = arr.Count - 1;

                            }
                            else
                            {
                                n += 1;
                                textBox1.SelectionStart = arr[n];
                                textBox1.SelectionLength = FormProvider.sd.length;
                                textBox1.Focus();
                            }
                        }
                        else
                        {
                            if (n == arr.Count - 1)
                            {
                                if (FormProvider.sd.L == true)
                                {
                                    n = 0;
                                    z = 1;
                                }
                                textBox1.SelectionStart = arr[n];
                                textBox1.SelectionLength = FormProvider.sd.length;
                                textBox1.Focus();                              
                                   


                            }
                            else
                            {
                                if (n == arr.Count)
                                {
                                    n -= 1;
                                    textBox1.SelectionStart = arr[n];
                                    textBox1.SelectionLength = FormProvider.sd.length;
                                    textBox1.Focus();

                                }
                            }
                        }
                        break;
                    case 1:
                        n = getstart(arr);
                        if (n <= arr.Count && n > 0)
                        {
                            if (FormProvider.sd.L == false && z == 1)
                            {
                                textBox1.SelectionStart = arr[0];
                                textBox1.SelectionLength = FormProvider.sd.length;
                                textBox1.Focus();
                                n = 0;
                            }
                            else
                            {
                                n -= 1;
                                textBox1.SelectionStart = arr[n];
                                textBox1.SelectionLength = FormProvider.sd.length;
                                textBox1.Focus();
                            }

                        }
                        else
                        {
                            if (n == 0)
                            {
                                if (FormProvider.sd.L)
                                {
                                    n = arr.Count - 1;
                                    z = 1;
                                    
                                }
                                textBox1.SelectionStart = arr[n];
                                textBox1.SelectionLength = FormProvider.sd.length;
                                textBox1.Focus();                                   
                         
                            }
                            else
                            {
                                if (n == -1)
                                {
                                    textBox1.SelectionStart = arr[arr.Count + n];
                                    textBox1.SelectionLength = FormProvider.sd.length;
                                    textBox1.Focus();
                                    n = arr.Count - 1;
                                }
                            }
                        }

                        break;

                }
            }
        }
        private void suchdlg()
        {
            FormProvider.rd.Hide();
            FormProvider.sd.Show();
            FormProvider.sd.textBox1.TextChanged += (object sender, EventArgs e) =>
            {
                g = true;
            };
            FormProvider.sd.search.Click += (object sender, EventArgs e) =>
            {
                if (FormProvider.sd.T)
                {

                    suche();
                    FormProvider.sd.search.Text = "Weitersuchen";
                    FormProvider.sd.T = false;

                }
            };

        }
        private void repldlg()
        {
            FormProvider.sd.Hide();
            FormProvider.rd.Show();
            FormProvider.rd.search.Click += (object sender, EventArgs e) =>
            {
                if (FormProvider.rd.T)
                {

                    replace(false);
                    FormProvider.rd.T = false;

                }
            };
            FormProvider.rd.replace.Click += (object sender, EventArgs e) =>
            {
                if (FormProvider.rd.T)
                {

                    replace(true);
                    FormProvider.rd.T = false;

                }
            };
            FormProvider.rd.replaceall.Click += (object sender, EventArgs e) =>
            {
                if (FormProvider.rd.T)
                {

                    replaceall();
                    FormProvider.rd.T = false;

                }
            };
        }
        private void replace(bool check)
        {
            List<int> arr = new List<int>();
            
            arr = textBox1.Text.AllIndexesOf(FormProvider.sd.word, !FormProvider.sd.O).ToList();                 
            
            if (arr.Count == 0)
            {
                FormProvider.sd.TopMost = false;
                MessageBox.Show(FormProvider.sd.word + " kann nicht gefunden werden.", "Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                if (check == true)
                {
                    n = getstart(arr);
                    if (n < arr.Count)
                    {
                        textBox1.SelectionStart = arr[n];
                        textBox1.SelectionLength = FormProvider.sd.length;
                        textBox1.Focus();
                        textBox1.SelectedText = FormProvider.rd.textBox2.Text;
                    }
                    else
                    {
                        if (n == arr.Count && FormProvider.sd.L)
                        {
                            n = 0;
                            textBox1.SelectionStart = arr[n];
                            textBox1.SelectionLength = FormProvider.sd.length;
                            textBox1.Focus();
                            textBox1.SelectedText = FormProvider.rd.textBox2.Text;
                        }
                    }
                }
                else
                {
                    y = FormProvider.sd.X;
                    FormProvider.sd.X = 0;
                    suche();
                    FormProvider.sd.X = y;
                }
            }
        }
        private void replaceall()
        {
            List<int> arr = new List<int>();
           
            arr = textBox1.Text.AllIndexesOf(FormProvider.sd.word, !FormProvider.sd.O).ToList();
                 
            if (arr.Count == 0)
            {
                FormProvider.sd.TopMost = false;
                MessageBox.Show(FormProvider.sd.word + " kann nicht gefunden werden.", "Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                foreach (int q in arr)
                {
                    textBox1.SelectionStart = q;
                    textBox1.SelectionLength = FormProvider.sd.word.Length;
                    textBox1.SelectedText = FormProvider.rd.textBox2.Text;
                }
            }
        }
        private void checkOS()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                osStatus.Text = "Linux (LF)";
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                osStatus.Text = "Mac OSX (LF)";
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                osStatus.Text = "Windows (CRLF)";
            }
        }
        private void location()
        {
            int zeile = textBox1.GetLineFromCharIndex(this.textBox1.SelectionStart);
            int spalte = textBox1.SelectionStart - textBox1.GetFirstCharIndexFromLine(zeile);
            locationstatus.Text = "Zeile " + (zeile+1) + ", Spalte " + (spalte+1);

        }
        private void zoomfactor()
        {
            float x = MathF.Round(textBox1.ZoomFactor,1) * 100;
            zoomStatus.Text = (int)x + "%";
        }
        private void encoding()
        {
            if (s != "")
            {
                StreamReader sr = new StreamReader(s,true);
                encodingStatus.Text = sr.CurrentEncoding.ToString();
            }
            else
            {
                encodingStatus.Text = "UTF-8";
            }
        }
        private void loeschen()
        {
            int delete = textBox1.SelectionLength;
            if (delete == 0)
            {
                delete = 1;
            }
            int i = textBox1.SelectionStart;
            textBox1.Text = textBox1.Text.Remove(textBox1.SelectionStart, delete);
            textBox1.SelectionStart = i;
        }
        #endregion

        #region Header Datei
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            a = 1;            
            location();
            bool enabled = textBox1.Text != "";
            suchenToolStripMenuItem.Enabled = enabled;
            weitersuchenToolStripMenuItem.Enabled = enabled;
            ersetzenToolStripMenuItem.Enabled = enabled;
            vorherigeSuchenToolStripMenuItem.Enabled = enabled;

        }
        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (a != 1 || !warnung() )
            {               
                    oeffnen();
                    a = 0;               
            }            
        }
        private void speichernUnterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            speichernUnter();
        }
        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (c)
            {
                case 0:
                    speichernUnter();
                    break;

                case 1:
                    speichern(s);
                    break;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (a == 1 && warnung())
            {                
                e.Cancel = true;                
            }
        }
        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Text = "TextEditor";
            c = 0;
            a = 0;
            encoding();
        }
        private void neuesFensterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
        }
        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox1.Text, textBox1.Font, Brushes.Black, new Point(10, 10));
        }
        private void seiteEinrichtenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDoc.DocumentName = s;
            PageSetupDialog psd = new PageSetupDialog();
            psd.Document = printDoc;
            psd.AllowPaper = true;
            psd.AllowOrientation = true;
            psd.AllowMargins = true;
            if (psd.ShowDialog() == DialogResult.OK)
            {
                printDoc.DefaultPageSettings = psd.PageSettings;
                printDoc.PrinterSettings = psd.PrinterSettings;
            }

        }
        private void druckenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();

            if (pd.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }
        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (c == 0 || (c == 1 && !warnung()))
            {
                Close();
            }
        }
        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (bg)
            {
                case false:
                    dbg = textBox1.Text;
                    textBox1.Text = "⠀    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀     ⠀⠀⠀⠀    ⣀⣤⣴⣶⣶⣶⣦⣤⣀" + Environment.NewLine + "                                                                ⢀⣴⣿⣿⡿⠟⠋⠙⠻⢿⣿⣿⣦⡀" + Environment.NewLine + "                                                             ⣰⣿⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠉⠻⣿⣿⣆" + Environment.NewLine + "                                                          ⣸⣿⣿⠃⠀⠀⠀⠀⠀⣠⣤⣤⣄⠀⠀   ⠘⣿⣿⣆⣀⣀⣀⣀⣀⣀⡀" + Environment.NewLine + "    ⠀                                                ⢠⣿⣿⠇⠀⠀⠀⠀⠀⠀ ⣿⣿⣿⣿⠀⠀⠀   ⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿" + Environment.NewLine + "                ⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⠀⠀⠀⠀⠀⠀  ⠀⠈⠙⠋⠁⠀⠀⠀⠀   ⣿⣿⣿⣿⣿⣿⣿⣿⣿" + Environment.NewLine + "           ⢀⣾⣿⣿⣷⣦⣄⠀⠀⠀⠀⠀⠀⠀    ⢸⣿⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⡟" + Environment.NewLine + "        ⣠⣿⣿⠟⠉⠛⢿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀ ⢿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⠀⣼⣿⣿⣿⣿⣿⣿⣿⠟" + Environment.NewLine + "     ⣰⣿⣿⠋⠀⠀⠀⠀⠀⠙⢿⣿⣷⣄⠀⠀⠀⠀⠀ ⠘⢿⣿⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⣿⣿⣿⣿⠿⠿⠋⠁" + Environment.NewLine + " ⢠⣿⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀ ⠹⣿⣿⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⡅" + Environment.NewLine + "⣼⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀  ⠈⠛⠛⠉⠉⠉⠉⠉⠉⠉⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⡀" + Environment.NewLine + "⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀       ⣿⣿⡇" + Environment.NewLine + "⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀       ⢸⣿⣿" + Environment.NewLine + "⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀        ⢸⣿⣿" + Environment.NewLine + "⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀        ⢸⣿⣿" + Environment.NewLine + "⢻⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀     ⠀   ⣼⣿⡟" + Environment.NewLine + " ⠘⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀       ⢠⣿⣿" + Environment.NewLine + "     ⢹⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⢠⣿⣿⡏" + Environment.NewLine + "        ⠻⣿⣿⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⢠⣿⣿⡟" + Environment.NewLine + "           ⠙⢿⣿⣿⣷⣦⣤⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀    ⣀⣠⣤⣶⣿⣿⠋" + Environment.NewLine + "                ⠈⠙⠛⠿⢿⣿⣿⣿⣶⣶⣤⣤⣤⣤⣄⣀⣀⣀⣤⣤⣤⣤⣴⣶⣾⣿⣿⣿⠿⠟⠋ " + Environment.NewLine + "                                  ⠉⠉⠛⠛⠻⠿⠿⠿⢿⣿⣿⡿⠿⠿⠿⠿⠛⠛⠋⠉";
                    bg = !bg;
                    debugToolStripMenuItem.Checked = bg;
                    break;
                case true:
                    textBox1.Text = dbg;
                    bg = !bg;
                    debugToolStripMenuItem.Checked = bg;
                    break;

            }
        }

        #endregion

        #region Header Bearbeiten        
        private void textBox1_SelectionChanged(object sender, EventArgs e)
        {
            bool enabled = textBox1.SelectedText.Length > 0;
                   
                ausschneidenToolStripMenuItem.Enabled = enabled;
                kopierenToolStripMenuItem.Enabled = enabled;                
                löschenToolStripMenuItem.Enabled = enabled;       
                ausschneidenToolStripMenuItem1.Enabled = enabled;
                kopierenToolStripMenuItem1.Enabled = enabled;                
                löschenToolStripMenuItem1.Enabled = enabled;           
                
        }
        private void rückgängigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }
        private void allesMarkierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }
        private void ausschneidenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }
        private void kopierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }
        private void einfügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }
        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loeschen();         
        }
        private void suchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            suchdlg();
        }
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            p = textBox1.SelectionStart;
        }
        private void weitersuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (g)
            {
                FormProvider.sd.X = 0;
                suche();
            }
            else
            {
                suchdlg();
            }
        }
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                k = false;
                p = textBox1.SelectionStart;
                location();
            }
            else if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
        private void vorherigeSuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (g == true)
            {
                FormProvider.sd.X = 1;
                suche();
            }
            else
            {
                suchdlg();
            }
        }
        private void ersetzenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repldlg();
        }
        private void wechselnSieZuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeLine cl = new changeLine();
            tz = textBox1.GetLineFromCharIndex(this.textBox1.SelectionStart) + 1;
            cl.textBox1.Text = tz.ToString();
            cmp = textBox1.Lines.Count() + 1;
            cl.ShowDialog();

            if (cl.DialogResult == DialogResult.OK)
            {
                textBox1.HideSelection = false;
                textBox1.SelectionStart = textBox1.GetFirstCharIndexFromLine(int.Parse(cl.textBox1.Text) - 1);
                textBox1.ScrollToCaret();
                location();

            }


        }
        private void datumUhrzeitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectionLength = 0;
            textBox1.SelectedText = DateTime.Now.ToString();
        }
        #endregion

        #region Header Format
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = false;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
        }

        private void zeilenumbruchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.WordWrap = !q;
            zeilenumbruchToolStripMenuItem.Checked = !q;
            q = !q;
        }
        #endregion

        #region Header Ansicht
        private void vergrößernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.ZoomFactor < (float)5)
                textBox1.ZoomFactor = textBox1.ZoomFactor + MathF.Round((float)0.1, 1);
            zoomfactor();
        }
        private void verkleinernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.ZoomFactor > (float)0.15)
                textBox1.ZoomFactor = textBox1.ZoomFactor - MathF.Round((float)0.1, 1); ;
            zoomfactor();
        }
        private void standardWiederherstellenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ZoomFactor = 1;
            zoomfactor();
        }
        private void statusleisteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusleisteToolStripMenuItem.Checked = w;
            statusStrip1.Visible = w;
            w = !w;
        }
        #endregion

        #region Rechtsklickmenu
        private void rückgängigToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void allesAuswählenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void ausschneidenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void kopierenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void einfügenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void löschenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            loeschen();
        }

        private void rechtsnachlinksLesefolgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!d)
            {
                textBox1.RightToLeft = RightToLeft.Yes;
                
            }
            else
            {
                textBox1.RightToLeft = RightToLeft.No;
                
            }
            rechtsnachlinksLesefolgeToolStripMenuItem.Checked = !d;
            d = !d;
        }

        #endregion
       
    }
}