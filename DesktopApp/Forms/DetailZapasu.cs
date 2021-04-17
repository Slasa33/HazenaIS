using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.DomainController;

namespace DesktopApp.Forms
{
    public partial class DetailZapasu : Form, IAsyncInitialization
    {

        private DomainHraci _domainHraci;
        private DomainZapasy _domainZapasy;
        private int _id;
        
        public Task Initialization { get; }
        
        public DetailZapasu(int id)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _id = id;
            _domainZapasy = new DomainZapasy();
            _domainHraci = new DomainHraci();
            Initialization = GetInfo();
        }
        
        private async Task GetInfo()
        {
            var info = await _domainZapasy.GetZapasById(_id);

            tbrozhodci.Text = info.Rozhodci.Name + " " + info.Rozhodci.LastName;
            tbdatum.Text = info.Datum.ToString();
            tbdomaci.Text = info.Klub1.KlubName;
            tbhoste.Text = info.Klub2.KlubName;
            tbdomaciskore.Text = info.DomaciSkore.ToString();
            tbhosteskore.Text = info.HosteSkore.ToString();

            var soupiskaDomaci = await _domainHraci.SelectHraciByKlubId(info.Klub1.Kid);

            dataGridView1.DataSource =
                (from domaci in soupiskaDomaci select new {domaci.Name, domaci.LastName, domaci.Post.Post}).ToList();

            var soupiskaHoste = await _domainHraci.SelectHraciByKlubId(info.Klub2.Kid);
            
            dataGridView2.DataSource =
                (from hoste in soupiskaHoste select new {hoste.Name, hoste.LastName, hoste.Post.Post}).ToList();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}