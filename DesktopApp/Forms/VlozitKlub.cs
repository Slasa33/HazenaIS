using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.DomainController;
using DataLayer.Items;

namespace DesktopApp.Forms
{
    public partial class VlozitKlub : Form
    {

        private ItemKlub klub;
        private DomainKluby _domainKluby;

        private SpravaKlubu form;
        public VlozitKlub(ItemKlub klubik, SpravaKlubu spravaKlubu)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _domainKluby = new DomainKluby();
            klub = klubik;
            form = spravaKlubu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GetInfo()
        {
            klub.KlubName = textBox1.Text;
            klub.Prezident = textBox2.Text;
        }
        
        private bool ValidateInput()
        {
            if(textBox1.Text.Equals("")) return false;
            if(textBox2.Text.Equals("")) return false;
            
            return true;
        }
        
        private async void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Špatně vyplněné údaje!");
                return;
            }
            
            await InsertKlub();
            await form.GetKlubs();
            Close();

        }

        private async Task InsertKlub()
        {
            GetInfo();
            await _domainKluby.InsertKlub(klub);
        }

    }
}