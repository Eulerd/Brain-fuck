using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                if(BfText[i] >= 10) Chars.Text += (char)BfText[i] + " ";
                else Chars.Text += BfText[i] + " ";
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
            

            int l = textBox1.Text.Length;
            int ptr = 0;
            int count = 0;
            string[] Inputs = InPutBox.Text.Split(' ');


            for(int i = 0;i < l; i++)
            {
                char ch = textBox1.Text[i];
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
                            i = textBox1.Text.IndexOf(']', ptr);
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
    }
}
