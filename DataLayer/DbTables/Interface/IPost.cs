using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Items;

namespace DataLayer.DbTables.Interface
{
    public interface IPost<T> where T : class
    {
        Task<IEnumerable<ItemPost>> GetPost();
    }
}