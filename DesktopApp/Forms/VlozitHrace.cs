using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.DomainController;
using DataLayer.Items;

namespace DesktopApp.Forms
{
    public partial class VlozitHrace : Form, IAsyncInitialization
    {
        private ItemHrac Hrac;
        private DomainHraci _domainHraci;
        private DomainKluby _domainKluby;
        private DomainPost _domainPost;

        private IEnumerable<ItemKlub> _klubList;
        private IEnumerable<ItemPost> _postList;
        
        public Task Initialization { get; }

        private int _id;

        private SpravaHracu form;
        
        public VlozitHrace(ItemHrac hracik, int id, SpravaHracu spravaHracu)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _domainPost = new DomainPost();
            _domainKluby = new DomainKluby();
            _domainHraci = new DomainHraci();
            _id = id;
            form = spravaHracu;
            Hrac = hracik;
            Initialization = InitializeAsync();
        }

        private void GetInfo()
        {
            Hrac.Name = textBox1.Text;
            Hrac.LastName = textBox2.Text;
            Hrac.PersonalIn = textBox3.Text;
            Hrac.Heslo = textBox4.Text;
            Hrac.Post = (ItemPost) postComboBox.SelectedValue;
            Hrac.Klub = (ItemKlub) klubComboBox.SelectedValue;
        }
        
        private async Task InitializeAsync()
        {
            _postList = await _domainPost.SelectPosty();
            _klubList = await _domainKluby.SelectKluby();
            
            postComboBox.DataSource = _postList;
            klubComboBox.DataSource = _klubList;
            klubComboBox.SelectedItem = GetKlub();
            klubComboBox.Enabled = false;
            
        }

        private bool ValidateInput()
        {
            if(textBox1.Text.Equals("")) return false;
            if(textBox2.Text.Equals("")) return false;
            if(textBox3.Text.Equals("")) return false;
            if(textBox4.Text.Equals("")) return false;
            if(klubComboBox.SelectedIndex == -1) return false;
            if(postComboBox.SelectedIndex == -1) return false;

            return true;
        }
        
        private ItemKlub GetKlub()
        {
            return _klubList.FirstOrDefault(klub => klub.Kid == _id);
        }
        
        private async void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Špatně vyplněné údaje!");
                return;
            }
            
            GetInfo();
            await _domainHraci.InsertHrac(Hrac);
            await form.GetHraci();
            Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}