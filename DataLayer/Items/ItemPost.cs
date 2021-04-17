using System.ComponentModel.DataAnnotations;
using ORM.Atributy;

namespace DataLayer.Items
{
    [TableName("Post")]
    public class ItemPost
    {
        [Key]
        [ColumnName("pID")]
        public int Pid { get; set; }
        [ColumnName("nazev_postu")]
        public string Post { get; set; }

        public override string ToString()
        {
            return $"{Post}";
        }
    }
}