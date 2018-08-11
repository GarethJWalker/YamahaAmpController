using System;
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
        History HistoryWindow { get;  set;}
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

            notifyIcon1.Visible = false;
            GetCurrent();
            timer1.Start();


        }

        private void GetCurrent()
        {


            var np = Amp.NowPlaying();

            this.CurrentStatus = np.Status;

            if (np.Status=="Play")
            {
                this.Text = $"Playing ({Amp.GetStatus().Source})...";
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
                button1.Text = History.Count + " songs";
                currentTitle = np.Title;
                this.label1.Text = np.Artist;
                this.label2.Text = np.Title;
                this.label3.Text = np.Album;
                HistoryWindow?.Redraw();
                notifyIcon1.BalloonTipText = np.Artist + " - " + np.Title;
                notifyIcon1.Text = (np.Artist + " - " + np.Title).Left(50);
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

        private void GetVolumeStatus()
        {
            var status = Amp.GetStatus();

            if (status.MainZoneMute == "On")
            {
                this.Mute.Image = global::YamahaAmpController.Properties.Resources.speaker_volume_control_mute;
            }
            else
            {
                this.Mute.Image = global::YamahaAmpController.Properties.Resources.speaker_volume;
            }

            if (status.ZoneBMute == "On")
            {
                this.Mute2.Image = global::YamahaAmpController.Properties.Resources.speaker_volume_control_mute;
            }
            else
            {
                this.Mute2.Image = global::YamahaAmpController.Properties.Resources.speaker_volume;
            }

            Volume1.Text = (status.MainZoneVolume/10.0).ToString() + " dB";
            Volume2.Text = (status.ZoneBVolume/10.0).ToString() + " dB";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetCurrent();
            GetVolumeStatus();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Amp.ChangeVolume(-2);
            GetVolumeStatus();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Amp.ChangeVolume(+2);
            GetVolumeStatus();
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

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {


            notifyIcon1.Visible = true;

            this.Hide();
            e.Cancel = true;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
             
                this.Show();
                notifyIcon1.Visible = false;
            }
            if (e.Button == MouseButtons.Right)
            {

                contextMenuStrip1.Show();
                Rectangle workingArea = Screen.GetWorkingArea(this);
                contextMenuStrip1.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - 30);
            }
        }



        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Environment.Exit(0);
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }

        private void DecreaseVolume2_Click(object sender, EventArgs e)
        {
            Amp.ChangeVolume(-2,2);
            GetVolumeStatus();
        }

        private void IncreaseVolume2_Click(object sender, EventArgs e)
        {
            Amp.ChangeVolume(2, 2);
            GetVolumeStatus();
        }

        private void Mute_Click(object sender, EventArgs e)
        {
            Amp.ToggleMute(1);
            GetVolumeStatus();
        }

        private void Mute2_Click(object sender, EventArgs e)
        {
            Amp.ToggleMute(2);
            GetVolumeStatus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (HistoryWindow == null || HistoryWindow.IsDisposed) HistoryWindow = new History(this);

            HistoryWindow.Show();
            HistoryWindow.Focus();
        }
    }
}
