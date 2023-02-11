namespace PolyMesh
{
    partial class MainWindowForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.MainGroupBox = new System.Windows.Forms.GroupBox();
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.OptionsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FieldTrackBar = new System.Windows.Forms.TrackBar();
            this.XTrackBar = new System.Windows.Forms.TrackBar();
            this.YTrackBar = new System.Windows.Forms.TrackBar();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.LightSourceStopCheckBox = new System.Windows.Forms.CheckBox();
            this.ZTrackBar = new System.Windows.Forms.TrackBar();
            this.DrawEdgesCheckBox = new System.Windows.Forms.CheckBox();
            this.zLabel = new System.Windows.Forms.Label();
            this.MainColorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.MainGroupBox.SuspendLayout();
            this.OptionsGroupBox.SuspendLayout();
            this.OptionsLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FieldTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainPictureBox.Location = new System.Drawing.Point(0, 0);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(800, 800);
            this.MainPictureBox.TabIndex = 0;
            this.MainPictureBox.TabStop = false;
            this.MainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPictureBox_Paint);
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Controls.Add(this.OptionsGroupBox);
            this.MainGroupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.MainGroupBox.Location = new System.Drawing.Point(806, 0);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(200, 800);
            this.MainGroupBox.TabIndex = 1;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "Controls";
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.Controls.Add(this.OptionsLayoutPanel);
            this.OptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionsGroupBox.Location = new System.Drawing.Point(3, 19);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Size = new System.Drawing.Size(194, 265);
            this.OptionsGroupBox.TabIndex = 0;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "Options";
            // 
            // OptionsLayoutPanel
            // 
            this.OptionsLayoutPanel.ColumnCount = 3;
            this.OptionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.OptionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OptionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.OptionsLayoutPanel.Controls.Add(this.FieldTrackBar, 0, 4);
            this.OptionsLayoutPanel.Controls.Add(this.XTrackBar, 0, 0);
            this.OptionsLayoutPanel.Controls.Add(this.YTrackBar, 0, 1);
            this.OptionsLayoutPanel.Controls.Add(this.xLabel, 2, 0);
            this.OptionsLayoutPanel.Controls.Add(this.yLabel, 2, 1);
            this.OptionsLayoutPanel.Controls.Add(this.LightSourceStopCheckBox, 0, 3);
            this.OptionsLayoutPanel.Controls.Add(this.ZTrackBar, 0, 2);
            this.OptionsLayoutPanel.Controls.Add(this.DrawEdgesCheckBox, 1, 3);
            this.OptionsLayoutPanel.Controls.Add(this.zLabel, 2, 2);
            this.OptionsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.OptionsLayoutPanel.Name = "OptionsLayoutPanel";
            this.OptionsLayoutPanel.RowCount = 5;
            this.OptionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.OptionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.OptionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.OptionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.OptionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.OptionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.OptionsLayoutPanel.Size = new System.Drawing.Size(188, 243);
            this.OptionsLayoutPanel.TabIndex = 4;
            // 
            // FieldTrackBar
            // 
            this.OptionsLayoutPanel.SetColumnSpan(this.FieldTrackBar, 2);
            this.FieldTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FieldTrackBar.LargeChange = 0;
            this.FieldTrackBar.Location = new System.Drawing.Point(3, 205);
            this.FieldTrackBar.Maximum = 120;
            this.FieldTrackBar.Minimum = 30;
            this.FieldTrackBar.Name = "FieldTrackBar";
            this.FieldTrackBar.Size = new System.Drawing.Size(126, 35);
            this.FieldTrackBar.TabIndex = 9;
            this.FieldTrackBar.Value = 90;
            // 
            // XTrackBar
            // 
            this.OptionsLayoutPanel.SetColumnSpan(this.XTrackBar, 2);
            this.XTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XTrackBar.LargeChange = 0;
            this.XTrackBar.Location = new System.Drawing.Point(3, 3);
            this.XTrackBar.Maximum = 5000;
            this.XTrackBar.Minimum = -5000;
            this.XTrackBar.Name = "XTrackBar";
            this.XTrackBar.Size = new System.Drawing.Size(126, 45);
            this.XTrackBar.TabIndex = 8;
            this.XTrackBar.Value = 2200;
            this.XTrackBar.Scroll += new System.EventHandler(this.XTrackBar_Scroll);
            // 
            // YTrackBar
            // 
            this.OptionsLayoutPanel.SetColumnSpan(this.YTrackBar, 2);
            this.YTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YTrackBar.LargeChange = 0;
            this.YTrackBar.Location = new System.Drawing.Point(3, 54);
            this.YTrackBar.Maximum = 5000;
            this.YTrackBar.Minimum = -5000;
            this.YTrackBar.Name = "YTrackBar";
            this.YTrackBar.Size = new System.Drawing.Size(126, 45);
            this.YTrackBar.TabIndex = 7;
            this.YTrackBar.Scroll += new System.EventHandler(this.YTrackBar_Scroll);
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xLabel.Location = new System.Drawing.Point(137, 5);
            this.xLabel.Margin = new System.Windows.Forms.Padding(5);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(46, 41);
            this.xLabel.TabIndex = 6;
            this.xLabel.Text = "x = 2200";
            this.xLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yLabel.Location = new System.Drawing.Point(137, 56);
            this.yLabel.Margin = new System.Windows.Forms.Padding(5);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(46, 41);
            this.yLabel.TabIndex = 5;
            this.yLabel.Text = "y = 0";
            this.yLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LightSourceStopCheckBox
            // 
            this.LightSourceStopCheckBox.AutoSize = true;
            this.LightSourceStopCheckBox.Checked = true;
            this.LightSourceStopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LightSourceStopCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LightSourceStopCheckBox.Location = new System.Drawing.Point(3, 155);
            this.LightSourceStopCheckBox.Name = "LightSourceStopCheckBox";
            this.LightSourceStopCheckBox.Size = new System.Drawing.Size(88, 44);
            this.LightSourceStopCheckBox.TabIndex = 3;
            this.LightSourceStopCheckBox.Text = "Stop Animation";
            this.LightSourceStopCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LightSourceStopCheckBox.UseVisualStyleBackColor = true;
            this.LightSourceStopCheckBox.CheckedChanged += new System.EventHandler(this.LightSourceStopTextBox_CheckedChanged);
            // 
            // ZTrackBar
            // 
            this.OptionsLayoutPanel.SetColumnSpan(this.ZTrackBar, 2);
            this.ZTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZTrackBar.LargeChange = 0;
            this.ZTrackBar.Location = new System.Drawing.Point(3, 105);
            this.ZTrackBar.Maximum = 5000;
            this.ZTrackBar.Minimum = -5000;
            this.ZTrackBar.Name = "ZTrackBar";
            this.ZTrackBar.Size = new System.Drawing.Size(126, 44);
            this.ZTrackBar.TabIndex = 2;
            this.ZTrackBar.Scroll += new System.EventHandler(this.ZTrackBar_Scroll);
            // 
            // DrawEdgesCheckBox
            // 
            this.DrawEdgesCheckBox.AutoSize = true;
            this.OptionsLayoutPanel.SetColumnSpan(this.DrawEdgesCheckBox, 2);
            this.DrawEdgesCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawEdgesCheckBox.Location = new System.Drawing.Point(97, 155);
            this.DrawEdgesCheckBox.Name = "DrawEdgesCheckBox";
            this.DrawEdgesCheckBox.Size = new System.Drawing.Size(88, 44);
            this.DrawEdgesCheckBox.TabIndex = 1;
            this.DrawEdgesCheckBox.Text = "Draw Edges";
            this.DrawEdgesCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DrawEdgesCheckBox.UseVisualStyleBackColor = true;
            this.DrawEdgesCheckBox.CheckedChanged += new System.EventHandler(this.DrawEdgesCheckBox_CheckedChanged);
            // 
            // zLabel
            // 
            this.zLabel.AutoSize = true;
            this.zLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLabel.Location = new System.Drawing.Point(137, 107);
            this.zLabel.Margin = new System.Windows.Forms.Padding(5);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(46, 40);
            this.zLabel.TabIndex = 4;
            this.zLabel.Text = "z = 0";
            this.zLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 800);
            this.Controls.Add(this.MainGroupBox);
            this.Controls.Add(this.MainPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindowForm";
            this.Text = "PolyMesh";
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.MainGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsLayoutPanel.ResumeLayout(false);
            this.OptionsLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FieldTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox MainPictureBox;
        private GroupBox MainGroupBox;
        private GroupBox OptionsGroupBox;
        private TrackBar ZTrackBar;
        private CheckBox DrawEdgesCheckBox;
        private ColorDialog MainColorDialog;
        private CheckBox LightSourceStopCheckBox;
        private TableLayoutPanel OptionsLayoutPanel;
        private Label zLabel;
        private TrackBar YTrackBar;
        private Label xLabel;
        private Label yLabel;
        private TrackBar XTrackBar;
        private TrackBar FieldTrackBar;
    }
}