namespace DesktopApp
{
    partial class Menu
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.zapasyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spravaKlubuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabulkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.zapasyToolStripMenuItem, this.spravaKlubuToolStripMenuItem, this.tabulkaToolStripMenuItem, this.konecToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(351, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // zapasyToolStripMenuItem
            // 
            this.zapasyToolStripMenuItem.Name = "zapasyToolStripMenuItem";
            this.zapasyToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.zapasyToolStripMenuItem.Text = "Zapasy";
            this.zapasyToolStripMenuItem.Click += new System.EventHandler(this.zapasyToolStripMenuItem_Click);
            // 
            // spravaKlubuToolStripMenuItem
            // 
            this.spravaKlubuToolStripMenuItem.Name = "spravaKlubuToolStripMenuItem";
            this.spravaKlubuToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.spravaKlubuToolStripMenuItem.Text = "Sprava klubu";
            this.spravaKlubuToolStripMenuItem.Click += new System.EventHandler(this.spravaKlubuToolStripMenuItem_Click);
            // 
            // tabulkaToolStripMenuItem
            // 
            this.tabulkaToolStripMenuItem.Name = "tabulkaToolStripMenuItem";
            this.tabulkaToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.tabulkaToolStripMenuItem.Text = "Tabulka";
            this.tabulkaToolStripMenuItem.Click += new System.EventHandler(this.tabulkaToolStripMenuItem_Click);
            // 
            // konecToolStripMenuItem
            // 
            this.konecToolStripMenuItem.Name = "konecToolStripMenuItem";
            this.konecToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.konecToolStripMenuItem.Text = "Konec";
            this.konecToolStripMenuItem.Click += new System.EventHandler(this.konecToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(351, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 236);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Menu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem konecToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem tabulkaToolStripMenuItem;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.ToolStripMenuItem spravaKlubuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapasyToolStripMenuItem;

        private System.Windows.Forms.MenuStrip menuStrip1;

        #endregion
    }
}