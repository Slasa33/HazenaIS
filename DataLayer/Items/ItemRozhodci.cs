using System.ComponentModel.DataAnnotations;
using ORM.Atributy;

namespace DataLayer.Items
{
    [TableName("Rozhodci")]
    public class ItemRozhodci
    {
        [Key]
        [ColumnName("rid")]
        public int Rid { get; set; }
        [ColumnName("jmeno")]
        public string Name { get; set; }
        [ColumnName("prijmeni")]
        public string LastName { get; set; }
        [ColumnName("rodne_cislo")]
        public string PersonalIn { get; set; }
        [ColumnName("telefon")]
        public string Telephone { get; set; }
        [ColumnName("heslo")]
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{Name}, {LastName}, {PersonalIn}, {Telephone}, {Password}";
        }
    }
}
