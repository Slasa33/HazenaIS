using DataLayer.Items;
using DataLayer.Repository;
using DataLayer.Repository.Interface;
using ORM;

namespace DataLayer
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        public IHraciRepository<T> Hraci { get; set; }
        public IKlubyRepository<T> Kluby { get; set; }
        public IZapasyRepository<T> Zapasy { get; set; }
        public IPostRepository<T> Post { get; set; }
        public ITabulkaRepository<T> Tabulka { get; set; }


        public UnitOfWork(HazenaContext hazenaContext)
        {
            InitializeRepository(hazenaContext);
        }

        private void InitializeRepository(HazenaContext hazenaContext)
        {
            Hraci = new HraciRepository<T>(hazenaContext.Hrac);
            Kluby = new KlubyRepository<T>(hazenaContext.Klub);
            Zapasy = new ZapasyRepository<T>(hazenaContext.Zapas);
            Post = new PostRepository<T>(hazenaContext.Post);
            Tabulka = new TabulkaRepository<T>(hazenaContext.Tabulka);
        }

    }
}