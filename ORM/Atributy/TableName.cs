using System;

namespace ORM.Atributy
{
    public class TableName : Attribute
    {
        public TableName(string tableName)
        {
            TablName = tableName;
        }

        public override string ToString()
        {
            return $"{TablName}";
        }
    
        public string TablName { get; set; }
        
    }
}