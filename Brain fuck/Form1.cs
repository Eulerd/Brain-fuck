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
        private BrainF_ck brainF_ck;
        
        /// <summary>
        /// 停止
        /// </summary>
        private bool stop = false;

        /// <summary>
        /// ステップ毎待ち時間
        /// </summary>
        private int SleepTime;
        
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// メモリ状態を更新する
        /// </summary>
        private void UpdateMemoryState()
        {
            Chars.Text = brainF_ck.GetMemoryState();
            Chars.Refresh();
            Application.DoEvents();
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

            try
            {
                brainF_ck = new BrainF_ck(code: CodeBox.Text, inputs: InPutBox.Text);

                UpdateMemoryState();
                OutPutBox.Text = "";

                while (!brainF_ck.IsEnded)
                {
                    brainF_ck.NextStep();


                    if (brainF_ck.IsOutputUpdate)
                    {
                        OutPutBox.Text += brainF_ck.OutputData;
                        OutPutBox.Refresh();
                    }

                    if (!FastcheckBox.Checked)
                        UpdateMemoryState();

                    if (SlowcheckBox.Checked)
                        Thread.Sleep(SleepTime);

                    if (stop)
                        break;
                }

                if (FastcheckBox.Checked)
                    UpdateMemoryState();
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
            }
            catch (OutOfMemoryException exc)
            {
                MessageBox.Show(exc.Message);
            }

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
            SlowcheckBox.Enabled = !FastcheckBox.Checked;
        }

        /// <summary>
        /// ステップ毎に待つかどうか設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SlowcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool slowCheck = SlowcheckBox.Checked;
            trackBar1.Enabled = slowCheck;
            TrackValLabel.Text = trackBar1.Value.ToString();
            FastcheckBox.Enabled = !slowCheck;
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
