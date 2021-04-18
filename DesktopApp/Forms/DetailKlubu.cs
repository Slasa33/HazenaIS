using System;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer.DomainController;
using DataLayer.Items;

namespace DesktopApp.Forms
{
    public partial class DetailKlubu : Form
    {
        private int _id;
        private SpravaKlubu form;
        private DomainKluby _domainKluby;
        private DomainHraci _domainHraci;
        private ItemKlub Klub;
        public DetailKlubu(ItemKlub klub, int id, SpravaKlubu spravaKlubu)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _domainKluby = new DomainKluby();
            _domainHraci = new DomainHraci();
            Klub = klub;
            LoadInfo();
            _id = id;
            form = spravaKlubu;
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
            button4.Visible = true;
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
        
        private async void button4_Click(object sender, EventArgs e)
        {
            var check = await _domainHraci.SelectHraciByKlubId(_id);

            if (check.Count().Equals(0))
            {
                GetInfo();
                await _domainKluby.DeleteKlub(Klub);
                await form.GetKlubs();
                Close();
            }
            else
            {
                MessageBox.Show("Nemůžeš smazat klub, který má nějaké hráče!");
            }
        }
    }
}