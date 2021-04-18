using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.DomainController;
using DataLayer.Items;

namespace DesktopApp.Forms
{
    public partial class DetailHrace : Form, IAsyncInitialization
    {
        
        private ItemHrac Hrac;
        private SpravaHracu form;
        
        private DomainHraci _domainHraci;
        private DomainPost _domainPost;
        private DomainKluby _domainKluby;
        
        private IEnumerable<ItemPost> _postList;
        private IEnumerable<ItemKlub> _klubList;
        
        public Task Initialization { get; }

        public DetailHrace(ItemHrac hrac, SpravaHracu spravaHracu)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _domainHraci = new DomainHraci();
            _domainPost = new DomainPost();
            _domainKluby = new DomainKluby();
            Hrac = hrac;
            form = spravaHracu;
            Initialization = GetPostList();
            LoadInfo();
            
        }

        private void LoadInfo()
        {
            textBox1.Text = Hrac.Hid.ToString();
            textBox2.Text = Hrac.Name;
            textBox3.Text = Hrac.LastName;
            textBox5.Text = Hrac.PersonalIn;
            textBox7.Text = Hrac.Heslo;
            textBox1.Enabled = false;
            LockTextBox();
            ulozitButton.Visible = false;
            deleteButton.Visible = false;
        }

        private ItemPost GetPost()
        {
            return _postList.FirstOrDefault(post => Hrac.Post.Pid == post.Pid);
        }
        
        private async Task GetPostList()
        {
            _postList = await _domainPost.SelectPosty();
            _klubList = await _domainKluby.SelectKluby();
            
            klubComboBox.DataSource = _klubList;
            klubComboBox.SelectedItem = GetKlub();
            klubComboBox.Enabled = false;
            postComboBox.DataSource = _postList;
            postComboBox.SelectedItem = GetPost();
        }
        
        
        private ItemKlub GetKlub()
        {
            return _klubList.FirstOrDefault(klub => klub.Kid == Hrac.Klub.Kid);
        }

        private void GetInfo()
        {
            Hrac.Name = textBox2.Text;
            Hrac.LastName = textBox3.Text;
            Hrac.PersonalIn = textBox5.Text;
            Hrac.Post = (ItemPost) postComboBox.SelectedValue;
            Hrac.Klub = (ItemKlub) klubComboBox.SelectedValue;
            Hrac.Heslo = textBox7.Text;
        }

        private void prestupButton_Click(object sender, EventArgs e)
        {
            klubComboBox.Enabled = true;
            ulozitButton.Visible = true;
        }

        private void upravitButton_Click(object sender, EventArgs e)
        {
            UnlockTextBox();
            ulozitButton.Visible = true;
            deleteButton.Visible = true;
        }

        private async void ulozitButton_click(object sender, EventArgs e)
        {
            LockTextBox();
            await Updatehrac();
            await form.GetHraci();
            Close();

        }

        private async Task Updatehrac()
        {
            GetInfo();
            await _domainHraci.UpdateHrac(Hrac);
        }

        private async Task DeleteHrac()
        {
            GetInfo();
            await _domainHraci.DeleteHrac(Hrac);
        }


        private void LockTextBox()
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox7.ReadOnly = true;
            postComboBox.Enabled = false;
        }

        private void UnlockTextBox()
        {
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox7.ReadOnly = false;
            postComboBox.Enabled = true;
        }

        private void zpetButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult =
                MessageBox.Show("Opravdu chcete smazat hrace?", "Smazani", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                await DeleteHrac();
                await form.GetHraci();
                Close();
            }
        }
        
    }
}