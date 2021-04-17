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

        public VlozitKlub(ItemKlub klubik)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _domainKluby = new DomainKluby();
            klub = klubik;
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
        
        private async void button1_Click(object sender, EventArgs e)
        {
            await InsertKlub();
        }

        private async Task InsertKlub()
        {
            GetInfo();
            await _domainKluby.InsertKlub(klub);
        }

    }
}