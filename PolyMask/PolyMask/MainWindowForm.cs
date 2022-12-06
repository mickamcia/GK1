using System.Diagnostics.Tracing;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace PolyMask
{
    public partial class MainWindowForm : Form
    {
        public DirectBitmap source;
        public DirectBitmap output;
        public CellType[,] orders;
        public CellType[,] current;
        public Histogram[] histograms;
        public Polygon polygon;
        public MainWindowForm()
        {
            polygon = new();
            histograms = new Histogram[4];
            histograms[0] = new Histogram((Color c) => c.R, Color.Red);
            histograms[1] = new Histogram((Color c) => c.G, Color.Green);
            histograms[2] = new Histogram((Color c) => c.B, Color.Blue);
            histograms[3] = new Histogram((Color c) => (c.R + c.G + c.B) / 3, Color.Black);
            orders = new CellType[Settings.PictureHeigth, Settings.PictureWidth];
            current = new CellType[Settings.PictureHeigth, Settings.PictureWidth];
            source = new DirectBitmap(Settings.PictureHeigth, Settings.PictureWidth);
            output = new DirectBitmap(Settings.PictureHeigth, Settings.PictureWidth);
            FillMask(orders, CellType.Unknown);
            FillMask(current, CellType.Unknown);
            Filter.ClearBitmap(output);
            InitializeComponent();
        }
        private void RefreshAll()
        {
            MainPictureUpdate();
            HistogramsUpdate();
            InvalidateAll();
        }
        private void InvalidateAll()
        {
            MainPictureBox.Invalidate();
            RedHistogramPictureBox.Invalidate();
            GreenHistogramPictureBox.Invalidate();
            BlueHistogramPictureBox.Invalidate();
            HistogramPictureBox.Invalidate();
        }
        private void HistogramsUpdate()
        {
            foreach (var histogram in histograms)
            {
                histogram.Update(source, output, current);
            }
        }

        private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            return;
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (!BrushFillRadioButton.Checked)
            {
                return;
            }
            for (int i = 0; i < Settings.PictureHeigth; i++)
            {
                for (int j = 0; j < Settings.PictureWidth; j++)
                {
                    if ((i - e.Y) * (i - e.Y) + (j - e.X) * (j - e.X) <= Settings.BrushSize * Settings.BrushSize)
                    {
                        orders[j, i] = BrushType.Filler == Settings.BrushType ? CellType.Applied : CellType.Calculated;
                        current[j, i] = CellType.Other;
                    }
                }
            }
            RefreshAll();
        }
        private void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (Settings.FillType)
            {
                case FillType.Whole:
                    switch (Settings.BrushType)
                    {
                        case BrushType.Filler:
                            FillMask(orders, CellType.Applied);
                            FillMask(current, CellType.Other);
                            RefreshAll();
                            break;
                        case BrushType.Eraser:
                            FillMask(orders, CellType.Calculated);
                            FillMask(current, CellType.Other);
                            RefreshAll();
                            break;
                    }
                    break;
                case FillType.Polygon:
                    if (e.Button == MouseButtons.Left)
                    {
                        polygon.points.Add(new PointF(e.Location.X, e.Location.Y));
                        MainPictureBox.Invalidate();
                    }
                    else
                    {
                        //if (polygon.points.Count == 0) break;
                        //polygon.points.Add(new PointF(polygon.points[0].X, polygon.points[0].Y));
;
                        for (int i = 0; i < Settings.PictureHeigth; i++)
                        {
                            for (int j = 0; j < Settings.PictureWidth; j++)
                            {
                                if (polygon.Contains(j, i))
                                {
                                    orders[j, i] = BrushType.Filler == Settings.BrushType ? CellType.Applied : CellType.Calculated;
                                    current[j, i] = CellType.Other;
                                }
                            }
                        }
                        polygon.points.Clear();
                        RefreshAll();
                    }
                    break;
                case FillType.Brush:
                    for (int i = 0; i < Settings.PictureHeigth; i++)
                    {
                        for (int j = 0; j < Settings.PictureWidth; j++)
                        {
                            if ((i - e.Y) * (i - e.Y) + (j - e.X) * (j - e.X) <= Settings.BrushSize * Settings.BrushSize)
                            {
                                orders[j, i] = BrushType.Filler == Settings.BrushType ? CellType.Applied : CellType.Calculated;
                                current[j, i] = CellType.Other;
                            }
                        }
                    }
                    RefreshAll();
                    break;
                default:
                    break;
            }
        }
        private void MainPictureUpdate()
        {
            for (int i = 0; i < Settings.PictureHeigth; i++)
            {
                for (int j = 0; j < Settings.PictureWidth; j++)
                {
                    switch (current[i, j])
                    {
                        case CellType.Applied:
                            switch (orders[i, j])
                            {
                                case CellType.Calculated:
                                    output.SetPixel(i, j, Color.FromArgb(0, output.GetPixel(i, j)));
                                    current[i, j] = CellType.Calculated;
                                    break;
                                case CellType.Unknown:
                                    output.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                                    current[i, j] = CellType.Unknown;
                                    break;
                            }
                            break;
                        case CellType.Calculated:
                            switch (orders[i, j])
                            {
                                case CellType.Applied:
                                    output.SetPixel(i, j, Color.FromArgb(255, output.GetPixel(i, j)));
                                    current[i, j] = CellType.Applied;
                                    break;
                                case CellType.Unknown:
                                    output.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                                    current[i, j] = CellType.Unknown;
                                    break;
                            }
                            break;
                        case CellType.Other:
                            switch (orders[i, j])
                            {
                                case CellType.Applied:
                                    Filter.ApplyKernel(i, j, source, output, Settings.Kernel);
                                    current[i, j] = CellType.Applied;
                                    break;
                                case CellType.Calculated:
                                    Filter.ApplyKernel(i, j, source, output, Settings.Kernel);
                                    output.SetPixel(i, j, Color.FromArgb(0, output.GetPixel(i, j)));
                                    current[i, j] = CellType.Calculated;
                                    break;
                                case CellType.Unknown:
                                    output.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                                    current[i, j] = CellType.Unknown;
                                    break;
                            }
                            break;
                        case CellType.Unknown:
                            switch (orders[i, j])
                            {
                                case CellType.Applied:
                                    Filter.ApplyKernel(i, j, source, output, Settings.Kernel);
                                    current[i, j] = CellType.Applied;
                                    break;
                                case CellType.Calculated:
                                    Filter.ApplyKernel(i, j, source, output, Settings.Kernel);
                                    output.SetPixel(i, j, Color.FromArgb(0, output.GetPixel(i, j)));
                                    current[i, j] = CellType.Calculated;
                                    break;
                            }
                            break;
                    }
                }
            }
        }
        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            var pen = new Pen(Brushes.Red, 1);
            e.Graphics.DrawImage(source.Bitmap, 0, 0);
            e.Graphics.DrawImage(output.Bitmap, 0, 0);
            var g = e.Graphics;
            for (int i = 0; i < polygon.points.Count; i++)
            {
                g.DrawLine(pen, polygon.points[i], polygon.points[(i + 1) % polygon.points.Count]);
            }
        }
        private void UpdateChangesButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Settings.PictureHeigth; i++)
            {
                for (int j = 0; j < Settings.PictureWidth; j++)
                {
                    if (current[i,j] == CellType.Applied || current[i,j] == CellType.Other)
                    {
                        source.SetPixel(i, j, output.GetPixel(i, j));
                    }
                }
            }
            FillMask(current, CellType.Unknown);
            FillMask(orders, CellType.Unknown);
        }

        private void ChooseImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ImagePathLabel.Text = dlg.FileName;
                    var temp = new Bitmap(dlg.FileName);
                    temp = new Bitmap(temp, Settings.PictureWidth, Settings.PictureHeigth);
                    for (int i = 0; i < Settings.PictureHeigth; i++)
                    {
                        for (int j = 0; j < Settings.PictureWidth; j++)
                        {
                            source.SetPixel(j, i, temp.GetPixel(j, i));
                        }
                    }
                    FillMask(orders, CellType.Unknown);
                    FillMask(current, CellType.Unknown);
                }
            }
            RefreshAll();
        }

        private void IdentityRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(IdentityRadioButton.Checked)
            {
                Settings.Kernel = Kernels.Identity;
                UpdateKernelCellValues(Kernels.Identity);
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();

                }
            }
        }
        private void RidgeDetectionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RidgeDetectionRadioButton.Checked)
            {
                Settings.Kernel = Kernels.RidgeDetection;
                UpdateKernelCellValues(Kernels.RidgeDetection);
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();

                }
            }
        }

        private void GaussianBlurRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (GaussianBlurRadioButton.Checked)
            {
                Settings.Kernel = Kernels.GaussianBlur;
                UpdateKernelCellValues(Kernels.GaussianBlur);
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();

                }
            }
        }

        private void EmbossRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (EmbossRadioButton.Checked)
            {
                Settings.Kernel = Kernels.Emboss;
                UpdateKernelCellValues(Kernels.Emboss);
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();

                }
            }
        }

        private void SharpenRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SharpenRadioButton.Checked)
            {
                Settings.Kernel = Kernels.Sharpen;
                UpdateKernelCellValues(Kernels.Sharpen);
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();

                }
            }
        }

        private void SobelLeftRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SobelLeftRadioButton.Checked)
            {
                Settings.Kernel = Kernels.SobelLeft;
                UpdateKernelCellValues(Kernels.SobelLeft);
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();

                }
            }
        }

        private void BoxBlurRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (BoxBlurRadioButton.Checked)
            {
                Settings.Kernel = Kernels.BoxBlur;
                UpdateKernelCellValues(Kernels.BoxBlur);
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();
                }
            }
        }

        private void CustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            CustomKernelTableLayoutPanel.Enabled = CustomRadioButton.Checked;
            if (CustomRadioButton.Checked)
            {
                Settings.Kernel = Kernels.Custom;
                UpdateKernelCellValues(Kernels.Custom);
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();
                }
            }
        }

        private void KernelCellNumericUpDown0_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[0] = (float)KernelCellNumericUpDown0.Value;
            if(CustomKernelTableLayoutPanel.Enabled)
            {
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();
                }
            }
        }

        private void KernelCellNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[1] = (float)KernelCellNumericUpDown1.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();
                }
            }
        }

        private void KernelCellNumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[2] = (float)KernelCellNumericUpDown2.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Other);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();
                }
            }
        }

        private void KernelCellNumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[3] = (float)KernelCellNumericUpDown3.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();
                }
            }
        }

        private void KernelCellNumericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[4] = (float)KernelCellNumericUpDown4.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();
                }
            }
        }

        private void KernelCellNumericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[5] = (float)KernelCellNumericUpDown5.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();
                }
            }
        }

        private void KernelCellNumericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[6] = (float)KernelCellNumericUpDown6.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();
                }
            }
        }

        private void KernelCellNumericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[7] = (float)KernelCellNumericUpDown7.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();
                }
            }
        }

        private void KernelCellNumericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            Kernels.Custom[8] = (float)KernelCellNumericUpDown8.Value;
            if (CustomKernelTableLayoutPanel.Enabled)
            {
                if (ImmediatelyRadioButton.Checked)
                {
                    FillMask(current, CellType.Unknown);
                    MainPictureBox.Invalidate();
                    HistogramsUpdate();
                }
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
            if(type == CellType.Other)
            {
                for (int i = 0; i < Settings.PictureHeigth; i++)
                {
                    for (int j = 0; j < Settings.PictureWidth; j++)
                    {
                        mask[i, j] = mask[i,j] == CellType.Applied ? CellType.Other : CellType.Unknown;
                    }
                }
                return;
            }
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
            e.Graphics.DrawImage(histograms[0].Bits.Bitmap, 0, 0);
        }

        private void GreenHistogramPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(histograms[1].Bits.Bitmap, 0, 0);
        }

        private void BlueHistogramPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(histograms[2].Bits.Bitmap, 0, 0);
        }

        private void HistogramPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(histograms[3].Bits.Bitmap, 0, 0);
        }

        private void EraserRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (EraserRadioButton.Checked)
            {
                Settings.BrushType = BrushType.Eraser;
            }
        }

        private void FillerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (FillerRadioButton.Checked)
            {
                Settings.BrushType = BrushType.Filler;
            }
        }

        private void WholeFillRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (WholeFillRadioButton.Checked)
            {
                polygon.points.Clear();
                Settings.FillType = FillType.Whole;
            }
        }

        private void PolygonFillRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (PolygonFillRadioButton.Checked)
            {
                polygon.points.Clear();
                Settings.FillType = FillType.Polygon;
            }
        }

        private void BrushFillRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (BrushFillRadioButton.Checked)
            {
                polygon.points.Clear();
                Settings.FillType = FillType.Brush;
            }
        }

        private void BrushSizeTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.BrushSize = BrushSizeTrackBar.Value;
            BrushSizeLabel.Text = "Brush Size: " + BrushSizeTrackBar.Value.ToString();
        }
    }
}