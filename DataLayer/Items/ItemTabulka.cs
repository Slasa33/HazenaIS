using System.ComponentModel.DataAnnotations.Schema;
using ORM.Atributy;

namespace DataLayer.Items
{
    [TableName("tabulky")]
    public class ItemTabulka
    {
        [ColumnName("body")] 
        public int Body { get; set; }
        
        [ColumnName("vyhry")] 
        public int Vyhry { get; set; }
        
        [ColumnName("remizy")] 
        public int Remizy { get; set; }
        
        [ColumnName("prohry")] 
        public int Prohry { get; set; }
        
        [ColumnName("vstrelene_branky")] 
        public int VstreleneBranky { get; set; }
        
        [ColumnName("utrzene_branky")] 
        public int UtrzeneBranky{ get; set; }
        
        [ForeignKey("klub")] 
        public ItemKlub Klub { get; set; }
        
        [ForeignKey("liga")] 
        public ItemLiga Liga { get; set; }

        public override string ToString()
        {
            return $"{Body}, {Vyhry}, {Remizy}, {Prohry}, {VstreleneBranky}, {UtrzeneBranky}, {Klub}, {Liga}";
        }
    }
}