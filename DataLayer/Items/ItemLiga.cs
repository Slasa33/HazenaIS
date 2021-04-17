using System.ComponentModel.DataAnnotations;
using ORM.Atributy;

namespace DataLayer.Items
{
    [TableName("liga")]
    public class ItemLiga
    {
        [Key]
        [ColumnName("lID")] 
        public int Lid { get; set; }
        
        [ColumnName("nazev_ligy")] 
        public string NazevLigy { get; set; }

        public override string ToString()
        {
            return $"{NazevLigy}";
        }
    }
}