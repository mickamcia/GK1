namespace PolyDraw
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
            this.ControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.EditLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DeleteVertexButton = new System.Windows.Forms.Button();
            this.DeletePolygonButton = new System.Windows.Forms.Button();
            this.EditRadioButton = new System.Windows.Forms.RadioButton();
            this.CreateRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.ControlsGroupBox.SuspendLayout();
            this.EditLayoutPanel.SuspendLayout();
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
            this.MainPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseClick);
            this.MainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseMove);
            // 
            // ControlsGroupBox
            // 
            this.ControlsGroupBox.Controls.Add(this.EditLayoutPanel);
            this.ControlsGroupBox.Controls.Add(this.EditRadioButton);
            this.ControlsGroupBox.Controls.Add(this.CreateRadioButton);
            this.ControlsGroupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.ControlsGroupBox.Location = new System.Drawing.Point(806, 0);
            this.ControlsGroupBox.Name = "ControlsGroupBox";
            this.ControlsGroupBox.Size = new System.Drawing.Size(200, 800);
            this.ControlsGroupBox.TabIndex = 1;
            this.ControlsGroupBox.TabStop = false;
            this.ControlsGroupBox.Text = "Controls";
            // 
            // EditLayoutPanel
            // 
            this.EditLayoutPanel.ColumnCount = 2;
            this.EditLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.EditLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.EditLayoutPanel.Controls.Add(this.DeleteVertexButton, 0, 0);
            this.EditLayoutPanel.Controls.Add(this.DeletePolygonButton, 1, 0);
            this.EditLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditLayoutPanel.Location = new System.Drawing.Point(3, 99);
            this.EditLayoutPanel.Name = "EditLayoutPanel";
            this.EditLayoutPanel.RowCount = 1;
            this.EditLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.EditLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.EditLayoutPanel.Size = new System.Drawing.Size(194, 60);
            this.EditLayoutPanel.TabIndex = 4;
            // 
            // DeleteVertexButton
            // 
            this.DeleteVertexButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteVertexButton.Enabled = false;
            this.DeleteVertexButton.Location = new System.Drawing.Point(3, 3);
            this.DeleteVertexButton.Name = "DeleteVertexButton";
            this.DeleteVertexButton.Size = new System.Drawing.Size(91, 54);
            this.DeleteVertexButton.TabIndex = 0;
            this.DeleteVertexButton.Text = "Delete Selected Vertex";
            this.DeleteVertexButton.UseVisualStyleBackColor = true;
            this.DeleteVertexButton.Click += new System.EventHandler(this.DeleteVertexButton_Click);
            // 
            // DeletePolygonButton
            // 
            this.DeletePolygonButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeletePolygonButton.Enabled = false;
            this.DeletePolygonButton.Location = new System.Drawing.Point(100, 3);
            this.DeletePolygonButton.Name = "DeletePolygonButton";
            this.DeletePolygonButton.Size = new System.Drawing.Size(91, 54);
            this.DeletePolygonButton.TabIndex = 1;
            this.DeletePolygonButton.Text = "Delete Selected Polygon";
            this.DeletePolygonButton.UseVisualStyleBackColor = true;
            this.DeletePolygonButton.Click += new System.EventHandler(this.DeletePolygonButton_Click);
            // 
            // EditRadioButton
            // 
            this.EditRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditRadioButton.Location = new System.Drawing.Point(3, 59);
            this.EditRadioButton.Name = "EditRadioButton";
            this.EditRadioButton.Size = new System.Drawing.Size(194, 40);
            this.EditRadioButton.TabIndex = 1;
            this.EditRadioButton.TabStop = true;
            this.EditRadioButton.Text = "Edit existing polygons";
            this.EditRadioButton.UseVisualStyleBackColor = true;
            this.EditRadioButton.CheckedChanged += new System.EventHandler(this.EditRadioButton_CheckedChanged);
            // 
            // CreateRadioButton
            // 
            this.CreateRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateRadioButton.Location = new System.Drawing.Point(3, 19);
            this.CreateRadioButton.Name = "CreateRadioButton";
            this.CreateRadioButton.Size = new System.Drawing.Size(194, 40);
            this.CreateRadioButton.TabIndex = 0;
            this.CreateRadioButton.TabStop = true;
            this.CreateRadioButton.Text = "Create new polygons";
            this.CreateRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 800);
            this.Controls.Add(this.ControlsGroupBox);
            this.Controls.Add(this.MainPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindowForm";
            this.Text = "PolyDraw";
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.ControlsGroupBox.ResumeLayout(false);
            this.EditLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox MainPictureBox;
        private GroupBox ControlsGroupBox;
        private RadioButton EditRadioButton;
        private RadioButton CreateRadioButton;
        private TableLayoutPanel EditLayoutPanel;
        private Button DeleteVertexButton;
        private Button DeletePolygonButton;
    }
}