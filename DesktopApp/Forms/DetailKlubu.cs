using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.DomainController;
using DataLayer.Items;

namespace DesktopApp.Forms
{
    public partial class DetailKlubu : Form
    {
        private int _id;
        private DomainKluby _domainKluby;
        private ItemKlub Klub;
        public DetailKlubu(ItemKlub klub)
        {
            InitializeComponent();
            _domainKluby = new DomainKluby();
            Klub = klub;
            LoadInfo();
        }

        private void LoadInfo()
        {
            textBox1.Text = Klub.KlubName;
            textBox2.Text = Klub.Prezident;
        }

        private void GetInfo()
        {
            Klub.KlubName = textBox1.Text;
            Klub.Prezident = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            button3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            GetInfo();
            await _domainKluby.UpdateKlub(Klub);
            Close();
        }
    }
}