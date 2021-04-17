using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ORM.Atributy;

namespace DataLayer.Items
{
    [TableName("zapasy")]
    public class ItemZapasy
    {
        [Key] 
        [ColumnName("zid")] 
        public int Zid { get; set; }
        
        [ColumnName("domaci_skore")] 
        public int DomaciSkore { get; set; }
        
        [ColumnName("hoste_skore")] 
        public int HosteSkore { get; set; }
        
        [ColumnName("datum_cas")] 
        public DateTime Datum { get; set; }
        
        [ForeignKey("rozhodci")] 
        public ItemRozhodci Rozhodci { get; set; }
        
        [ForeignKey("klub")] 
        public ItemKlub Klub1 { get; set; }
        
        [ForeignKey("klub")] 
        public ItemKlub Klub2 { get; set; }

        public override string ToString()
        {
            return $"{Zid}, {DomaciSkore}, {HosteSkore},  {Datum},  {Rozhodci},  {Klub1}, {Klub2}";
        }
    }
}