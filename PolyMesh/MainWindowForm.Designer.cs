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
            this.ParamsGroupBox = new System.Windows.Forms.GroupBox();
            this.ParametersLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LightSourceColorButton = new System.Windows.Forms.Button();
            this.mTrackBar = new System.Windows.Forms.TrackBar();
            this.mLabel = new System.Windows.Forms.Label();
            this.LightColorLabel = new System.Windows.Forms.Label();
            this.ksLabel = new System.Windows.Forms.Label();
            this.kdLabel = new System.Windows.Forms.Label();
            this.ksTrackBar = new System.Windows.Forms.TrackBar();
            this.kdTrackBar = new System.Windows.Forms.TrackBar();
            this.ObjectColorButton = new System.Windows.Forms.Button();
            this.ObjectColorLabel = new System.Windows.Forms.Label();
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.OptionsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LightSourceStopCheckBox = new System.Windows.Forms.CheckBox();
            this.LightSourceZTrackBar = new System.Windows.Forms.TrackBar();
            this.DrawEdgesCheckBox = new System.Windows.Forms.CheckBox();
            this.NormalInterpolationRadioButton = new System.Windows.Forms.RadioButton();
            this.ColorInterpolationRadioButton = new System.Windows.Forms.RadioButton();
            this.zLabel = new System.Windows.Forms.Label();
            this.MainColorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.MainGroupBox.SuspendLayout();
            this.ParamsGroupBox.SuspendLayout();
            this.ParametersLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).BeginInit();
            this.OptionsGroupBox.SuspendLayout();
            this.OptionsLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceZTrackBar)).BeginInit();
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
            this.MainGroupBox.Controls.Add(this.ParamsGroupBox);
            this.MainGroupBox.Controls.Add(this.OptionsGroupBox);
            this.MainGroupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.MainGroupBox.Location = new System.Drawing.Point(806, 0);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(200, 800);
            this.MainGroupBox.TabIndex = 1;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "Controls";
            // 
            // ParamsGroupBox
            // 
            this.ParamsGroupBox.Controls.Add(this.ParametersLayoutPanel);
            this.ParamsGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ParamsGroupBox.Location = new System.Drawing.Point(3, 520);
            this.ParamsGroupBox.Name = "ParamsGroupBox";
            this.ParamsGroupBox.Size = new System.Drawing.Size(194, 277);
            this.ParamsGroupBox.TabIndex = 3;
            this.ParamsGroupBox.TabStop = false;
            this.ParamsGroupBox.Text = "Parameters";
            // 
            // ParametersLayoutPanel
            // 
            this.ParametersLayoutPanel.ColumnCount = 2;
            this.ParametersLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ParametersLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.ParametersLayoutPanel.Controls.Add(this.LightSourceColorButton, 0, 0);
            this.ParametersLayoutPanel.Controls.Add(this.mTrackBar, 0, 2);
            this.ParametersLayoutPanel.Controls.Add(this.mLabel, 1, 2);
            this.ParametersLayoutPanel.Controls.Add(this.LightColorLabel, 1, 0);
            this.ParametersLayoutPanel.Controls.Add(this.ksLabel, 1, 3);
            this.ParametersLayoutPanel.Controls.Add(this.kdLabel, 1, 4);
            this.ParametersLayoutPanel.Controls.Add(this.ksTrackBar, 0, 3);
            this.ParametersLayoutPanel.Controls.Add(this.kdTrackBar, 0, 4);
            this.ParametersLayoutPanel.Controls.Add(this.ObjectColorButton, 0, 1);
            this.ParametersLayoutPanel.Controls.Add(this.ObjectColorLabel, 1, 1);
            this.ParametersLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParametersLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.ParametersLayoutPanel.Name = "ParametersLayoutPanel";
            this.ParametersLayoutPanel.RowCount = 5;
            this.ParametersLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ParametersLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ParametersLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ParametersLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ParametersLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ParametersLayoutPanel.Size = new System.Drawing.Size(188, 255);
            this.ParametersLayoutPanel.TabIndex = 5;
            // 
            // LightSourceColorButton
            // 
            this.LightSourceColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LightSourceColorButton.Location = new System.Drawing.Point(3, 3);
            this.LightSourceColorButton.Name = "LightSourceColorButton";
            this.LightSourceColorButton.Size = new System.Drawing.Size(126, 45);
            this.LightSourceColorButton.TabIndex = 2;
            this.LightSourceColorButton.Text = "Choose Light Color";
            this.LightSourceColorButton.UseVisualStyleBackColor = true;
            this.LightSourceColorButton.Click += new System.EventHandler(this.LightSourceColorButton_Click);
            // 
            // mTrackBar
            // 
            this.mTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTrackBar.LargeChange = 1;
            this.mTrackBar.Location = new System.Drawing.Point(3, 105);
            this.mTrackBar.Maximum = 100;
            this.mTrackBar.Minimum = 1;
            this.mTrackBar.Name = "mTrackBar";
            this.mTrackBar.Size = new System.Drawing.Size(126, 45);
            this.mTrackBar.TabIndex = 3;
            this.mTrackBar.Value = 20;
            this.mTrackBar.ValueChanged += new System.EventHandler(this.mTrackBar_ValueChanged);
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mLabel.Location = new System.Drawing.Point(137, 107);
            this.mLabel.Margin = new System.Windows.Forms.Padding(5);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(46, 41);
            this.mLabel.TabIndex = 4;
            this.mLabel.Text = "m = 20";
            this.mLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LightColorLabel
            // 
            this.LightColorLabel.AutoSize = true;
            this.LightColorLabel.BackColor = System.Drawing.Color.White;
            this.LightColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LightColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LightColorLabel.Location = new System.Drawing.Point(137, 5);
            this.LightColorLabel.Margin = new System.Windows.Forms.Padding(5);
            this.LightColorLabel.Name = "LightColorLabel";
            this.LightColorLabel.Size = new System.Drawing.Size(46, 41);
            this.LightColorLabel.TabIndex = 5;
            // 
            // ksLabel
            // 
            this.ksLabel.AutoSize = true;
            this.ksLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ksLabel.Location = new System.Drawing.Point(137, 158);
            this.ksLabel.Margin = new System.Windows.Forms.Padding(5);
            this.ksLabel.Name = "ksLabel";
            this.ksLabel.Size = new System.Drawing.Size(46, 41);
            this.ksLabel.TabIndex = 6;
            this.ksLabel.Text = "ks = 1";
            this.ksLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kdLabel
            // 
            this.kdLabel.AutoSize = true;
            this.kdLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kdLabel.Location = new System.Drawing.Point(137, 209);
            this.kdLabel.Margin = new System.Windows.Forms.Padding(5);
            this.kdLabel.Name = "kdLabel";
            this.kdLabel.Size = new System.Drawing.Size(46, 41);
            this.kdLabel.TabIndex = 7;
            this.kdLabel.Text = "kd = 1";
            this.kdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ksTrackBar
            // 
            this.ksTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ksTrackBar.LargeChange = 1;
            this.ksTrackBar.Location = new System.Drawing.Point(3, 156);
            this.ksTrackBar.Maximum = 100;
            this.ksTrackBar.Name = "ksTrackBar";
            this.ksTrackBar.Size = new System.Drawing.Size(126, 45);
            this.ksTrackBar.TabIndex = 8;
            this.ksTrackBar.Value = 100;
            this.ksTrackBar.ValueChanged += new System.EventHandler(this.ksTrackBar_ValueChanged);
            // 
            // kdTrackBar
            // 
            this.kdTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kdTrackBar.LargeChange = 1;
            this.kdTrackBar.Location = new System.Drawing.Point(3, 207);
            this.kdTrackBar.Maximum = 100;
            this.kdTrackBar.Name = "kdTrackBar";
            this.kdTrackBar.Size = new System.Drawing.Size(126, 45);
            this.kdTrackBar.TabIndex = 9;
            this.kdTrackBar.Value = 100;
            this.kdTrackBar.ValueChanged += new System.EventHandler(this.kdTrackBar_ValueChanged);
            // 
            // ObjectColorButton
            // 
            this.ObjectColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectColorButton.Location = new System.Drawing.Point(3, 54);
            this.ObjectColorButton.Name = "ObjectColorButton";
            this.ObjectColorButton.Size = new System.Drawing.Size(126, 45);
            this.ObjectColorButton.TabIndex = 10;
            this.ObjectColorButton.Text = "Choose Object Color";
            this.ObjectColorButton.UseVisualStyleBackColor = true;
            this.ObjectColorButton.Click += new System.EventHandler(this.ObjectColorButton_Click);
            // 
            // ObjectColorLabel
            // 
            this.ObjectColorLabel.AutoSize = true;
            this.ObjectColorLabel.BackColor = System.Drawing.Color.Blue;
            this.ObjectColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ObjectColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectColorLabel.Location = new System.Drawing.Point(137, 56);
            this.ObjectColorLabel.Margin = new System.Windows.Forms.Padding(5);
            this.ObjectColorLabel.Name = "ObjectColorLabel";
            this.ObjectColorLabel.Size = new System.Drawing.Size(46, 41);
            this.ObjectColorLabel.TabIndex = 11;
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
            this.OptionsLayoutPanel.Controls.Add(this.LightSourceStopCheckBox, 0, 1);
            this.OptionsLayoutPanel.Controls.Add(this.LightSourceZTrackBar, 0, 0);
            this.OptionsLayoutPanel.Controls.Add(this.DrawEdgesCheckBox, 1, 1);
            this.OptionsLayoutPanel.Controls.Add(this.NormalInterpolationRadioButton, 0, 2);
            this.OptionsLayoutPanel.Controls.Add(this.ColorInterpolationRadioButton, 0, 3);
            this.OptionsLayoutPanel.Controls.Add(this.zLabel, 2, 0);
            this.OptionsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.OptionsLayoutPanel.Name = "OptionsLayoutPanel";
            this.OptionsLayoutPanel.RowCount = 4;
            this.OptionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.OptionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.OptionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.OptionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.OptionsLayoutPanel.Size = new System.Drawing.Size(188, 243);
            this.OptionsLayoutPanel.TabIndex = 4;
            // 
            // LightSourceStopCheckBox
            // 
            this.LightSourceStopCheckBox.AutoSize = true;
            this.LightSourceStopCheckBox.Checked = true;
            this.LightSourceStopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LightSourceStopCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LightSourceStopCheckBox.Location = new System.Drawing.Point(3, 74);
            this.LightSourceStopCheckBox.Name = "LightSourceStopCheckBox";
            this.LightSourceStopCheckBox.Size = new System.Drawing.Size(88, 65);
            this.LightSourceStopCheckBox.TabIndex = 3;
            this.LightSourceStopCheckBox.Text = "Stop Light Source";
            this.LightSourceStopCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LightSourceStopCheckBox.UseVisualStyleBackColor = true;
            this.LightSourceStopCheckBox.CheckedChanged += new System.EventHandler(this.LightSourceStopTextBox_CheckedChanged);
            // 
            // LightSourceZTrackBar
            // 
            this.OptionsLayoutPanel.SetColumnSpan(this.LightSourceZTrackBar, 2);
            this.LightSourceZTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LightSourceZTrackBar.LargeChange = 100;
            this.LightSourceZTrackBar.Location = new System.Drawing.Point(3, 3);
            this.LightSourceZTrackBar.Maximum = 1000;
            this.LightSourceZTrackBar.Name = "LightSourceZTrackBar";
            this.LightSourceZTrackBar.Size = new System.Drawing.Size(126, 65);
            this.LightSourceZTrackBar.TabIndex = 2;
            this.LightSourceZTrackBar.Value = 500;
            this.LightSourceZTrackBar.Scroll += new System.EventHandler(this.LightSourceZTrackBar_Scroll);
            // 
            // DrawEdgesCheckBox
            // 
            this.DrawEdgesCheckBox.AutoSize = true;
            this.OptionsLayoutPanel.SetColumnSpan(this.DrawEdgesCheckBox, 2);
            this.DrawEdgesCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawEdgesCheckBox.Location = new System.Drawing.Point(97, 74);
            this.DrawEdgesCheckBox.Name = "DrawEdgesCheckBox";
            this.DrawEdgesCheckBox.Size = new System.Drawing.Size(88, 65);
            this.DrawEdgesCheckBox.TabIndex = 1;
            this.DrawEdgesCheckBox.Text = "Draw Edges";
            this.DrawEdgesCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DrawEdgesCheckBox.UseVisualStyleBackColor = true;
            this.DrawEdgesCheckBox.CheckedChanged += new System.EventHandler(this.DrawEdgesCheckBox_CheckedChanged);
            // 
            // NormalInterpolationRadioButton
            // 
            this.NormalInterpolationRadioButton.AutoSize = true;
            this.NormalInterpolationRadioButton.Checked = true;
            this.OptionsLayoutPanel.SetColumnSpan(this.NormalInterpolationRadioButton, 3);
            this.NormalInterpolationRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NormalInterpolationRadioButton.Location = new System.Drawing.Point(3, 145);
            this.NormalInterpolationRadioButton.Name = "NormalInterpolationRadioButton";
            this.NormalInterpolationRadioButton.Size = new System.Drawing.Size(182, 44);
            this.NormalInterpolationRadioButton.TabIndex = 5;
            this.NormalInterpolationRadioButton.TabStop = true;
            this.NormalInterpolationRadioButton.Text = "Normal vector interpolation";
            this.NormalInterpolationRadioButton.UseVisualStyleBackColor = true;
            this.NormalInterpolationRadioButton.CheckedChanged += new System.EventHandler(this.NormalInterpolationRadioButton_CheckedChanged);
            // 
            // ColorInterpolationRadioButton
            // 
            this.ColorInterpolationRadioButton.AutoSize = true;
            this.OptionsLayoutPanel.SetColumnSpan(this.ColorInterpolationRadioButton, 3);
            this.ColorInterpolationRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorInterpolationRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ColorInterpolationRadioButton.Location = new System.Drawing.Point(3, 195);
            this.ColorInterpolationRadioButton.Name = "ColorInterpolationRadioButton";
            this.ColorInterpolationRadioButton.Size = new System.Drawing.Size(182, 45);
            this.ColorInterpolationRadioButton.TabIndex = 6;
            this.ColorInterpolationRadioButton.Text = "Color interpolation";
            this.ColorInterpolationRadioButton.UseVisualStyleBackColor = true;
            // 
            // zLabel
            // 
            this.zLabel.AutoSize = true;
            this.zLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLabel.Location = new System.Drawing.Point(137, 5);
            this.zLabel.Margin = new System.Windows.Forms.Padding(5);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(46, 61);
            this.zLabel.TabIndex = 4;
            this.zLabel.Text = "z = 500";
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
            this.ParamsGroupBox.ResumeLayout(false);
            this.ParametersLayoutPanel.ResumeLayout(false);
            this.ParametersLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).EndInit();
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsLayoutPanel.ResumeLayout(false);
            this.OptionsLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceZTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox MainPictureBox;
        private GroupBox MainGroupBox;
        private GroupBox OptionsGroupBox;
        private TrackBar LightSourceZTrackBar;
        private CheckBox DrawEdgesCheckBox;
        private Button LightSourceColorButton;
        private ColorDialog MainColorDialog;
        private GroupBox ParamsGroupBox;
        private TrackBar mTrackBar;
        private Label mLabel;
        private TableLayoutPanel ParametersLayoutPanel;
        private Label LightColorLabel;
        private Label ksLabel;
        private Label kdLabel;
        private TrackBar ksTrackBar;
        private TrackBar kdTrackBar;
        private CheckBox LightSourceStopCheckBox;
        private TableLayoutPanel OptionsLayoutPanel;
        private Label zLabel;
        private RadioButton NormalInterpolationRadioButton;
        private RadioButton ColorInterpolationRadioButton;
        private Button ObjectColorButton;
        private Label ObjectColorLabel;
    }
}