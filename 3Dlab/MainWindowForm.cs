using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Timers;

namespace PolyMesh
{
    public partial class MainWindowForm : Form
    {
        public readonly List<Model> models = new List<Model>();
        public Matrix4x4 rotationMatrix;
        public Matrix4x4 viewMatrix;
        public Matrix4x4 lastMatrix;
        public readonly DirectBitmap bits;
        private readonly Thread thread;
        private static ManualResetEvent mre = new ManualResetEvent(false);
        public MainWindowForm()
        {
            InitializeComponent();

            models.Add(Utils.ParseModel(Settings.path));
            models.Add(Utils.ParseModel(Settings.path));
            models.Add(Utils.ParseModel(Settings.path));
            models[0].color = Color.Red;
            models[1].color = Color.Green;
            foreach (var t in models[0].triangles)
            {
                foreach (var v in t.vertices)
                {
                    v.position.Z -= 200;
                }

            }
            foreach (var t in models[2].triangles)
            {
                foreach (var v in t.vertices)
                {
                    v.position.Z += 200;
                }
            }
            foreach (var m in models)
            {
                foreach (var t in m.triangles)
                {
                    foreach (var v in t.vertices)
                    {
                        v.position.X += 400;
                        v.position.X += 400;
                    }
                }
            }
            rotationMatrix = Matrix4x4.CreateRotationX(0);
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
            Geometry.zBufferClear();
            rotationMatrix = Matrix4x4.CreateRotationX((float)Settings.stopwatch.ElapsedMilliseconds / 2000);
            viewMatrix = Matrix4x4.CreateLookAt(new Vector3(Geometry.X, Geometry.Y, Geometry.Z), new Vector3(0, 0, 0), new Vector3(0, 0, 1));
            lastMatrix = Matrix4x4.CreatePerspectiveFieldOfView((float)FieldTrackBar.Value / 180 * 3.14f, 1f, 1000, 2000);
            using var g = Graphics.FromImage(bits.Bitmap);
            g.Clear(Color.White);
            if (DrawEdgesCheckBox.Checked)
            {
                foreach (var model in models)
                {

                    foreach (var t in model.triangles)
                    {
                        var v0 = new Vector4(t.vertices[0].position, 1);
                        var v1 = new Vector4(t.vertices[1].position, 1);
                        var v2 = new Vector4(t.vertices[2].position, 1);
                        v0 = Vector4.Transform(v0, rotationMatrix);
                        v1 = Vector4.Transform(v1, rotationMatrix);
                        v2 = Vector4.Transform(v2, rotationMatrix);
                        v0 = Vector4.Transform(v0, viewMatrix);
                        v1 = Vector4.Transform(v1, viewMatrix);
                        v2 = Vector4.Transform(v2, viewMatrix);
                        v0 = Vector4.Transform(v0, lastMatrix);
                        v1 = Vector4.Transform(v1, lastMatrix);
                        v2 = Vector4.Transform(v2, lastMatrix);
                        v0 = new Vector4(v0.Z / v0.W, v0.Y / v0.W, v0.Z / v0.W, 1);
                        v1 = new Vector4(v1.Z / v1.W, v1.Y / v1.W, v1.Z / v1.W, 1);
                        v2 = new Vector4(v2.Z / v2.W, v2.Y / v2.W, v2.Z / v2.W, 1);
                        if (v0.X < -1 || v0.X > 1 || v1.X < -1 || v1.X > 1 || v2.X < -1 || v2.X > 1) continue;
                        var tri = new Triangle(
                            new Vector3(v0.X * Settings.bitmapSize / 2 + Settings.bitmapSize / 2, v0.Y * Settings.bitmapSize / 2 + Settings.bitmapSize / 2, v0.Z * Settings.bitmapSize / 2 + Settings.bitmapSize / 2),
                            new Vector3(v1.X * Settings.bitmapSize / 2 + Settings.bitmapSize / 2, v1.Y * Settings.bitmapSize / 2 + Settings.bitmapSize / 2, v1.Z * Settings.bitmapSize / 2 + Settings.bitmapSize / 2),
                            new Vector3(v2.X * Settings.bitmapSize / 2 + Settings.bitmapSize / 2, v2.Y * Settings.bitmapSize / 2 + Settings.bitmapSize / 2, v2.Z * Settings.bitmapSize / 2 + Settings.bitmapSize / 2),
                            t.vertices[0].normal, t.vertices[1].normal, t.vertices[1].normal
                            );

                        tri.Paint(bits, model.color, true);
                        //g.DrawLine(Pens.Black, (int)(v0.X * Settings.bitmapSize / 2 + Settings.bitmapSize / 2), (int)(v0.Y * Settings.bitmapSize / 2 + Settings.bitmapSize / 2), (int)(v1.X * Settings.bitmapSize / 2 + Settings.bitmapSize / 2), (int)(v1.Y * Settings.bitmapSize / 2 + Settings.bitmapSize / 2));
                        //g.DrawLine(Pens.Black, (int)(v1.X * Settings.bitmapSize / 2 + Settings.bitmapSize / 2), (int)(v1.Y * Settings.bitmapSize / 2 + Settings.bitmapSize / 2), (int)(v2.X * Settings.bitmapSize / 2 + Settings.bitmapSize / 2), (int)(v2.Y * Settings.bitmapSize / 2 + Settings.bitmapSize / 2));
                        //g.DrawLine(Pens.Black, (int)(v2.X * Settings.bitmapSize / 2 + Settings.bitmapSize / 2), (int)(v2.Y * Settings.bitmapSize / 2 + Settings.bitmapSize / 2), (int)(v0.X * Settings.bitmapSize / 2 + Settings.bitmapSize / 2), (int)(v0.Y * Settings.bitmapSize / 2 + Settings.bitmapSize / 2));
                    }
                }
            }

            _ = Geometry.zBuffer;
            Geometry.zBufferClear();
            e.Graphics.DrawImage(bits.Bitmap, 0, 0);
        }

        
        private void DrawEdgesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
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


        private void XTrackBar_Scroll(object sender, EventArgs e)
        {
            Geometry.X = XTrackBar.Value;
            xLabel.Text = "x = " + Geometry.X.ToString();
            MainPictureBox.Invalidate();
        }

        private void YTrackBar_Scroll(object sender, EventArgs e)
        {
            Geometry.Y = YTrackBar.Value;
            yLabel.Text = "y = " + Geometry.Y.ToString();
            MainPictureBox.Invalidate();
        }

        private void ZTrackBar_Scroll(object sender, EventArgs e)
        {
            Geometry.Z = ZTrackBar.Value;
            zLabel.Text = "z = " + Geometry.Z.ToString();
            MainPictureBox.Invalidate();
        }
    }
}