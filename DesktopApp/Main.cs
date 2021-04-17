using System;
using System.Windows.Forms;
using DesktopApp.Forms;

namespace DesktopApp
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void spravaKlubuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpravaKlubu form = new SpravaKlubu();
            form.ShowDialog();
            Hide();
        }
        
        private void zapasyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zapasy form = new Zapasy();
            form.Show();
            Hide();
        }

        private void tabulkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tabulka form = new Tabulka();
            form.Show();
            Hide();
        }

        private void konecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}