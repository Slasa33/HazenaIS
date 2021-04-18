using DataLayer.DbTables;
using DataLayer.DbTables.Interface;

namespace DataLayer
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        public IHraci<T> Hraci { get; set; }
        public IKluby<T> Kluby { get; set; }
        public IZapasy<T> Zapasy { get; set; }
        public IPost<T> Post { get; set; }
        public ITabulka<T> Tabulka { get; set; }


        public UnitOfWork(DbContext hazenaContext)
        {
            InitializeRepository(hazenaContext);
        }

        private void InitializeRepository(DbContext hazenaContext)
        {
            Hraci = new DbHraci<T>(hazenaContext.Hrac);
            Kluby = new DbKluby<T>(hazenaContext.Klub);
            Zapasy = new DbZapasy<T>(hazenaContext.Zapas);
            Post = new DbPost<T>(hazenaContext.Post);
            Tabulka = new DbTabulka<T>(hazenaContext.Tabulka);
        }

    }
}