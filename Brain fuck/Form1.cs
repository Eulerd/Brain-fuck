using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Brain_fuck
{
    public partial class Form1 : Form
    {
        private List<byte> BfText = new List<byte>();
        private bool fkon;
        private bool fkoff;
        private bool stop = false;
        private int SleepTime;
        private int ptr;

        public Form1()
        {
            InitializeComponent();
        }

        private void CurrentState()
        {
            Chars.Text = "";
            for (int i = 0; i < BfText.Count; i++)
            {
                if (i == ptr) Chars.Text += "[";

                if (BfText[i] < 10) Chars.Text += "00" + BfText[i];
                else if (BfText[i] < 100) Chars.Text += "0" + BfText[i];
                else Chars.Text += BfText[i];

                if (i == ptr) Chars.Text += "]";

                Chars.Text += " ";
            }
            Chars.Refresh();
            Application.DoEvents();
        }

        private void Resetting()
        {
            BfText.Clear();
            BfText.Add(0);
            OutPutBox.Text = "";
            ptr = 0;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Text = "Now F*cking";
            Stopbutton.Enabled = true;
            Resetting();
            CurrentState();
            

            int l = CodeBox.Text.Length;
            int count = 0;
            string[] Inputs = InPutBox.Text.Split(' ');


            for(int i = 0;i < l; i++)
            {
                if (stop) break;
                char ch = CodeBox.Text[i];
                switch (ch)
                {
                    case '+':
                        BfText[ptr]++;
                        break;
                    case '-':
                        BfText[ptr]--;
                        break;
                    case '>':
                        if(BfText.Count - 1 <= ptr)BfText.Add(0);
                        ptr++;
                        break;
                    case '<':
                        ptr--;
                        break;
                    case '.':
                        OutPutBox.Text += (char)BfText[ptr];
                        OutPutBox.Refresh();
                        break;
                    case ',':
                        break;
                    case '[':
                        if (BfText[ptr] == 0)
                            i = CodeBox.Text.IndexOf(']', ptr);
                        else
                            count = i;
                        break;
                    case ']':
                        if (BfText[ptr] != 0)
                            i = count;
                        break;
                    default:
                        break;
                }
                if(!fkon) CurrentState();
                if (fkoff) Thread.Sleep(SleepTime);
            }
            if(fkon) CurrentState();
            OutPutBox.Text += "\r\n---Dice is great.---";

            button1.Text = "Brain F*ck";
            stop = false;
            button1.Enabled = true;
            Stopbutton.Enabled = false;
        }

        private void OpentextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                DefaultExt = "*.txt",
                Filter = "テキストファイル|*.txt|すべてのファイル|*.*",
                Title = "フ*ッキンテキストを開く",
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(dialog.FileName);
                CodeBox.Text = file.ReadToEnd();
            }
            else MessageBox.Show("テキストの読み取りに失敗しました。");
        }

        private void helloWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show
                ("コードを上書きしますか?","確認",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            if(result == DialogResult.Yes)
            {
                StreamReader file = new StreamReader("./Hw!_BF.txt");
                CodeBox.Text = file.ReadToEnd();
            }
        }

        private void SaveTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                DefaultExt = "*.txt",
                Filter = "テキストファイル|*.txt|すべてのファイル|*.*",
                Title = "フ*ッキンテキストを保存",
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = 
                    new StreamWriter(dialog.FileName, false, Encoding.GetEncoding("UTF-8"));

                writer.WriteLine(CodeBox.Text);
            }
            else MessageBox.Show("テキストの書き込みに失敗しました。");
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            fkon = FastcheckBox.Checked;
            SlowcheckBox.Enabled = !FastcheckBox.Checked;
        }

        private void SlowcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool check = SlowcheckBox.Checked;
            fkoff = check;
            trackBar1.Enabled = check;
            TrackValLabel.Text = trackBar1.Value.ToString();
            FastcheckBox.Enabled = !check;
        }
    
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            SleepTime = trackBar1.Value;
            TrackValLabel.Text = trackBar1.Value.ToString();
        }

        private void Stopbutton_Click(object sender, EventArgs e)
        {
            stop = true;
        }
    }
}
