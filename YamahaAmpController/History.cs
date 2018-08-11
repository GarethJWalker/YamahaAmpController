using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YamahaAmpController
{
    public partial class History : Form
    {
        public Main MyCaller { get; set; }

        public History(Main caller)
        {
            MyCaller = caller;



            InitializeComponent();

            Redraw();

        }


        public void Redraw()
        {
            this.dataGridView1.DataSource = MyCaller.History?.OrderByDescending(x=>x.Item1).Select(x => new { Date = x.Item1.ToShortDateString(), Time = x.Item1.ToLongTimeString(), x.Item2.Artist, x.Item2.Title, x.Item2.Album }).ToList();
                this.dataGridView1.Width = this.Width;
                this.dataGridView1.Height = this.Height;
                this.dataGridView1.Columns[0].Width = 70;
                this.dataGridView1.Columns[1].Width = 60;
                this.dataGridView1.Columns[2].Width = ((this.dataGridView1.Width - 130) / 3) - 1;
                this.dataGridView1.Columns[3].Width = ((this.dataGridView1.Width - 130) / 3) - 1;
                this.dataGridView1.Columns[4].Width = ((this.dataGridView1.Width - 130) / 3) - 1;

        }

        private void History_Resize(object sender, EventArgs e)
        {
            Redraw();
        }
    }
}
