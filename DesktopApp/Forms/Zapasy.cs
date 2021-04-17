using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.DomainController;

namespace DesktopApp.Forms
{
    public partial class Zapasy : Form, IAsyncInitialization
    {

        private DomainZapasy _domainZapasy;

        public Task Initialization { get; }
        
        public Zapasy()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _domainZapasy = new DomainZapasy();
            Initialization = GetZapasy();
        }

        private async Task GetZapasy()
        {
            var zapasy = await _domainZapasy.SelectZapasy();

            var a = from zapas in zapasy select new {zapas.Zid, KlubName = zapas.Klub1.KlubName, klub2 = zapas.Klub2.KlubName, zapas.DomaciSkore, zapas.HosteSkore, zapas.Datum};
            dataGridView1.DataSource = a.ToList();
            
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Domácí";
            dataGridView1.Columns[2].HeaderText = "Hosté";
            dataGridView1.Columns[3].HeaderText = "Domácí skóre";
            dataGridView1.Columns[4].HeaderText = "Hosté skóre";
            dataGridView1.Columns[5].HeaderText = "Datum";
            
            var btnCell = new DataGridViewButtonColumn
            {
                HeaderText = @"Detail zápasu",
                Text = @"Zobrazit",
                UseColumnTextForButtonValue = true
            };

            dataGridView1.Columns.Add(btnCell);
            
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }
        

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var table = (DataGridView) sender;
            
            if(!(table.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var a = (int) table.Rows[e.RowIndex].Cells["zid"].Value;

            using (var soupiska = new DetailZapasu(a))
            {
                if (soupiska.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Menu a = new Menu();
            a.Show();
        }
    }
}