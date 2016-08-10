using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Brain_fuck
{
    public partial class Form1 : Form
    {
        private byte[] BfText = new byte[1000];
        private bool fkon;

        public Form1()
        {
            InitializeComponent();
        }

        private void CurrentState()
        {
            Chars.Text = "";
            for (int i = 0; i < 100; i++)
            {
                if (BfText[i] < 10) Chars.Text += "00" + BfText[i];
                else if (BfText[i] < 100) Chars.Text += "0" + BfText[i];
                else Chars.Text += BfText[i];
                Chars.Text += " ";
            }
            Chars.Refresh();
            Application.DoEvents();
        }

        private void Resetting()
        {
            for (int i = 0; i < 100; i++)
                BfText[i] = 0;
            OutPutBox.Text = "";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Resetting();
            CurrentState();
            

            int l = CodeBox.Text.Length;
            int ptr = 0;
            int count = 0;
            string[] Inputs = InPutBox.Text.Split(' ');


            for(int i = 0;i < l; i++)
            {
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
            }
            if(fkon) CurrentState();
            OutPutBox.Text += "\r\n---Dice is great.---";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            fkon = checkBox1.Checked;
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
    }
}
