using System;
using System.Data.SqlClient;
using DataLayer.Items;
using ORM;

namespace DataLayer
{
    public class HazenaContext : IDisposable
    {

        private readonly SqlConnection _sqlConnection;
        
        public ReflectiveOrm<ItemHrac> Hrac { get; private set; }
        public ReflectiveOrm<ItemKlub> Klub { get; private set; }
        public ReflectiveOrm<ItemZapasy> Zapas { get; private set; }
        public ReflectiveOrm<ItemPost> Post { get; private set; }
        public ReflectiveOrm<ItemTabulka> Tabulka { get; private set; }

        public HazenaContext()
        {
            _sqlConnection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Integrated Security=True;Initial Catalog=VIS");
            _sqlConnection.Open();
            CreateRepositoryOrm();
        }

        private void CreateRepositoryOrm()
        {
            Hrac = new ReflectiveOrm<ItemHrac>(_sqlConnection);
            Klub = new ReflectiveOrm<ItemKlub>(_sqlConnection);
            Zapas = new ReflectiveOrm<ItemZapasy>(_sqlConnection);
            Post = new ReflectiveOrm<ItemPost>(_sqlConnection);
            Tabulka = new ReflectiveOrm<ItemTabulka>(_sqlConnection);
        }
        
        public void Dispose()
        {
            _sqlConnection.Dispose();
        }
    }
}