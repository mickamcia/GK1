using Microsoft.VisualBasic.ApplicationServices;

namespace PolyView
{
    public partial class MainWindowForm : Form
    {
        public static Scene scene = new Scene();
        public readonly DirectBitmap bits;
        public MainWindowForm()
        {
            bits = new(Settings.BitmapWidth, Settings.BitmapHeight);
            InitializeComponent();
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            scene.zBuffer.Reset();
            scene.CalculateAnimation();
            scene.CalculateFrame();
            Settings.frameCount++;
            using var g = Graphics.FromImage(bits.Bitmap);
            g.Clear(Color.White);
            foreach (var model in scene.movingModels)
            {
                model.Paint(bits);
            }
            foreach (var model in scene.stationaryModels)
            {
                model.Paint(bits);
            }
            e.Graphics.DrawImage(bits.Bitmap, 0, 0);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            MainPictureBox.Invalidate();
        }

        private void CameraOnCenterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Settings.cameraOption = CameraOption.Center;
            MainPictureBox.Invalidate();
        }

        private void CameraOnStationaryObjectRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Settings.cameraOption = CameraOption.Stationary;
            MainPictureBox.Invalidate();
        }

        private void CameraOnMovingObjectRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Settings.cameraOption = CameraOption.Moving;
            MainPictureBox.Invalidate();
        }

        private void LightOnMovingObjectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.LightOnMovingObject = LightOnMovingObjectCheckBox.Checked;
            MainPictureBox.Invalidate();
        }

        private void LightOnStationaryObjectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.LightOnStationaryObject = LightOnStationaryObjectCheckBox.Checked;
            MainPictureBox.Invalidate();
        }

        private void LightingDaylightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.LightingDaylight = LightingDaylightCheckBox.Checked;
            MainPictureBox.Invalidate();
        }

        private void LightingFogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.LightingFog = LightingFogCheckBox.Checked;
            MainPictureBox.Invalidate();
        }

        private void ShadingConstantRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Settings.shadingType = ShadingType.Constant;
            MainPictureBox.Invalidate();
        }

        private void ShadingGouraudRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Settings.shadingType = ShadingType.Gouraud;
            MainPictureBox.Invalidate();
        }

        private void ShadingPhongRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Settings.shadingType = ShadingType.Phong;
            MainPictureBox.Invalidate();
        }
    }
}