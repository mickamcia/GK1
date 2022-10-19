﻿namespace PolyDraw
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
            this.ButtonControls = new System.Windows.Forms.TableLayoutPanel();
            this.RemoveVertexButton = new System.Windows.Forms.Button();
            this.RemoveEdgeButton = new System.Windows.Forms.Button();
            this.RemovePolygonButton = new System.Windows.Forms.Button();
            this.RemoveAllButton = new System.Windows.Forms.Button();
            this.DivideEdgeButton = new System.Windows.Forms.Button();
            this.RandomPolygonButton = new System.Windows.Forms.Button();
            this.BasicControls = new System.Windows.Forms.TableLayoutPanel();
            this.CreateRadioButton = new System.Windows.Forms.RadioButton();
            this.MoveRadioButton = new System.Windows.Forms.RadioButton();
            this.LineControls = new System.Windows.Forms.TableLayoutPanel();
            this.BresenhamLine = new System.Windows.Forms.RadioButton();
            this.BuildInLine = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.ControlsGroupBox.SuspendLayout();
            this.ButtonControls.SuspendLayout();
            this.BasicControls.SuspendLayout();
            this.LineControls.SuspendLayout();
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
            this.MainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseDown);
            this.MainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseMove);
            // 
            // ControlsGroupBox
            // 
            this.ControlsGroupBox.Controls.Add(this.ButtonControls);
            this.ControlsGroupBox.Controls.Add(this.BasicControls);
            this.ControlsGroupBox.Controls.Add(this.LineControls);
            this.ControlsGroupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.ControlsGroupBox.Location = new System.Drawing.Point(806, 0);
            this.ControlsGroupBox.Name = "ControlsGroupBox";
            this.ControlsGroupBox.Size = new System.Drawing.Size(200, 800);
            this.ControlsGroupBox.TabIndex = 1;
            this.ControlsGroupBox.TabStop = false;
            this.ControlsGroupBox.Text = "Controls";
            // 
            // ButtonControls
            // 
            this.ButtonControls.ColumnCount = 2;
            this.ButtonControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ButtonControls.Controls.Add(this.RemoveVertexButton, 0, 0);
            this.ButtonControls.Controls.Add(this.RemoveEdgeButton, 1, 0);
            this.ButtonControls.Controls.Add(this.RemovePolygonButton, 0, 1);
            this.ButtonControls.Controls.Add(this.RemoveAllButton, 1, 1);
            this.ButtonControls.Controls.Add(this.DivideEdgeButton, 0, 2);
            this.ButtonControls.Controls.Add(this.RandomPolygonButton, 1, 2);
            this.ButtonControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonControls.Location = new System.Drawing.Point(3, 119);
            this.ButtonControls.Name = "ButtonControls";
            this.ButtonControls.RowCount = 3;
            this.ButtonControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonControls.Size = new System.Drawing.Size(194, 222);
            this.ButtonControls.TabIndex = 4;
            // 
            // RemoveVertexButton
            // 
            this.RemoveVertexButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveVertexButton.Location = new System.Drawing.Point(3, 3);
            this.RemoveVertexButton.Name = "RemoveVertexButton";
            this.RemoveVertexButton.Size = new System.Drawing.Size(91, 68);
            this.RemoveVertexButton.TabIndex = 0;
            this.RemoveVertexButton.Text = "Remove selected vertex";
            this.RemoveVertexButton.UseVisualStyleBackColor = true;
            this.RemoveVertexButton.Click += new System.EventHandler(this.RemoveVertexButton_Click);
            // 
            // RemoveEdgeButton
            // 
            this.RemoveEdgeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveEdgeButton.Location = new System.Drawing.Point(100, 3);
            this.RemoveEdgeButton.Name = "RemoveEdgeButton";
            this.RemoveEdgeButton.Size = new System.Drawing.Size(91, 68);
            this.RemoveEdgeButton.TabIndex = 1;
            this.RemoveEdgeButton.Text = "Remove selected edge";
            this.RemoveEdgeButton.UseVisualStyleBackColor = true;
            this.RemoveEdgeButton.Click += new System.EventHandler(this.RemoveEdgeButton_Click);
            // 
            // RemovePolygonButton
            // 
            this.RemovePolygonButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemovePolygonButton.Location = new System.Drawing.Point(3, 77);
            this.RemovePolygonButton.Name = "RemovePolygonButton";
            this.RemovePolygonButton.Size = new System.Drawing.Size(91, 68);
            this.RemovePolygonButton.TabIndex = 2;
            this.RemovePolygonButton.Text = "Remove selected polygon";
            this.RemovePolygonButton.UseVisualStyleBackColor = true;
            this.RemovePolygonButton.Click += new System.EventHandler(this.RemovePolygonButton_Click);
            // 
            // RemoveAllButton
            // 
            this.RemoveAllButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveAllButton.Location = new System.Drawing.Point(100, 77);
            this.RemoveAllButton.Name = "RemoveAllButton";
            this.RemoveAllButton.Size = new System.Drawing.Size(91, 68);
            this.RemoveAllButton.TabIndex = 3;
            this.RemoveAllButton.Text = "Clear All";
            this.RemoveAllButton.UseVisualStyleBackColor = true;
            this.RemoveAllButton.Click += new System.EventHandler(this.RemoveAllButton_Click);
            // 
            // DivideEdgeButton
            // 
            this.DivideEdgeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DivideEdgeButton.Location = new System.Drawing.Point(3, 151);
            this.DivideEdgeButton.Name = "DivideEdgeButton";
            this.DivideEdgeButton.Size = new System.Drawing.Size(91, 68);
            this.DivideEdgeButton.TabIndex = 4;
            this.DivideEdgeButton.Text = "Divide selected edge";
            this.DivideEdgeButton.UseVisualStyleBackColor = true;
            this.DivideEdgeButton.Click += new System.EventHandler(this.DivideEdgeButton_Click);
            // 
            // RandomPolygonButton
            // 
            this.RandomPolygonButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RandomPolygonButton.Location = new System.Drawing.Point(100, 151);
            this.RandomPolygonButton.Name = "RandomPolygonButton";
            this.RandomPolygonButton.Size = new System.Drawing.Size(91, 68);
            this.RandomPolygonButton.TabIndex = 5;
            this.RandomPolygonButton.Text = "Random polygon";
            this.RandomPolygonButton.UseVisualStyleBackColor = true;
            this.RandomPolygonButton.Click += new System.EventHandler(this.RandomPolygonButton_Click);
            // 
            // BasicControls
            // 
            this.BasicControls.ColumnCount = 1;
            this.BasicControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BasicControls.Controls.Add(this.CreateRadioButton, 0, 0);
            this.BasicControls.Controls.Add(this.MoveRadioButton, 0, 1);
            this.BasicControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.BasicControls.Location = new System.Drawing.Point(3, 19);
            this.BasicControls.Name = "BasicControls";
            this.BasicControls.RowCount = 2;
            this.BasicControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BasicControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BasicControls.Size = new System.Drawing.Size(194, 100);
            this.BasicControls.TabIndex = 3;
            // 
            // CreateRadioButton
            // 
            this.CreateRadioButton.AutoSize = true;
            this.CreateRadioButton.Checked = true;
            this.CreateRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreateRadioButton.Location = new System.Drawing.Point(3, 3);
            this.CreateRadioButton.Name = "CreateRadioButton";
            this.CreateRadioButton.Size = new System.Drawing.Size(188, 44);
            this.CreateRadioButton.TabIndex = 0;
            this.CreateRadioButton.TabStop = true;
            this.CreateRadioButton.Text = "Create new polygons";
            this.CreateRadioButton.UseVisualStyleBackColor = true;
            // 
            // MoveRadioButton
            // 
            this.MoveRadioButton.AutoSize = true;
            this.MoveRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MoveRadioButton.Location = new System.Drawing.Point(3, 53);
            this.MoveRadioButton.Name = "MoveRadioButton";
            this.MoveRadioButton.Size = new System.Drawing.Size(188, 44);
            this.MoveRadioButton.TabIndex = 1;
            this.MoveRadioButton.Text = "Move existing objects";
            this.MoveRadioButton.UseVisualStyleBackColor = true;
            // 
            // LineControls
            // 
            this.LineControls.ColumnCount = 1;
            this.LineControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LineControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LineControls.Controls.Add(this.BresenhamLine, 0, 0);
            this.LineControls.Controls.Add(this.BuildInLine, 0, 1);
            this.LineControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LineControls.Location = new System.Drawing.Point(3, 697);
            this.LineControls.Name = "LineControls";
            this.LineControls.RowCount = 2;
            this.LineControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LineControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LineControls.Size = new System.Drawing.Size(194, 100);
            this.LineControls.TabIndex = 2;
            // 
            // BresenhamLine
            // 
            this.BresenhamLine.AutoSize = true;
            this.BresenhamLine.Checked = true;
            this.BresenhamLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BresenhamLine.Location = new System.Drawing.Point(3, 3);
            this.BresenhamLine.Name = "BresenhamLine";
            this.BresenhamLine.Size = new System.Drawing.Size(188, 44);
            this.BresenhamLine.TabIndex = 1;
            this.BresenhamLine.TabStop = true;
            this.BresenhamLine.Text = "Bresenham\'s Line Algorithm";
            this.BresenhamLine.UseVisualStyleBackColor = true;
            // 
            // BuildInLine
            // 
            this.BuildInLine.AutoSize = true;
            this.BuildInLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuildInLine.Location = new System.Drawing.Point(3, 53);
            this.BuildInLine.Name = "BuildInLine";
            this.BuildInLine.Size = new System.Drawing.Size(188, 44);
            this.BuildInLine.TabIndex = 0;
            this.BuildInLine.Text = "Build-In Line Algorithm";
            this.BuildInLine.UseVisualStyleBackColor = true;
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
            this.ButtonControls.ResumeLayout(false);
            this.BasicControls.ResumeLayout(false);
            this.BasicControls.PerformLayout();
            this.LineControls.ResumeLayout(false);
            this.LineControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox MainPictureBox;
        private GroupBox ControlsGroupBox;
        private TableLayoutPanel LineControls;
        private RadioButton BresenhamLine;
        private RadioButton BuildInLine;
        private TableLayoutPanel BasicControls;
        private RadioButton CreateRadioButton;
        private RadioButton MoveRadioButton;
        private TableLayoutPanel ButtonControls;
        private Button RemoveVertexButton;
        private Button RemoveEdgeButton;
        private Button RemovePolygonButton;
        private Button RemoveAllButton;
        private Button DivideEdgeButton;
        private Button RandomPolygonButton;
    }
}