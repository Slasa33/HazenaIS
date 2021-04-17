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
    public partial class DetailZapasu : Form, IAsyncInitialization
    {

        private DomainHraci _domainHraci;
        private DomainZapasy _domainZapasy;

        private IEnumerable<ItemHrac> _zapasyDomaci;
        private IEnumerable<ItemHrac> _zapasyHoste;
        
        private ItemHrac _hrac = new ItemHrac();
        private ItemPost _post = new ItemPost();
        
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
            CreateGrid();
            var info = await _domainZapasy.GetZapasById(_id);
            tbrozhodci.Text = info.Rozhodci.Name + " " + info.Rozhodci.LastName;
            tbdatum.Text = info.Datum.ToString();
            tbdomaci.Text = info.Klub1.KlubName;
            tbhoste.Text = info.Klub2.KlubName;
            tbdomaciskore.Text = info.DomaciSkore.ToString();
            tbhosteskore.Text = info.HosteSkore.ToString();
            
            _zapasyDomaci = await _domainHraci.SelectHraciByKlubId(info.Klub1.Kid);
            var bindingList = new BindingList<ItemHrac>(_zapasyDomaci.ToList());
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
            
            _zapasyHoste = await _domainHraci.SelectHraciByKlubId(info.Klub2.Kid);
            var bindingList2 = new BindingList<ItemHrac>(_zapasyHoste.ToList());
            var source2 = new BindingSource(bindingList2, null);
            dataGridView2.DataSource = source2;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void CreateGrid()
        {

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Jméno",
                DataPropertyName = nameof(_hrac.Name)
            });
            
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Příjmení",
                DataPropertyName = nameof(_hrac.LastName),
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Post",
                DataPropertyName = nameof(_post.Post)
            });
            
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            
            
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Jméno",
                DataPropertyName = nameof(_hrac.Name)
            });
            
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Příjmení",
                DataPropertyName = nameof(_hrac.LastName),
            });

            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Post",
                DataPropertyName = nameof(_post.Post)
            });
            
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }

        
    }
}