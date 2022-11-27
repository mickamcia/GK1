using System.Diagnostics.Tracing;
using System.Reflection;

namespace PolyMask
{
    public partial class MainWindowForm : Form
    {
        public DirectBitmap source;
        public DirectBitmap output;
        public CellType[,] orders;
        public CellType[,] current;
        public Histograms histograms; 
        public MainWindowForm()
        {
            histograms = new Histograms();
            orders = new CellType[Settings.PictureHeigth, Settings.PictureWidth];
            current = new CellType[Settings.PictureHeigth, Settings.PictureWidth];
            source = new DirectBitmap(Settings.PictureWidth, Settings.PictureHeigth);
            output = new DirectBitmap(Settings.PictureWidth, Settings.PictureHeigth);
            FillMask(orders, CellType.Visible);
            FillMask(current, CellType.Unknown);
            Filter.ClearBitmap(output);
            InitializeComponent();
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Settings.PictureHeigth; i++)
            {
                for (int j = 0; j < Settings.PictureWidth; j++)
                {
                    switch (current[i,j])
                    {
                        case CellType.Visible:
                            switch (orders[i,j])
                            {
                                case CellType.Hidden:
                                    output.SetPixel(i, j, Color.FromArgb(0, output.GetPixel(i, j)));
                                    current[i,j] = CellType.Visible;
                                    break;
                                case CellType.Unknown:
                                    output.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                                    current[i, j] = CellType.Visible;
                                    break;
                            }
                            break;
                        case CellType.Hidden:
                            switch (orders[i, j])
                            {
                                case CellType.Visible:
                                    output.SetPixel(i, j, Color.FromArgb(255, output.GetPixel(i, j)));
                                    current[i, j] = CellType.Hidden;
                                    break;
                                case CellType.Unknown:
                                    output.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                                    current[i, j] = CellType.Hidden;
                                    break;
                            }
                            break;
                        case CellType.Unknown:
                            switch (orders[i, j])
                            {
                                case CellType.Visible:
                                    Filter.ApplyKernel(i, j, source, output, Settings.Kernel);
                                    current[i, j] = CellType.Unknown;
                                    break;
                                case CellType.Hidden:
                                    Filter.ApplyKernel(i, j, source, output, Settings.Kernel);
                                    output.SetPixel(i, j, Color.FromArgb(0, output.GetPixel(i, j)));
                                    current[i, j] = CellType.Unknown;
                                    break;
                            }
                            break;
                    }
                }
            }
            e.Graphics.DrawImage(source.Bitmap, 0, 0);
            e.Graphics.DrawImage(output.Bitmap, 0, 0);
        }

        private void ChooseImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var temp = new Bitmap(dlg.FileName);
                    temp = new Bitmap(temp, Settings.PictureWidth, Settings.PictureHeigth);
                    for (int i = 0; i < Settings.PictureHeigth; i++)
                    {
                        for (int j = 0; j < Settings.PictureWidth; j++)
                        {
                            source.SetPixel(i, j, temp.GetPixel(i, j));
                        }
                    }
                    FillMask(orders, CellType.Visible);
                    FillMask(current, CellType.Unknown);
                }
            }
            MainPictureBox.Invalidate();
        }

        private void IdentityRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(IdentityRadioButton.Checked)
            {
                Settings.Kernel = Kernels.Identity;
                UpdateKernelCellValues(Kernels.Identity);
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }
        private void RidgeDetectionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RidgeDetectionRadioButton.Checked)
            {
                Settings.Kernel = Kernels.RidgeDetection;
                UpdateKernelCellValues(Kernels.RidgeDetection);
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void GaussianBlurRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (GaussianBlurRadioButton.Checked)
            {
                Settings.Kernel = Kernels.GaussianBlur;
                UpdateKernelCellValues(Kernels.GaussianBlur);
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void EmbossRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (EmbossRadioButton.Checked)
            {
                Settings.Kernel = Kernels.Emboss;
                UpdateKernelCellValues(Kernels.Emboss);
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void SharpenRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SharpenRadioButton.Checked)
            {
                Settings.Kernel = Kernels.Sharpen;
                UpdateKernelCellValues(Kernels.Sharpen);
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void SobelLeftRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SobelLeftRadioButton.Checked)
            {
                Settings.Kernel = Kernels.SobelLeft;
                UpdateKernelCellValues(Kernels.SobelLeft);
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void BoxBlurRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (BoxBlurRadioButton.Checked)
            {
                Settings.Kernel = Kernels.BoxBlur;
                UpdateKernelCellValues(Kernels.BoxBlur);
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void CustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            CustomKernelTableLayoutPanel.Enabled = CustomRadioButton.Checked;
            if (CustomRadioButton.Checked)
            {
                Settings.Kernel = Kernels.Custom;
                UpdateKernelCellValues(Kernels.Custom);
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void KernelCellNumericUpDown0_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[0] = (float)KernelCellNumericUpDown0.Value;
            if(CustomKernelTableLayoutPanel.Enabled)
            {
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void KernelCellNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[1] = (float)KernelCellNumericUpDown1.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void KernelCellNumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[2] = (float)KernelCellNumericUpDown2.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void KernelCellNumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[3] = (float)KernelCellNumericUpDown3.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void KernelCellNumericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[4] = (float)KernelCellNumericUpDown4.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void KernelCellNumericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[5] = (float)KernelCellNumericUpDown5.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void KernelCellNumericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[6] = (float)KernelCellNumericUpDown6.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void KernelCellNumericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[7] = (float)KernelCellNumericUpDown7.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void KernelCellNumericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[8] = (float)KernelCellNumericUpDown8.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                FillMask(current, CellType.Unknown);
                MainPictureBox.Invalidate();
            }
        }

        private void UpdateKernelCellValues(float[] kernel)
        {
            KernelCellNumericUpDown0.Value = (decimal)kernel[0];
            KernelCellNumericUpDown1.Value = (decimal)kernel[1];
            KernelCellNumericUpDown2.Value = (decimal)kernel[2];
            KernelCellNumericUpDown3.Value = (decimal)kernel[3];
            KernelCellNumericUpDown4.Value = (decimal)kernel[4];
            KernelCellNumericUpDown5.Value = (decimal)kernel[5];
            KernelCellNumericUpDown6.Value = (decimal)kernel[6];
            KernelCellNumericUpDown7.Value = (decimal)kernel[7];
            KernelCellNumericUpDown8.Value = (decimal)kernel[8];
        }
        private static void FillMask(CellType[,] mask, CellType type)
        {
            for (int i = 0; i < Settings.PictureHeigth; i++)
            {
                for (int j = 0; j < Settings.PictureWidth; j++)
                {
                    mask[i, j] = type;
                }
            }
        }

        private void RedHistogramPictureBox_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}