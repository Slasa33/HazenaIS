using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ORM.Atributy;

namespace DataLayer.Items
{
    [TableName("klub")]
    public class ItemKlub : INotifyPropertyChanged
    {

        private string _name, _prezident;
        
        [Key] 
        [ColumnName("kid")] 
        public int Kid { get; set; }

        [ColumnName("nazev_klubu")]
        public string KlubName
        {
            get => _name;
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(KlubName)));
            }
        }
        [ColumnName("prezident_klubu")]
        public string Prezident
        {
            get => _prezident;
            set
            {
                _prezident = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Prezident)));
            }
        }

        public override string ToString()
        {
            return $"{KlubName}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
    }
}