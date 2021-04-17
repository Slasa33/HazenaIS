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
    public partial class SpravaHracu : Form, IAsyncInitialization
    {
        
        private DomainHraci _domainHraci;
        private DomainKluby _domainKluby;
        
        private IEnumerable<ItemHrac> _hraci;
        
        private ItemHrac _hrac = new ItemHrac();
        private ItemPost _post = new ItemPost();
        
        public Task Initialization { get; }

        private int _id;
        public SpravaHracu(int id)
        {
            _id = id;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _domainHraci = new DomainHraci();
            _domainKluby = new DomainKluby();
            CreateGrid();
            Initialization = GetHraci();
           // _ = GetKlubNameAndPrez();
        }

        public async Task GetHraci()
        {
            _hraci = await _domainHraci.SelectHraciByKlubId(_id);
            
            var info = await _domainKluby.SelectKlubById(_id);
            label1.Text = info.ToList()[0].KlubName.ToUpper();
            label4.Text = info.ToList()[0].Prezident.ToUpper();
            
            FillData();
        }
        
        private void CreateGrid()
        {
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "hid",
                DataPropertyName = nameof(_hrac.Hid),
                Name = "hid",
                Visible = false
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Jmeno",
                DataPropertyName = nameof(_hrac.Name)
            });
            
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Prijmeni",
                DataPropertyName = nameof(_hrac.LastName),
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Post",
                DataPropertyName = nameof(_post.Post)
            });
            
            dataGridView1.AutoGenerateColumns = false;
            
            var btnCell = new DataGridViewButtonColumn
            {
                HeaderText = @"Detail hráče",
                Text = @"Zobrazit",
                UseColumnTextForButtonValue = true
            };
            
            dataGridView1.Columns.Add(btnCell);
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FillData()
        {
            var bindingList = new BindingList<ItemHrac>(_hraci.ToList());
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var table = (DataGridView) sender;
            
            if(!(table.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            
            
            var id = (int)table.Rows[e.RowIndex].Cells["hid"].Value;

            var hrac = GetHrac(id);

            var soupiska = new DetailHrace(hrac, this);
            
            soupiska.Show();
        }

        private ItemHrac GetHrac(int id)
        {
            ItemHrac hraci = new ItemHrac();

            foreach (var hrac in _hraci)
            {
                if (hrac.Hid == id)
                {
                    return hrac;
                }
            }

            return hraci;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SpravaKlubu form = new SpravaKlubu();
            form.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VlozitHrace form = new VlozitHrace(new ItemHrac(), _id, this);
            form.ShowDialog();
        }
    }
}