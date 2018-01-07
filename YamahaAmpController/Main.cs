﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static YamahaAmpController.Program;

namespace YamahaAmpController
{
    public partial class Main : Form
    {
        private string currentTitle;
        private string currentArtUrl;
        public List<Tuple<DateTime,NowPlayingInfo>> History { get; set; }
        public string CurrentStatus { get; private set; }

        private YamahaReceiver Amp = new YamahaReceiver();

        public Main()
        {
            InitializeComponent();
            this.Focus();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
            History = new List<Tuple<DateTime,NowPlayingInfo>>();
            this.label1.Text = "";
            this.label2.Text = "";
            this.label3.Text = "";
            GetCurrent();
            timer1.Start();


        }

        private void GetCurrent()
        {

            var np = Amp.NowPlaying();

            this.CurrentStatus = np.Status;

            if (np.Status=="Play")
            {
                this.Text = "Currently Playing...";
                this.PlayPause.Text = "| |";
            }

            if (np.Status == "Pause")
            {
                this.PlayPause.Text = ">";
                this.Text = "Paused";
            }
            if (np.Status == "Stop")
            {
                this.PlayPause.Text = ">";
                this.Text = "Stopped";
                this.label1.Text = "";
                this.label2.Text = "";
                this.label3.Text = "";
                pictureBox1.Image = null;
                pictureBox1.Invalidate();
                return;
            }


            if (currentTitle != np.Title)
            {
                History.Add(new Tuple<DateTime,NowPlayingInfo>(DateTime.Now,np));
                label4.Text = History.Count + " songs played";
                currentTitle = np.Title;
                this.label1.Text = np.Artist;
                this.label2.Text = np.Title;
                this.label3.Text = np.Album;


            }

            if (currentArtUrl != np.ArtURL)
            {
                var y = new YamahaReceiver();
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = y.GetImage(np.ArtURL)?.GetThumbnailImage(pictureBox1.Width, pictureBox1.Height, null, new IntPtr());
                pictureBox1.Invalidate();
                currentArtUrl = np.ArtURL;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetCurrent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Amp.ChangeVolume(-2);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Amp.ChangeVolume(+2);

        }

        private void label4_Click(object sender, EventArgs e)
        {
            var h = new History(this);
            
            h.Show();
        }

        private void PlayPause_Click(object sender, EventArgs e)
        {
            if (this.CurrentStatus=="Play")
            {
                Amp.Pause();
            } else
            {
                Amp.Play();
            }
        }
    }
}