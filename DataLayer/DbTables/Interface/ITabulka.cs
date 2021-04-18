using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Items;

namespace DataLayer.DbTables.Interface
{
    public interface ITabulka<T> where T : class
    {
        Task<IEnumerable<ItemTabulka>> GetTabulku();
    }
}