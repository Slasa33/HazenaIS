using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ORM.Atributy;

namespace DataLayer.Items
{
    [TableName("Hrac")]
    public class ItemHrac : INotifyPropertyChanged
    {

        private string _name, _lastName;
        private ItemPost _post;
        
        [Key] 
        [ColumnName("hid")] 
        public int Hid { get; set; }

        [ColumnName("jmeno")]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        [ColumnName("prijmeni")]
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        }
        [ColumnName("rodne_cislo")] 
        public string PersonalIn { get; set; }

        [ColumnName("heslo")] 
        public string Heslo { get; set; }

        [ForeignKey("post")]
        public ItemPost Post
        {
            get => _post;
            set
            {
                _post = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Post)));
            }
        }
        
        [ForeignKey("klub")] 
        public ItemKlub Klub { get; set; }

        public override string ToString()
        {
            return $"{Hid}, {Name}, {LastName}, {PersonalIn}, {Heslo}, {Post}, {Klub}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
    }
}