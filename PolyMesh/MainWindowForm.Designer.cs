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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LightSourceColorButton = new System.Windows.Forms.Button();
            this.mTrackBar = new System.Windows.Forms.TrackBar();
            this.mLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.ksLabel = new System.Windows.Forms.Label();
            this.kdLabel = new System.Windows.Forms.Label();
            this.ksTrackBar = new System.Windows.Forms.TrackBar();
            this.kdTrackBar = new System.Windows.Forms.TrackBar();
            this.DrawEdgesCheckBox = new System.Windows.Forms.CheckBox();
            this.LightSourceControlGroupBox = new System.Windows.Forms.GroupBox();
            this.LightSourceStopCheckBox = new System.Windows.Forms.CheckBox();
            this.LightSourceZTrackBar = new System.Windows.Forms.TrackBar();
            this.LightSourceColorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.MainGroupBox.SuspendLayout();
            this.ParamsGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).BeginInit();
            this.LightSourceControlGroupBox.SuspendLayout();
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
            this.MainGroupBox.Controls.Add(this.LightSourceControlGroupBox);
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
            this.ParamsGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.ParamsGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ParamsGroupBox.Location = new System.Drawing.Point(3, 520);
            this.ParamsGroupBox.Name = "ParamsGroupBox";
            this.ParamsGroupBox.Size = new System.Drawing.Size(194, 277);
            this.ParamsGroupBox.TabIndex = 3;
            this.ParamsGroupBox.TabStop = false;
            this.ParamsGroupBox.Text = "Parameters";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.Controls.Add(this.LightSourceColorButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mTrackBar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.mLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.colorLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ksLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.kdLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ksTrackBar, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.kdTrackBar, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(188, 255);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // LightSourceColorButton
            // 
            this.LightSourceColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LightSourceColorButton.Location = new System.Drawing.Point(3, 3);
            this.LightSourceColorButton.Name = "LightSourceColorButton";
            this.LightSourceColorButton.Size = new System.Drawing.Size(126, 45);
            this.LightSourceColorButton.TabIndex = 2;
            this.LightSourceColorButton.Text = "Choose Color";
            this.LightSourceColorButton.UseVisualStyleBackColor = true;
            this.LightSourceColorButton.Click += new System.EventHandler(this.LightSourceColorButton_Click);
            // 
            // mTrackBar
            // 
            this.mTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTrackBar.LargeChange = 1;
            this.mTrackBar.Location = new System.Drawing.Point(3, 54);
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
            this.mLabel.Location = new System.Drawing.Point(137, 56);
            this.mLabel.Margin = new System.Windows.Forms.Padding(5);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(46, 41);
            this.mLabel.TabIndex = 4;
            this.mLabel.Text = "m = 20";
            this.mLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorLabel.Location = new System.Drawing.Point(137, 5);
            this.colorLabel.Margin = new System.Windows.Forms.Padding(5);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(46, 41);
            this.colorLabel.TabIndex = 5;
            // 
            // ksLabel
            // 
            this.ksLabel.AutoSize = true;
            this.ksLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ksLabel.Location = new System.Drawing.Point(137, 107);
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
            this.kdLabel.Location = new System.Drawing.Point(137, 158);
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
            this.ksTrackBar.Location = new System.Drawing.Point(3, 105);
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
            this.kdTrackBar.Location = new System.Drawing.Point(3, 156);
            this.kdTrackBar.Maximum = 100;
            this.kdTrackBar.Name = "kdTrackBar";
            this.kdTrackBar.Size = new System.Drawing.Size(126, 45);
            this.kdTrackBar.TabIndex = 9;
            this.kdTrackBar.Value = 100;
            this.kdTrackBar.ValueChanged += new System.EventHandler(this.kdTrackBar_ValueChanged);
            // 
            // DrawEdgesCheckBox
            // 
            this.DrawEdgesCheckBox.AutoSize = true;
            this.DrawEdgesCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.DrawEdgesCheckBox.Location = new System.Drawing.Point(3, 64);
            this.DrawEdgesCheckBox.Name = "DrawEdgesCheckBox";
            this.DrawEdgesCheckBox.Size = new System.Drawing.Size(188, 19);
            this.DrawEdgesCheckBox.TabIndex = 1;
            this.DrawEdgesCheckBox.Text = "Draw Edges";
            this.DrawEdgesCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DrawEdgesCheckBox.UseVisualStyleBackColor = true;
            this.DrawEdgesCheckBox.CheckedChanged += new System.EventHandler(this.DrawEdgesCheckBox_CheckedChanged);
            // 
            // LightSourceControlGroupBox
            // 
            this.LightSourceControlGroupBox.Controls.Add(this.LightSourceStopCheckBox);
            this.LightSourceControlGroupBox.Controls.Add(this.DrawEdgesCheckBox);
            this.LightSourceControlGroupBox.Controls.Add(this.LightSourceZTrackBar);
            this.LightSourceControlGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.LightSourceControlGroupBox.Location = new System.Drawing.Point(3, 19);
            this.LightSourceControlGroupBox.Name = "LightSourceControlGroupBox";
            this.LightSourceControlGroupBox.Size = new System.Drawing.Size(194, 265);
            this.LightSourceControlGroupBox.TabIndex = 0;
            this.LightSourceControlGroupBox.TabStop = false;
            this.LightSourceControlGroupBox.Text = "Light Source";
            // 
            // LightSourceStopCheckBox
            // 
            this.LightSourceStopCheckBox.AutoSize = true;
            this.LightSourceStopCheckBox.Checked = true;
            this.LightSourceStopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LightSourceStopCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.LightSourceStopCheckBox.Location = new System.Drawing.Point(3, 83);
            this.LightSourceStopCheckBox.Name = "LightSourceStopCheckBox";
            this.LightSourceStopCheckBox.Size = new System.Drawing.Size(188, 19);
            this.LightSourceStopCheckBox.TabIndex = 3;
            this.LightSourceStopCheckBox.Text = "Stop Light Source";
            this.LightSourceStopCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LightSourceStopCheckBox.UseVisualStyleBackColor = true;
            this.LightSourceStopCheckBox.CheckedChanged += new System.EventHandler(this.LightSourceStopTextBox_CheckedChanged);
            // 
            // LightSourceZTrackBar
            // 
            this.LightSourceZTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.LightSourceZTrackBar.LargeChange = 100;
            this.LightSourceZTrackBar.Location = new System.Drawing.Point(3, 19);
            this.LightSourceZTrackBar.Maximum = 1000;
            this.LightSourceZTrackBar.Name = "LightSourceZTrackBar";
            this.LightSourceZTrackBar.Size = new System.Drawing.Size(188, 45);
            this.LightSourceZTrackBar.TabIndex = 2;
            this.LightSourceZTrackBar.Value = 500;
            this.LightSourceZTrackBar.Scroll += new System.EventHandler(this.LightSourceZTrackBar_Scroll);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).EndInit();
            this.LightSourceControlGroupBox.ResumeLayout(false);
            this.LightSourceControlGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceZTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox MainPictureBox;
        private GroupBox MainGroupBox;
        private GroupBox LightSourceControlGroupBox;
        private TrackBar LightSourceZTrackBar;
        private CheckBox DrawEdgesCheckBox;
        private Button LightSourceColorButton;
        private ColorDialog LightSourceColorDialog;
        private GroupBox ParamsGroupBox;
        private TrackBar mTrackBar;
        private Label mLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private Label colorLabel;
        private Label ksLabel;
        private Label kdLabel;
        private TrackBar ksTrackBar;
        private TrackBar kdTrackBar;
        private CheckBox LightSourceStopCheckBox;
    }
}