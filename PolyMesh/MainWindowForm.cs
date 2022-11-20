using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Timers;

namespace PolyMesh
{
    public partial class MainWindowForm : Form
    {
        public readonly Model model;
        public readonly Bitmap bits;
        private Thread thread;
        private static ManualResetEvent mre = new ManualResetEvent(false);


        public MainWindowForm()
        {
            InitializeComponent();

            model = Parser.ParseModel(Settings.path);
            bits = new(Settings.bitmapSize, Settings.bitmapSize);
            MainPictureBox.Invalidate();
            thread = new Thread(MainLoop);
            thread.Start();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            thread.Interrupt();
            base.OnFormClosing(e);
        }
        private void MainLoop()
        {
            while (true)
            {
                mre.WaitOne();
                System.Threading.Thread.Sleep(10);
                MainPictureBox.Invalidate();
            }
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            _ = model;
            using var g = Graphics.FromImage(bits);
            g.Clear(Color.White);
            foreach (var t in model.triangles)
            {
                t.Paint(bits);
            }
            if (DrawEdgesCheckBox.Checked)
            {
                foreach (var t in model.triangles)
                {
                    g.DrawLine(Pens.Black, (int)t.vertices[0].position.X, (int)t.vertices[0].position.Y, (int)t.vertices[1].position.X, (int)t.vertices[1].position.Y);
                    g.DrawLine(Pens.Black, (int)t.vertices[1].position.X, (int)t.vertices[1].position.Y, (int)t.vertices[2].position.X, (int)t.vertices[2].position.Y);
                    g.DrawLine(Pens.Black, (int)t.vertices[2].position.X, (int)t.vertices[2].position.Y, (int)t.vertices[0].position.X, (int)t.vertices[0].position.Y);
                }
            }
            e.Graphics.DrawImage(bits, 0, 0);
        }

        private void LightSourceZTrackBar_Scroll(object sender, EventArgs e)
        {
            Geometry.Z = LightSourceZTrackBar.Value + Settings.bitmapSize / 2;
            MainPictureBox.Invalidate();
        }

        private void DrawEdgesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MainPictureBox.Invalidate();
        }

        private void LightSourceColorButton_Click(object sender, EventArgs e)
        {
            LightSourceStopCheckBox.Checked = true;
            LightSourceColorDialog.ShowDialog();
            Geometry.il = LightSourceColorDialog.Color;
            colorLabel.BackColor = LightSourceColorDialog.Color;
            MainPictureBox.Invalidate();
        }

        private void mTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Geometry.m = mTrackBar.Value;
            mLabel.Text = "m = " + mTrackBar.Value.ToString();
            MainPictureBox.Invalidate();
        }

        private void ksTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Geometry.ks = (double)ksTrackBar.Value / ksTrackBar.Maximum;
            ksLabel.Text = "ks = " + ((double)ksTrackBar.Value / ksTrackBar.Maximum).ToString();
            MainPictureBox.Invalidate();
        }

        private void kdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Geometry.kd = (double)kdTrackBar.Value / kdTrackBar.Maximum;
            kdLabel.Text = "kd = " + ((double)kdTrackBar.Value / kdTrackBar.Maximum).ToString();
            MainPictureBox.Invalidate();
        }
        private void LightSourceStopTextBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LightSourceStopCheckBox.Checked)
            {
                Settings.stopwatch.Stop();
                mre.Reset();
            }
            else
            {
                Settings.stopwatch.Start();
                mre.Set();
            }
            MainPictureBox.Invalidate();
        }
    }
}