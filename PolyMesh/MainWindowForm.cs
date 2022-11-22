using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Timers;

namespace PolyMesh
{
    public partial class MainWindowForm : Form
    {
        public readonly Model model;
        public readonly DirectBitmap bits;
        private readonly Thread thread;
        private static ManualResetEvent mre = new ManualResetEvent(false);

        //labowe zmienne
        public Triangle obstacle;
        public Triangle shadow;
        public Vector3[] positions;
        //koniec
        public MainWindowForm()
        {
            InitializeComponent();

            //***laby start
            positions = new Vector3[5];
            positions[0] = new Vector3(300, 300, 100);
            positions[1] = new Vector3(400, 300, 100);
            positions[2] = new Vector3(400, 400, 100);
            positions[3] = new Vector3(100, 400, 100);
            positions[4] = new Vector3(350, 350, 100);
            obstacle = new();
            obstacle.vertices.Add(new Vertex(new Vector3(300, 300, 100), new Vector3(0, 0, 1)));
            obstacle.vertices.Add(new Vertex(new Vector3(400, 300, 100), new Vector3(0, 0, 1)));
            obstacle.vertices.Add(new Vertex(new Vector3(400, 400, 100), new Vector3(0, 0, 1)));
            obstacle.vertices.Add(new Vertex(new Vector3(100, 400, 100), new Vector3(0, 0, 1)));
            obstacle.vertices.Add(new Vertex(new Vector3(350, 350, 100), new Vector3(0, 0, 1)));

            for (int i = 0; i < obstacle.vertices.Count; i++)
            {
                obstacle.vertices[i].next = obstacle.vertices[(i + 1) % obstacle.vertices.Count];
                obstacle.vertices[i].prev = obstacle.vertices[(i + obstacle.vertices.Count - 1) % obstacle.vertices.Count];
            }
            obstacle.GenerateAETP();

            shadow = new();
            shadow.vertices.Add(new Vertex(new Vector3(300, 300, 0), new Vector3(0, 0, 1)));
            shadow.vertices.Add(new Vertex(new Vector3(400, 300, 0), new Vector3(0, 0, 1)));
            shadow.vertices.Add(new Vertex(new Vector3(400, 400, 0), new Vector3(0, 0, 1)));
            shadow.vertices.Add(new Vertex(new Vector3(100, 400, 0), new Vector3(0, 0, 1)));
            shadow.vertices.Add(new Vertex(new Vector3(350, 350, 0), new Vector3(0, 0, 1)));
            for (int i = 0; i < obstacle.vertices.Count; i++)
            {
                shadow.vertices[i].next = shadow.vertices[(i + 1) % shadow.vertices.Count];
                shadow.vertices[i].prev = shadow.vertices[(i + shadow.vertices.Count - 1) % shadow.vertices.Count];
            }
            ///***koniec
            model = Utils.ParseModel(Settings.path);
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
                System.Threading.Thread.Sleep(50);
                mre.WaitOne();
                MainPictureBox.Invalidate();
            }
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            using var g = Graphics.FromImage(bits.Bitmap);
            g.Clear(Color.White);
            Parallel.ForEach(model.triangles, t => t.Paint(bits)); 
            if (DrawEdgesCheckBox.Checked)
            {
                foreach (var t in model.triangles)
                {
                    g.DrawLine(Pens.Black, (int)t.vertices[0].position.X, (int)t.vertices[0].position.Y, (int)t.vertices[1].position.X, (int)t.vertices[1].position.Y);
                    g.DrawLine(Pens.Black, (int)t.vertices[1].position.X, (int)t.vertices[1].position.Y, (int)t.vertices[2].position.X, (int)t.vertices[2].position.Y);
                    g.DrawLine(Pens.Black, (int)t.vertices[2].position.X, (int)t.vertices[2].position.Y, (int)t.vertices[0].position.X, (int)t.vertices[0].position.Y);
                }
            }
            if (DrawObstacleCheckBox.Checked) ///*** laby
            {
                if (AnimateObstacleCheckBox.Checked)
                {
                    for(int i = 0; i < positions.Length; i++)
                    {
                        obstacle.vertices[i].position.X = positions[i].X + 50*(float)(Math.Sin((float)Settings.stopwatch.ElapsedMilliseconds / 2000) + 1);
                    }
                    obstacle.GenerateAETP();
                }
                for (int i = 0; i < obstacle.vertices.Count; i++)
                {
                    var offset = Settings.bitmapSize / 2;
                    var scale = (Geometry.Z) / (Geometry.Z - obstacle.vertices[i].position.Z);
                    var sunScale = (Geometry.Z - obstacle.vertices[i].position.Z) / obstacle.vertices[i].position.Z;

                    var light = Geometry.GetLightVector((float)Settings.stopwatch.ElapsedMilliseconds / 2000);
                    shadow.vertices[i].position = new Vector3(
                        (obstacle.vertices[i].position.X - offset - (light.X - offset) / sunScale) * scale + offset,
                        (obstacle.vertices[i].position.Y - offset - (light.Y - offset) / sunScale) * scale + offset,
                        0);
                }
                shadow.GenerateAETP();
                shadow.Paint(bits, true);
                obstacle.Paint(bits);

            }////*** koniec
            e.Graphics.DrawImage(bits.Bitmap, 0, 0);
        }

        private void LightSourceZTrackBar_Scroll(object sender, EventArgs e)
        {
            Geometry.Z = LightSourceZTrackBar.Value + Settings.bitmapSize / 2;
            zLabel.Text = "z = " + Geometry.Z.ToString();
            MainPictureBox.Invalidate();
        }

        private void DrawEdgesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MainPictureBox.Invalidate();
        }

        private void LightSourceColorButton_Click(object sender, EventArgs e)
        {
            LightSourceStopCheckBox.Checked = true;
            MainColorDialog.ShowDialog();
            Geometry.il = MainColorDialog.Color;
            LightColorLabel.BackColor = MainColorDialog.Color;
            MainPictureBox.Invalidate();
        }
        private void ObjectColorButton_Click(object sender, EventArgs e)
        {
            LightSourceStopCheckBox.Checked = true;
            MainColorDialog.ShowDialog();
            Geometry.io = MainColorDialog.Color;
            ObjectColorLabel.BackColor = MainColorDialog.Color;
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
            Geometry.ks = (float)ksTrackBar.Value / ksTrackBar.Maximum;
            ksLabel.Text = "ks = " + ((double)ksTrackBar.Value / ksTrackBar.Maximum).ToString();
            MainPictureBox.Invalidate();
        }

        private void kdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Geometry.kd = (float)kdTrackBar.Value / kdTrackBar.Maximum;
            kdLabel.Text = "kd = " + ((double)kdTrackBar.Value / kdTrackBar.Maximum).ToString();
            MainPictureBox.Invalidate();
        }
        private void LightSourceStopTextBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LightSourceStopCheckBox.Checked)
            {
                AnimateObstacleCheckBox.Checked = false;
                AnimateObstacleCheckBox.Enabled = false;
                Settings.stopwatch.Stop();
                mre.Reset();
            }
            else
            {
                AnimateObstacleCheckBox.Enabled = true;
                Settings.stopwatch.Start();
                mre.Set();
            }
            MainPictureBox.Invalidate();
        }

        private void NormalInterpolationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Settings.interpolationType = NormalInterpolationRadioButton.Checked ? Settings.InterpolationType.Normal : Settings.InterpolationType.Color;
            MainPictureBox.Invalidate();
        }

        private void AddTextureButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    TextureLabel.Text = "Texture: " + dlg.FileName.ToString();
                    var temp = new Bitmap(dlg.FileName);
                    temp = new Bitmap(temp, Settings.bitmapSize, Settings.bitmapSize);
                    Settings.texture = new DirectBitmap(Settings.bitmapSize, Settings.bitmapSize);
                    for (int i = 0; i < Settings.bitmapSize; i++)
                    {
                        for (int j = 0; j < Settings.bitmapSize; j++)
                        {
                            Settings.texture.SetPixel(i, j, temp.GetPixel(i, j));
                        }
                    }
                }
            }
            MainPictureBox.Invalidate();
        }

        private void AddNormalMapButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    NormalMapLabel.Text = "Normal Map: " + dlg.FileName.ToString();
                    var temp = new Bitmap(dlg.FileName);
                    temp = new Bitmap(temp, Settings.bitmapSize, Settings.bitmapSize);
                    Settings.normalMap = new DirectBitmap(Settings.bitmapSize, Settings.bitmapSize);
                    for (int i = 0; i < Settings.bitmapSize; i++)
                    {
                        for (int j = 0; j < Settings.bitmapSize; j++)
                        {
                            Settings.normalMap.SetPixel(i, j, temp.GetPixel(i, j));
                        }
                    }
                }
            }
            MainPictureBox.Invalidate();
        }

        private void RevertTextureButton_Click(object sender, EventArgs e)
        {
            Settings.texture = null;
            TextureLabel.Text = "Texture: None";
            MainPictureBox.Invalidate();
        }

        private void RevertNormalMapButton_Click(object sender, EventArgs e)
        {
            Settings.normalMap = null;
            NormalMapLabel.Text = "Normal Map: None";
            MainPictureBox.Invalidate();
        }

        private void kaTrackBar_Scroll(object sender, EventArgs e)
        {
            Geometry.ka = kaTrackBar.Value;
            kaLabel.Text = "ka = " + kaTrackBar.Value.ToString();
            MainPictureBox.Invalidate();
        }

        private void DrawObstacleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MainPictureBox.Invalidate();
        }
    }
}