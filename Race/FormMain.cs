using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RaceLibrary;
using DrawingLibrary;
using System.Threading;

namespace Race
{
    public partial class FormMain : Form
    {
        private bool size = false;
        RaceLibrary.Race race;
        public FormMain()
        {
            InitializeComponent();
            race = new RaceLibrary.Race(ClientSize.Width, ClientSize.Height);
            timer1.Start();
        }

        private void новаяГонкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                race.StartRace();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DrawAll(Graphics g, Rectangle r)
        {
            if (race != null)
            {
                Bitmap bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
                Drawing.DrawRace(bmp, race);
                g.DrawImage(bmp, r);
                bmp.Dispose();
            }
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            DrawAll(e.Graphics, e.ClipRectangle);
        }

        private void остановитьГонкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                race.StopRace();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void добавитьНовогоУчастникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewRacerFrom anr = new AddNewRacerFrom();
            if (anr.ShowDialog() == DialogResult.OK)
            {
                string name = anr.GetName;
                try
                {
                    race.AddRacer(name);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void очиститьУчастниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                race.ClearParticipants();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void добавить4УчастникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            race.CreateRace();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {

        }

        private void изменитьРазмерыТрассыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!race.RaceIsOn)
            {
                size = true;
                FormBorderStyle = FormBorderStyle.Sizable;
                menuStrip1.Enabled = false;
            }
        }

        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            if (!race.RaceIsOn && size)
            {
                race.UpdateTrack(ClientSize.Width, ClientSize.Height);
                size = false;
                FormBorderStyle = FormBorderStyle.FixedDialog;
                menuStrip1.Enabled = true;
            }
        }
    }
}
