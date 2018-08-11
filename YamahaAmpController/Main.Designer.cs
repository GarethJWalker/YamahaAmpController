namespace YamahaAmpController
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.IncreaseVolume = new System.Windows.Forms.Button();
            this.DecreaseVolume = new System.Windows.Forms.Button();
            this.PlayPause = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DecreaseVolume2 = new System.Windows.Forms.Button();
            this.IncreaseVolume2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Mute = new System.Windows.Forms.Button();
            this.Mute2 = new System.Windows.Forms.Button();
            this.Volume1 = new System.Windows.Forms.Label();
            this.Volume2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Artist";
            this.label1.UseMnemonic = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title";
            this.label2.UseMnemonic = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Album";
            this.label3.UseMnemonic = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-1, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 194);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // IncreaseVolume
            // 
            this.IncreaseVolume.Image = global::YamahaAmpController.Properties.Resources.speaker_volume_control_up;
            this.IncreaseVolume.Location = new System.Drawing.Point(174, 287);
            this.IncreaseVolume.Name = "IncreaseVolume";
            this.IncreaseVolume.Size = new System.Drawing.Size(32, 28);
            this.IncreaseVolume.TabIndex = 5;
            this.IncreaseVolume.Text = "+";
            this.IncreaseVolume.UseVisualStyleBackColor = true;
            this.IncreaseVolume.Click += new System.EventHandler(this.button1_Click);
            // 
            // DecreaseVolume
            // 
            this.DecreaseVolume.Image = global::YamahaAmpController.Properties.Resources.speaker_volume_control;
            this.DecreaseVolume.Location = new System.Drawing.Point(144, 287);
            this.DecreaseVolume.Name = "DecreaseVolume";
            this.DecreaseVolume.Size = new System.Drawing.Size(32, 28);
            this.DecreaseVolume.TabIndex = 6;
            this.DecreaseVolume.Text = "-";
            this.DecreaseVolume.UseVisualStyleBackColor = true;
            this.DecreaseVolume.Click += new System.EventHandler(this.button2_Click);
            // 
            // PlayPause
            // 
            this.PlayPause.Location = new System.Drawing.Point(173, 253);
            this.PlayPause.Name = "PlayPause";
            this.PlayPause.Size = new System.Drawing.Size(32, 28);
            this.PlayPause.TabIndex = 7;
            this.PlayPause.Text = ">";
            this.PlayPause.UseVisualStyleBackColor = true;
            this.PlayPause.Click += new System.EventHandler(this.PlayPause_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // DecreaseVolume2
            // 
            this.DecreaseVolume2.Image = global::YamahaAmpController.Properties.Resources.speaker_volume_control;
            this.DecreaseVolume2.Location = new System.Drawing.Point(144, 312);
            this.DecreaseVolume2.Name = "DecreaseVolume2";
            this.DecreaseVolume2.Size = new System.Drawing.Size(32, 28);
            this.DecreaseVolume2.TabIndex = 8;
            this.DecreaseVolume2.Text = "-";
            this.DecreaseVolume2.UseVisualStyleBackColor = true;
            this.DecreaseVolume2.Click += new System.EventHandler(this.DecreaseVolume2_Click);
            // 
            // IncreaseVolume2
            // 
            this.IncreaseVolume2.Image = global::YamahaAmpController.Properties.Resources.speaker_volume_control_up;
            this.IncreaseVolume2.Location = new System.Drawing.Point(174, 312);
            this.IncreaseVolume2.Name = "IncreaseVolume2";
            this.IncreaseVolume2.Size = new System.Drawing.Size(32, 28);
            this.IncreaseVolume2.TabIndex = 9;
            this.IncreaseVolume2.Text = "+";
            this.IncreaseVolume2.UseVisualStyleBackColor = true;
            this.IncreaseVolume2.Click += new System.EventHandler(this.IncreaseVolume2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Zone A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Zone B";
            // 
            // Mute
            // 
            this.Mute.Image = global::YamahaAmpController.Properties.Resources.speaker_volume;
            this.Mute.Location = new System.Drawing.Point(113, 287);
            this.Mute.Name = "Mute";
            this.Mute.Size = new System.Drawing.Size(32, 28);
            this.Mute.TabIndex = 12;
            this.Mute.UseVisualStyleBackColor = true;
            this.Mute.Click += new System.EventHandler(this.Mute_Click);
            // 
            // Mute2
            // 
            this.Mute2.Image = global::YamahaAmpController.Properties.Resources.speaker_volume_control_mute;
            this.Mute2.Location = new System.Drawing.Point(113, 312);
            this.Mute2.Name = "Mute2";
            this.Mute2.Size = new System.Drawing.Size(32, 28);
            this.Mute2.TabIndex = 13;
            this.Mute2.UseVisualStyleBackColor = true;
            this.Mute2.Click += new System.EventHandler(this.Mute2_Click);
            // 
            // Volume1
            // 
            this.Volume1.AutoSize = true;
            this.Volume1.Location = new System.Drawing.Point(55, 295);
            this.Volume1.Name = "Volume1";
            this.Volume1.Size = new System.Drawing.Size(10, 13);
            this.Volume1.TabIndex = 14;
            this.Volume1.Text = " ";
            // 
            // Volume2
            // 
            this.Volume2.AutoSize = true;
            this.Volume2.Location = new System.Drawing.Point(54, 320);
            this.Volume2.Name = "Volume2";
            this.Volume2.Size = new System.Drawing.Size(10, 13);
            this.Volume2.TabIndex = 15;
            this.Volume2.Text = " ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 28);
            this.button1.TabIndex = 16;
            this.button1.Text = "History";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(204, 336);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Volume2);
            this.Controls.Add(this.Volume1);
            this.Controls.Add(this.Mute2);
            this.Controls.Add(this.Mute);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IncreaseVolume2);
            this.Controls.Add(this.DecreaseVolume2);
            this.Controls.Add(this.PlayPause);
            this.Controls.Add(this.DecreaseVolume);
            this.Controls.Add(this.IncreaseVolume);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Now Playing...";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button IncreaseVolume;
        private System.Windows.Forms.Button DecreaseVolume;
        private System.Windows.Forms.Button PlayPause;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button DecreaseVolume2;
        private System.Windows.Forms.Button IncreaseVolume2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Mute;
        private System.Windows.Forms.Button Mute2;
        private System.Windows.Forms.Label Volume1;
        private System.Windows.Forms.Label Volume2;
        private System.Windows.Forms.Button button1;
    }
}

