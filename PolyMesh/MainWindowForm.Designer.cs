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
            this.LightSourceControlGroupBox = new System.Windows.Forms.GroupBox();
            this.LightSourceZTrackBar = new System.Windows.Forms.TrackBar();
            this.LightSourceYTrackBar = new System.Windows.Forms.TrackBar();
            this.LightSourceXTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.MainGroupBox.SuspendLayout();
            this.LightSourceControlGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceZTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceYTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceXTrackBar)).BeginInit();
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
            this.MainGroupBox.Controls.Add(this.LightSourceControlGroupBox);
            this.MainGroupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.MainGroupBox.Location = new System.Drawing.Point(806, 0);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(200, 800);
            this.MainGroupBox.TabIndex = 1;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "Controls";
            // 
            // LightSourceControlGroupBox
            // 
            this.LightSourceControlGroupBox.Controls.Add(this.LightSourceZTrackBar);
            this.LightSourceControlGroupBox.Controls.Add(this.LightSourceYTrackBar);
            this.LightSourceControlGroupBox.Controls.Add(this.LightSourceXTrackBar);
            this.LightSourceControlGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.LightSourceControlGroupBox.Location = new System.Drawing.Point(3, 19);
            this.LightSourceControlGroupBox.Name = "LightSourceControlGroupBox";
            this.LightSourceControlGroupBox.Size = new System.Drawing.Size(194, 265);
            this.LightSourceControlGroupBox.TabIndex = 0;
            this.LightSourceControlGroupBox.TabStop = false;
            this.LightSourceControlGroupBox.Text = "Light Source";
            // 
            // LightSourceZTrackBar
            // 
            this.LightSourceZTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.LightSourceZTrackBar.LargeChange = 100;
            this.LightSourceZTrackBar.Location = new System.Drawing.Point(3, 109);
            this.LightSourceZTrackBar.Maximum = 1000;
            this.LightSourceZTrackBar.Minimum = -1000;
            this.LightSourceZTrackBar.Name = "LightSourceZTrackBar";
            this.LightSourceZTrackBar.Size = new System.Drawing.Size(188, 45);
            this.LightSourceZTrackBar.TabIndex = 2;
            this.LightSourceZTrackBar.Scroll += new System.EventHandler(this.LightSourceZTrackBar_Scroll);
            // 
            // LightSourceYTrackBar
            // 
            this.LightSourceYTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.LightSourceYTrackBar.LargeChange = 100;
            this.LightSourceYTrackBar.Location = new System.Drawing.Point(3, 64);
            this.LightSourceYTrackBar.Maximum = 1000;
            this.LightSourceYTrackBar.Minimum = -1000;
            this.LightSourceYTrackBar.Name = "LightSourceYTrackBar";
            this.LightSourceYTrackBar.Size = new System.Drawing.Size(188, 45);
            this.LightSourceYTrackBar.TabIndex = 1;
            this.LightSourceYTrackBar.Scroll += new System.EventHandler(this.LightSourceYTrackBar_Scroll);
            // 
            // LightSourceXTrackBar
            // 
            this.LightSourceXTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.LightSourceXTrackBar.LargeChange = 100;
            this.LightSourceXTrackBar.Location = new System.Drawing.Point(3, 19);
            this.LightSourceXTrackBar.Maximum = 1000;
            this.LightSourceXTrackBar.Minimum = -1000;
            this.LightSourceXTrackBar.Name = "LightSourceXTrackBar";
            this.LightSourceXTrackBar.Size = new System.Drawing.Size(188, 45);
            this.LightSourceXTrackBar.TabIndex = 0;
            this.LightSourceXTrackBar.Scroll += new System.EventHandler(this.LightSourceXTrackBar_Scroll);
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
            this.LightSourceControlGroupBox.ResumeLayout(false);
            this.LightSourceControlGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceZTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceYTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceXTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox MainPictureBox;
        private GroupBox MainGroupBox;
        private GroupBox LightSourceControlGroupBox;
        private TrackBar LightSourceZTrackBar;
        private TrackBar LightSourceYTrackBar;
        private TrackBar LightSourceXTrackBar;
    }
}