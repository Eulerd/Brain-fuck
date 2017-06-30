namespace Brain_fuck
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.CodeBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.InPutBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OutPutBox = new System.Windows.Forms.TextBox();
            this.Chars = new System.Windows.Forms.TextBox();
            this.FastcheckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpentextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helloWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SlowcheckBox = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.TrackValLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Stopbutton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // CodeBox
            // 
            this.CodeBox.Location = new System.Drawing.Point(12, 176);
            this.CodeBox.Multiline = true;
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.Size = new System.Drawing.Size(260, 160);
            this.CodeBox.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 113);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(133, 45);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Brain F*ck";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // InPutBox
            // 
            this.InPutBox.Location = new System.Drawing.Point(284, 196);
            this.InPutBox.Multiline = true;
            this.InPutBox.Name = "InPutBox";
            this.InPutBox.Size = new System.Drawing.Size(243, 61);
            this.InPutBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "BrainF*ck";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "InPut";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "OutPut";
            // 
            // OutPutBox
            // 
            this.OutPutBox.Location = new System.Drawing.Point(284, 275);
            this.OutPutBox.Multiline = true;
            this.OutPutBox.Name = "OutPutBox";
            this.OutPutBox.ReadOnly = true;
            this.OutPutBox.Size = new System.Drawing.Size(243, 61);
            this.OutPutBox.TabIndex = 7;
            // 
            // Chars
            // 
            this.Chars.Location = new System.Drawing.Point(12, 27);
            this.Chars.Multiline = true;
            this.Chars.Name = "Chars";
            this.Chars.ReadOnly = true;
            this.Chars.Size = new System.Drawing.Size(515, 76);
            this.Chars.TabIndex = 8;
            // 
            // FastcheckBox
            // 
            this.FastcheckBox.AutoSize = true;
            this.FastcheckBox.Location = new System.Drawing.Point(284, 113);
            this.FastcheckBox.Name = "FastcheckBox";
            this.FastcheckBox.Size = new System.Drawing.Size(70, 16);
            this.FastcheckBox.TabIndex = 9;
            this.FastcheckBox.Text = "F*cking!!";
            this.FastcheckBox.UseVisualStyleBackColor = true;
            this.FastcheckBox.CheckedChanged += new System.EventHandler(this.FastCheckBox_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpentextToolStripMenuItem,
            this.SaveTextToolStripMenuItem,
            this.helloWorldToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(539, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OpentextToolStripMenuItem
            // 
            this.OpentextToolStripMenuItem.Name = "OpentextToolStripMenuItem";
            this.OpentextToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpentextToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.OpentextToolStripMenuItem.Text = "テキストを開く";
            this.OpentextToolStripMenuItem.Click += new System.EventHandler(this.OpentextToolStripMenuItem_Click);
            // 
            // SaveTextToolStripMenuItem
            // 
            this.SaveTextToolStripMenuItem.Name = "SaveTextToolStripMenuItem";
            this.SaveTextToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.SaveTextToolStripMenuItem.Text = "テキストに保存";
            this.SaveTextToolStripMenuItem.Click += new System.EventHandler(this.SaveTextToolStripMenuItem_Click);
            // 
            // helloWorldToolStripMenuItem
            // 
            this.helloWorldToolStripMenuItem.Name = "helloWorldToolStripMenuItem";
            this.helloWorldToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.helloWorldToolStripMenuItem.Text = "Hello, world!";
            this.helloWorldToolStripMenuItem.Click += new System.EventHandler(this.helloWorldToolStripMenuItem_Click);
            // 
            // SlowcheckBox
            // 
            this.SlowcheckBox.AutoSize = true;
            this.SlowcheckBox.Location = new System.Drawing.Point(360, 113);
            this.SlowcheckBox.Name = "SlowcheckBox";
            this.SlowcheckBox.Size = new System.Drawing.Size(57, 16);
            this.SlowcheckBox.TabIndex = 11;
            this.SlowcheckBox.Text = "Slowly";
            this.SlowcheckBox.UseVisualStyleBackColor = true;
            this.SlowcheckBox.CheckedChanged += new System.EventHandler(this.SlowcheckBox_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Enabled = false;
            this.trackBar1.LargeChange = 100;
            this.trackBar1.Location = new System.Drawing.Point(423, 121);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.SmallChange = 10;
            this.trackBar1.TabIndex = 10;
            this.trackBar1.TickFrequency = 100;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // TrackValLabel
            // 
            this.TrackValLabel.AutoSize = true;
            this.TrackValLabel.Location = new System.Drawing.Point(498, 106);
            this.TrackValLabel.Name = "TrackValLabel";
            this.TrackValLabel.Size = new System.Drawing.Size(0, 12);
            this.TrackValLabel.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(428, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "SleepValue :";
            // 
            // Stopbutton
            // 
            this.Stopbutton.Enabled = false;
            this.Stopbutton.Location = new System.Drawing.Point(151, 113);
            this.Stopbutton.Name = "Stopbutton";
            this.Stopbutton.Size = new System.Drawing.Size(75, 23);
            this.Stopbutton.TabIndex = 14;
            this.Stopbutton.Text = "Stop";
            this.Stopbutton.UseVisualStyleBackColor = true;
            this.Stopbutton.Click += new System.EventHandler(this.Stopbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 348);
            this.Controls.Add(this.Stopbutton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TrackValLabel);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.SlowcheckBox);
            this.Controls.Add(this.FastcheckBox);
            this.Controls.Add(this.Chars);
            this.Controls.Add(this.OutPutBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InPutBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.CodeBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "BF";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CodeBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox InPutBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OutPutBox;
        private System.Windows.Forms.TextBox Chars;
        private System.Windows.Forms.CheckBox FastcheckBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpentextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helloWorldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveTextToolStripMenuItem;
        private System.Windows.Forms.CheckBox SlowcheckBox;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label TrackValLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Stopbutton;
    }
}

