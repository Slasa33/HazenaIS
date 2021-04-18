using DataLayer.DbTables.Interface;

namespace DataLayer.DbTables.Interface
{
    public interface IUnitOfWork<T> where T : class
    {
        IHraci<T> Hraci { get; set; }
        
        IKluby<T> Kluby { get; set; }
        IZapasy<T> Zapasy { get; set; }
        IPost<T> Post { get; set; }
        ITabulka<T> Tabulka { get; set; }
    }
}