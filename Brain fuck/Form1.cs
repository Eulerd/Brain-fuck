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
        /// <summary>
        /// BF用仮想メモリ
        /// </summary>
        private List<byte> BfMemory = new List<byte>();

        /// <summary>
        /// メモリ状態を表示せずに速度上げるかどうか
        /// </summary>
        private bool fkon;

        /// <summary>
        /// 一ステップ毎に待つかどうか
        /// </summary>
        private bool fkoff;

        /// <summary>
        /// 停止
        /// </summary>
        private bool stop = false;

        /// <summary>
        /// ステップ毎待ち時間
        /// </summary>
        private int SleepTime;

        /// <summary>
        /// Bfメモリポインタ
        /// </summary>
        private int ptr;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// メモリ状態を更新する
        /// </summary>
        private void UpdateMemoryState()
        {
            Chars.Text = "";
            for (int i = 0; i < BfMemory.Count; i++)
            {
                if (i == ptr) Chars.Text += "[";

                if (BfMemory[i] < 10) Chars.Text += "00" + BfMemory[i];
                else if (BfMemory[i] < 100) Chars.Text += "0" + BfMemory[i];
                else Chars.Text += BfMemory[i];

                if (i == ptr) Chars.Text += "]";

                Chars.Text += " ";
            }
            Chars.Refresh();
            Application.DoEvents();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Resetting()
        {
            BfMemory.Clear();
            BfMemory.Add(0);
            OutPutBox.Text = "";
            ptr = 0;
        }
        
        /// <summary>
        /// Bfを実行する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            startButton.Text = "Now F*cking";
            Stopbutton.Enabled = true;
            Resetting();
            UpdateMemoryState();

            int l = CodeBox.Text.Length;
            int count = 0;
            string[] Inputs = InPutBox.Text.Split(' ', '\n');


            for(int i = 0;i < l; i++)
            {
                if (stop) break;
                char ch = CodeBox.Text[i];
                switch (ch)
                {
                    case '+':
                        BfMemory[ptr]++;
                        break;
                    case '-':
                        BfMemory[ptr]--;
                        break;
                    case '>':
                        if(BfMemory.Count - 1 <= ptr)BfMemory.Add(0);
                        ptr++;
                        break;
                    case '<':
                        ptr--;
                        break;
                    case '.':
                        OutPutBox.Text += (char)BfMemory[ptr];
                        OutPutBox.Refresh();
                        break;
                    case ',':
                        break;
                    case '[':
                        if (BfMemory[ptr] == 0)
                            i = CodeBox.Text.IndexOf(']', ptr);
                        else
                            count = i;
                        break;
                    case ']':
                        if (BfMemory[ptr] != 0)
                            i = count;
                        break;
                    default:
                        break;
                }
                if(!fkon) UpdateMemoryState();
                if (fkoff) Thread.Sleep(SleepTime);
            }
            if(fkon) UpdateMemoryState();
            OutPutBox.Text += "\r\n---Dice is great.---";

            startButton.Text = "Brain F*ck";
            stop = false;
            startButton.Enabled = true;
            Stopbutton.Enabled = false;
        }

        /// <summary>
        /// ファイル入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpentextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                DefaultExt = "*.txt",
                Filter = "テキストファイル|*.txt|すべてのファイル|*.*",
                Title = "フ*ッキンテキストを開く",
            };

            switch (dialog.ShowDialog())
            {
                case DialogResult.OK:
                    StreamReader file = new StreamReader(dialog.FileName);
                    CodeBox.Text = file.ReadToEnd();
                    break;
                case DialogResult.Cancel:
                    break;

                default:
                    MessageBox.Show("テキストの読み取りに失敗しました。");
                    break;
            }
        }

        /// <summary>
        /// Hello,worldサンプルテキストを入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helloWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show
                ("コードを上書きしますか?","確認",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            switch (result)
            {
                case DialogResult.Yes:
                    string fileName = "./Hw!_BF.txt";
                    try
                    {
                        StreamReader file = new StreamReader(fileName);
                        CodeBox.Text = file.ReadToEnd();
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("Hw!_BF.txtが見つかりません");
                    }
                    break;

                case DialogResult.No:
                case DialogResult.Cancel:
                    break;
            }
        }

        /// <summary>
        /// コードを保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                DefaultExt = "*.txt",
                Filter = "テキストファイル|*.txt|すべてのファイル|*.*",
                Title = "フ*ッキンテキストを保存",
            };

            switch (dialog.ShowDialog())
            {
                case DialogResult.OK:
                    try
                    {
                        StreamWriter writer = 
                            new StreamWriter(dialog.FileName, false, Encoding.GetEncoding("UTF-8"));

                        writer.WriteLine(CodeBox.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("テキストの書き込みに失敗しました。");
                    }
                    break;

                case DialogResult.Cancel:
                    break;
            }
        }

        /// <summary>
        /// メモリ状態を表示するかどうか設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FastCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            fkon = FastcheckBox.Checked;
            SlowcheckBox.Enabled = !FastcheckBox.Checked;
        }

        /// <summary>
        /// ステップ毎に待つかどうか設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SlowcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool check = SlowcheckBox.Checked;
            fkoff = check;
            trackBar1.Enabled = check;
            TrackValLabel.Text = trackBar1.Value.ToString();
            FastcheckBox.Enabled = !check;
        }
    
        /// <summary>
        /// ステップ毎待ち時間を設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            SleepTime = trackBar1.Value;
            TrackValLabel.Text = trackBar1.Value.ToString();
        }

        /// <summary>
        /// 停止の設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stopbutton_Click(object sender, EventArgs e)
        {
            stop = true;
        }
    }
}
