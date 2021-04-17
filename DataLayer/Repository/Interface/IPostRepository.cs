using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Items;

namespace DataLayer.Repository.Interface
{
    public interface IPostRepository<T> where T : class
    {
        Task<IEnumerable<ItemPost>> GetPost();
    }
}