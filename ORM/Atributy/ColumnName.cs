using System;

namespace ORM.Atributy
{
    public class ColumnName : Attribute
    {
        public ColumnName(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}