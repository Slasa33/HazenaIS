namespace DataLayer.Repository.Interface
{
    public interface IUnitOfWork<T> where T : class
    {
        IHraciRepository<T> Hraci { get; set; }
        
        IKlubyRepository<T> Kluby { get; set; }
        IZapasyRepository<T> Zapasy { get; set; }
        IPostRepository<T> Post { get; set; }
        ITabulkaRepository<T> Tabulka { get; set; }
    }
}