using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.DomainController;
using DataLayer.Items;


namespace DesktopApp.Forms
{
    public partial class SpravaKlubu : Form, IAsyncInitialization
    {
        private DomainKluby _domainKluby;
        private IEnumerable<ItemKlub> _kluby;
        
        public Task Initialization { get; }
        
        public SpravaKlubu()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _domainKluby = new DomainKluby();
            Initialization = GetKlubs();
        }

        public async Task GetKlubs()
        {
            _kluby = await _domainKluby.SelectKluby();
            CreateGrid();
        }

        private void CreateGrid()
        {
            var bindingList = new BindingList<ItemKlub>(_kluby.ToList());
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;

            dataGridView1.Columns[0].HeaderText = "ID Klubu";
            dataGridView1.Columns[1].HeaderText = "Název klubu";
            
            var btnCell = new DataGridViewButtonColumn
            {
                HeaderText = @"Soupiska klubu",
                Text = @"Zobrazit",
                UseColumnTextForButtonValue = true
            };
            

            dataGridView1.Columns.Add(btnCell);
            
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].Visible = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            VlozitKlub newKlub = new VlozitKlub(new ItemKlub());
            newKlub.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var table = (DataGridView) sender;
            
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                var value = (int) table.Rows[e.RowIndex].Cells["kid"].Value;
                var klub = GetKlub(value);
                var aha = new DetailKlubu(klub, value, this);
                aha.Show();
            }
            
            if(!(table.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var a = (int) table.Rows[e.RowIndex].Cells["kid"].Value;
            var soupiska = new SpravaHracu(a);
            soupiska.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Menu a = new Menu();
            a.Show();
        }

        private ItemKlub GetKlub(int id)
        {
            ItemKlub klubs = new ItemKlub();

            foreach (var klub in _kluby)
            {
                if (klub.Kid == id)
                {
                    return klub;
                }
            }

            return klubs;
        }
    }
}