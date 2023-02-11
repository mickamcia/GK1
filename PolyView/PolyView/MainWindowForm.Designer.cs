namespace PolyView
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.OptionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CameraGroupBox = new System.Windows.Forms.GroupBox();
            this.CameraTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CameraOnCenterRadioButton = new System.Windows.Forms.RadioButton();
            this.CameraOnStationaryObjectRadioButton = new System.Windows.Forms.RadioButton();
            this.CameraOnMovingObjectRadioButton = new System.Windows.Forms.RadioButton();
            this.ShadingGroupBox = new System.Windows.Forms.GroupBox();
            this.ShadingTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ShadingConstantRadioButton = new System.Windows.Forms.RadioButton();
            this.ShadingGouraudRadioButton = new System.Windows.Forms.RadioButton();
            this.ShadingPhongRadioButton = new System.Windows.Forms.RadioButton();
            this.LightingGroupBox = new System.Windows.Forms.GroupBox();
            this.LightingTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LightOnMovingObjectCheckBox = new System.Windows.Forms.CheckBox();
            this.LightOnStationaryObjectCheckBox = new System.Windows.Forms.CheckBox();
            this.LightingDaylightCheckBox = new System.Windows.Forms.CheckBox();
            this.LightingFogCheckBox = new System.Windows.Forms.CheckBox();
            this.MainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.OptionsTableLayoutPanel.SuspendLayout();
            this.CameraGroupBox.SuspendLayout();
            this.CameraTableLayoutPanel.SuspendLayout();
            this.ShadingGroupBox.SuspendLayout();
            this.ShadingTableLayoutPanel.SuspendLayout();
            this.LightingGroupBox.SuspendLayout();
            this.LightingTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 2;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 806F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.MainPictureBox, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.OptionsTableLayoutPanel, 1, 0);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 1;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(1012, 806);
            this.MainTableLayoutPanel.TabIndex = 1;
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPictureBox.Location = new System.Drawing.Point(3, 3);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(800, 800);
            this.MainPictureBox.TabIndex = 1;
            this.MainPictureBox.TabStop = false;
            this.MainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPictureBox_Paint);
            // 
            // OptionsTableLayoutPanel
            // 
            this.OptionsTableLayoutPanel.ColumnCount = 1;
            this.OptionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OptionsTableLayoutPanel.Controls.Add(this.CameraGroupBox, 0, 0);
            this.OptionsTableLayoutPanel.Controls.Add(this.ShadingGroupBox, 0, 1);
            this.OptionsTableLayoutPanel.Controls.Add(this.LightingGroupBox, 0, 2);
            this.OptionsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsTableLayoutPanel.Location = new System.Drawing.Point(809, 3);
            this.OptionsTableLayoutPanel.Name = "OptionsTableLayoutPanel";
            this.OptionsTableLayoutPanel.RowCount = 4;
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.OptionsTableLayoutPanel.Size = new System.Drawing.Size(200, 800);
            this.OptionsTableLayoutPanel.TabIndex = 2;
            // 
            // CameraGroupBox
            // 
            this.CameraGroupBox.Controls.Add(this.CameraTableLayoutPanel);
            this.CameraGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraGroupBox.Location = new System.Drawing.Point(3, 3);
            this.CameraGroupBox.Name = "CameraGroupBox";
            this.CameraGroupBox.Size = new System.Drawing.Size(194, 114);
            this.CameraGroupBox.TabIndex = 0;
            this.CameraGroupBox.TabStop = false;
            this.CameraGroupBox.Text = "Camera";
            // 
            // CameraTableLayoutPanel
            // 
            this.CameraTableLayoutPanel.ColumnCount = 1;
            this.CameraTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CameraTableLayoutPanel.Controls.Add(this.CameraOnCenterRadioButton, 0, 0);
            this.CameraTableLayoutPanel.Controls.Add(this.CameraOnStationaryObjectRadioButton, 0, 1);
            this.CameraTableLayoutPanel.Controls.Add(this.CameraOnMovingObjectRadioButton, 0, 2);
            this.CameraTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraTableLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.CameraTableLayoutPanel.Name = "CameraTableLayoutPanel";
            this.CameraTableLayoutPanel.RowCount = 3;
            this.CameraTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CameraTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CameraTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CameraTableLayoutPanel.Size = new System.Drawing.Size(188, 92);
            this.CameraTableLayoutPanel.TabIndex = 0;
            // 
            // CameraOnCenterRadioButton
            // 
            this.CameraOnCenterRadioButton.AutoSize = true;
            this.CameraOnCenterRadioButton.Checked = true;
            this.CameraOnCenterRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraOnCenterRadioButton.Location = new System.Drawing.Point(3, 3);
            this.CameraOnCenterRadioButton.Name = "CameraOnCenterRadioButton";
            this.CameraOnCenterRadioButton.Size = new System.Drawing.Size(182, 24);
            this.CameraOnCenterRadioButton.TabIndex = 0;
            this.CameraOnCenterRadioButton.TabStop = true;
            this.CameraOnCenterRadioButton.Text = "On Center";
            this.CameraOnCenterRadioButton.UseVisualStyleBackColor = true;
            this.CameraOnCenterRadioButton.CheckedChanged += new System.EventHandler(this.CameraOnCenterRadioButton_CheckedChanged);
            // 
            // CameraOnStationaryObjectRadioButton
            // 
            this.CameraOnStationaryObjectRadioButton.AutoSize = true;
            this.CameraOnStationaryObjectRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraOnStationaryObjectRadioButton.Location = new System.Drawing.Point(3, 33);
            this.CameraOnStationaryObjectRadioButton.Name = "CameraOnStationaryObjectRadioButton";
            this.CameraOnStationaryObjectRadioButton.Size = new System.Drawing.Size(182, 24);
            this.CameraOnStationaryObjectRadioButton.TabIndex = 1;
            this.CameraOnStationaryObjectRadioButton.Text = "On Stationary Object";
            this.CameraOnStationaryObjectRadioButton.UseVisualStyleBackColor = true;
            this.CameraOnStationaryObjectRadioButton.CheckedChanged += new System.EventHandler(this.CameraOnStationaryObjectRadioButton_CheckedChanged);
            // 
            // CameraOnMovingObjectRadioButton
            // 
            this.CameraOnMovingObjectRadioButton.AutoSize = true;
            this.CameraOnMovingObjectRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraOnMovingObjectRadioButton.Location = new System.Drawing.Point(3, 63);
            this.CameraOnMovingObjectRadioButton.Name = "CameraOnMovingObjectRadioButton";
            this.CameraOnMovingObjectRadioButton.Size = new System.Drawing.Size(182, 26);
            this.CameraOnMovingObjectRadioButton.TabIndex = 2;
            this.CameraOnMovingObjectRadioButton.Text = "On Moving Object";
            this.CameraOnMovingObjectRadioButton.UseVisualStyleBackColor = true;
            this.CameraOnMovingObjectRadioButton.CheckedChanged += new System.EventHandler(this.CameraOnMovingObjectRadioButton_CheckedChanged);
            // 
            // ShadingGroupBox
            // 
            this.ShadingGroupBox.Controls.Add(this.ShadingTableLayoutPanel);
            this.ShadingGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShadingGroupBox.Location = new System.Drawing.Point(3, 123);
            this.ShadingGroupBox.Name = "ShadingGroupBox";
            this.ShadingGroupBox.Size = new System.Drawing.Size(194, 114);
            this.ShadingGroupBox.TabIndex = 1;
            this.ShadingGroupBox.TabStop = false;
            this.ShadingGroupBox.Text = "Shading";
            // 
            // ShadingTableLayoutPanel
            // 
            this.ShadingTableLayoutPanel.ColumnCount = 1;
            this.ShadingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ShadingTableLayoutPanel.Controls.Add(this.ShadingConstantRadioButton, 0, 0);
            this.ShadingTableLayoutPanel.Controls.Add(this.ShadingGouraudRadioButton, 0, 1);
            this.ShadingTableLayoutPanel.Controls.Add(this.ShadingPhongRadioButton, 0, 2);
            this.ShadingTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShadingTableLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.ShadingTableLayoutPanel.Name = "ShadingTableLayoutPanel";
            this.ShadingTableLayoutPanel.RowCount = 3;
            this.ShadingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ShadingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ShadingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ShadingTableLayoutPanel.Size = new System.Drawing.Size(188, 92);
            this.ShadingTableLayoutPanel.TabIndex = 0;
            // 
            // ShadingConstantRadioButton
            // 
            this.ShadingConstantRadioButton.AutoSize = true;
            this.ShadingConstantRadioButton.Checked = true;
            this.ShadingConstantRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShadingConstantRadioButton.Location = new System.Drawing.Point(3, 3);
            this.ShadingConstantRadioButton.Name = "ShadingConstantRadioButton";
            this.ShadingConstantRadioButton.Size = new System.Drawing.Size(182, 24);
            this.ShadingConstantRadioButton.TabIndex = 0;
            this.ShadingConstantRadioButton.TabStop = true;
            this.ShadingConstantRadioButton.Text = "Constant";
            this.ShadingConstantRadioButton.UseVisualStyleBackColor = true;
            // 
            // ShadingGouraudRadioButton
            // 
            this.ShadingGouraudRadioButton.AutoSize = true;
            this.ShadingGouraudRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShadingGouraudRadioButton.Location = new System.Drawing.Point(3, 33);
            this.ShadingGouraudRadioButton.Name = "ShadingGouraudRadioButton";
            this.ShadingGouraudRadioButton.Size = new System.Drawing.Size(182, 24);
            this.ShadingGouraudRadioButton.TabIndex = 1;
            this.ShadingGouraudRadioButton.Text = "Gouraud";
            this.ShadingGouraudRadioButton.UseVisualStyleBackColor = true;
            // 
            // ShadingPhongRadioButton
            // 
            this.ShadingPhongRadioButton.AutoSize = true;
            this.ShadingPhongRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShadingPhongRadioButton.Location = new System.Drawing.Point(3, 63);
            this.ShadingPhongRadioButton.Name = "ShadingPhongRadioButton";
            this.ShadingPhongRadioButton.Size = new System.Drawing.Size(182, 26);
            this.ShadingPhongRadioButton.TabIndex = 2;
            this.ShadingPhongRadioButton.Text = "Phong";
            this.ShadingPhongRadioButton.UseVisualStyleBackColor = true;
            // 
            // LightingGroupBox
            // 
            this.LightingGroupBox.Controls.Add(this.LightingTableLayoutPanel);
            this.LightingGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LightingGroupBox.Location = new System.Drawing.Point(3, 243);
            this.LightingGroupBox.Name = "LightingGroupBox";
            this.LightingGroupBox.Size = new System.Drawing.Size(194, 154);
            this.LightingGroupBox.TabIndex = 2;
            this.LightingGroupBox.TabStop = false;
            this.LightingGroupBox.Text = "Lighting";
            // 
            // LightingTableLayoutPanel
            // 
            this.LightingTableLayoutPanel.ColumnCount = 1;
            this.LightingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LightingTableLayoutPanel.Controls.Add(this.LightOnMovingObjectCheckBox, 0, 0);
            this.LightingTableLayoutPanel.Controls.Add(this.LightOnStationaryObjectCheckBox, 0, 1);
            this.LightingTableLayoutPanel.Controls.Add(this.LightingDaylightCheckBox, 0, 2);
            this.LightingTableLayoutPanel.Controls.Add(this.LightingFogCheckBox, 0, 3);
            this.LightingTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LightingTableLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.LightingTableLayoutPanel.Name = "LightingTableLayoutPanel";
            this.LightingTableLayoutPanel.RowCount = 4;
            this.LightingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LightingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LightingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LightingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LightingTableLayoutPanel.Size = new System.Drawing.Size(188, 132);
            this.LightingTableLayoutPanel.TabIndex = 0;
            // 
            // LightOnMovingObjectCheckBox
            // 
            this.LightOnMovingObjectCheckBox.AutoSize = true;
            this.LightOnMovingObjectCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LightOnMovingObjectCheckBox.Location = new System.Drawing.Point(3, 3);
            this.LightOnMovingObjectCheckBox.Name = "LightOnMovingObjectCheckBox";
            this.LightOnMovingObjectCheckBox.Size = new System.Drawing.Size(182, 27);
            this.LightOnMovingObjectCheckBox.TabIndex = 0;
            this.LightOnMovingObjectCheckBox.Text = "On Moving Object";
            this.LightOnMovingObjectCheckBox.UseVisualStyleBackColor = true;
            this.LightOnMovingObjectCheckBox.CheckedChanged += new System.EventHandler(this.LightOnMovingObjectCheckBox_CheckedChanged);
            // 
            // LightOnStationaryObjectCheckBox
            // 
            this.LightOnStationaryObjectCheckBox.AutoSize = true;
            this.LightOnStationaryObjectCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LightOnStationaryObjectCheckBox.Location = new System.Drawing.Point(3, 36);
            this.LightOnStationaryObjectCheckBox.Name = "LightOnStationaryObjectCheckBox";
            this.LightOnStationaryObjectCheckBox.Size = new System.Drawing.Size(182, 27);
            this.LightOnStationaryObjectCheckBox.TabIndex = 1;
            this.LightOnStationaryObjectCheckBox.Text = "On Stationary Object";
            this.LightOnStationaryObjectCheckBox.UseVisualStyleBackColor = true;
            this.LightOnStationaryObjectCheckBox.CheckedChanged += new System.EventHandler(this.LightOnStationaryObjectCheckBox_CheckedChanged);
            // 
            // LightingDaylightCheckBox
            // 
            this.LightingDaylightCheckBox.AutoSize = true;
            this.LightingDaylightCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LightingDaylightCheckBox.Location = new System.Drawing.Point(3, 69);
            this.LightingDaylightCheckBox.Name = "LightingDaylightCheckBox";
            this.LightingDaylightCheckBox.Size = new System.Drawing.Size(182, 27);
            this.LightingDaylightCheckBox.TabIndex = 2;
            this.LightingDaylightCheckBox.Text = "Daylight";
            this.LightingDaylightCheckBox.UseVisualStyleBackColor = true;
            this.LightingDaylightCheckBox.CheckedChanged += new System.EventHandler(this.LightingDaylightCheckBox_CheckedChanged);
            // 
            // LightingFogCheckBox
            // 
            this.LightingFogCheckBox.AutoSize = true;
            this.LightingFogCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LightingFogCheckBox.Location = new System.Drawing.Point(3, 102);
            this.LightingFogCheckBox.Name = "LightingFogCheckBox";
            this.LightingFogCheckBox.Size = new System.Drawing.Size(182, 27);
            this.LightingFogCheckBox.TabIndex = 3;
            this.LightingFogCheckBox.Text = "Fog";
            this.LightingFogCheckBox.UseVisualStyleBackColor = true;
            this.LightingFogCheckBox.CheckedChanged += new System.EventHandler(this.LightingFogCheckBox_CheckedChanged);
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 806);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindowForm";
            this.Text = "PolyView";
            this.MainTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.OptionsTableLayoutPanel.ResumeLayout(false);
            this.CameraGroupBox.ResumeLayout(false);
            this.CameraTableLayoutPanel.ResumeLayout(false);
            this.CameraTableLayoutPanel.PerformLayout();
            this.ShadingGroupBox.ResumeLayout(false);
            this.ShadingTableLayoutPanel.ResumeLayout(false);
            this.ShadingTableLayoutPanel.PerformLayout();
            this.LightingGroupBox.ResumeLayout(false);
            this.LightingTableLayoutPanel.ResumeLayout(false);
            this.LightingTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private TableLayoutPanel MainTableLayoutPanel;
        private PictureBox MainPictureBox;
        private TableLayoutPanel OptionsTableLayoutPanel;
        private GroupBox CameraGroupBox;
        private TableLayoutPanel CameraTableLayoutPanel;
        private RadioButton CameraOnCenterRadioButton;
        private RadioButton CameraOnStationaryObjectRadioButton;
        private RadioButton CameraOnMovingObjectRadioButton;
        private GroupBox ShadingGroupBox;
        private TableLayoutPanel ShadingTableLayoutPanel;
        private RadioButton ShadingConstantRadioButton;
        private RadioButton ShadingGouraudRadioButton;
        private RadioButton ShadingPhongRadioButton;
        private GroupBox LightingGroupBox;
        private TableLayoutPanel LightingTableLayoutPanel;
        private CheckBox LightOnMovingObjectCheckBox;
        private CheckBox LightOnStationaryObjectCheckBox;
        private CheckBox LightingDaylightCheckBox;
        private CheckBox LightingFogCheckBox;
    }
}