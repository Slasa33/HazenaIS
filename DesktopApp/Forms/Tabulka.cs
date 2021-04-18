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
    public partial class Tabulka : Form, IAsyncInitialization
    {
        private DomainTabulka _domainTabulka;
        private ItemTabulka _tabulka;
        private IEnumerable<ItemTabulka> tabulka;
        
        public Task Initialization { get; }
        public Tabulka()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _domainTabulka = new DomainTabulka();
            CreateGrid();
            Initialization = GetTabulka();
        }

        private async Task GetTabulka()
        {
            tabulka = await _domainTabulka.SelectTabulku();
            var bindingList = new BindingList<ItemTabulka>(tabulka.ToList());
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void CreateGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Liga",
                DataPropertyName = nameof(_tabulka.Liga)
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Klub",
                DataPropertyName = nameof(_tabulka.Klub)
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Výhry",
                DataPropertyName = nameof(_tabulka.Vyhry)
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Remízy",
                DataPropertyName = nameof(_tabulka.Remizy)
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Prohry",
                DataPropertyName = nameof(_tabulka.Prohry)
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Vstřelené branky",
                DataPropertyName = nameof(_tabulka.VstreleneBranky)
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Utržené branky",
                DataPropertyName = nameof(_tabulka.UtrzeneBranky)
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Body",
                DataPropertyName = nameof(_tabulka.Body)
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Menu a = new Menu();
            a.Show();
        }
    }
}