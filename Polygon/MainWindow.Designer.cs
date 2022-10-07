namespace Polygon
{
    partial class MainWindow
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
            this.UserInterface = new System.Windows.Forms.GroupBox();
            this.BitMap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BitMap)).BeginInit();
            this.SuspendLayout();
            // 
            // UserInterface
            // 
            this.UserInterface.Dock = System.Windows.Forms.DockStyle.Right;
            this.UserInterface.Location = new System.Drawing.Point(806, 0);
            this.UserInterface.Name = "UserInterface";
            this.UserInterface.Size = new System.Drawing.Size(200, 800);
            this.UserInterface.TabIndex = 0;
            this.UserInterface.TabStop = false;
            this.UserInterface.Text = "Controls";
            // 
            // BitMap
            // 
            this.BitMap.BackColor = System.Drawing.SystemColors.Control;
            this.BitMap.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BitMap.Dock = System.Windows.Forms.DockStyle.Left;
            this.BitMap.Location = new System.Drawing.Point(0, 0);
            this.BitMap.Name = "BitMap";
            this.BitMap.Size = new System.Drawing.Size(800, 800);
            this.BitMap.TabIndex = 1;
            this.BitMap.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1006, 800);
            this.Controls.Add(this.BitMap);
            this.Controls.Add(this.UserInterface);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Polygon";
            ((System.ComponentModel.ISupportInitialize)(this.BitMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox UserInterface;
        private PictureBox BitMap;
    }
}