using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Items;

namespace DataLayer.Repository.Interface
{
    public interface IZapasyRepository<T> where T : class
    {
        Task<IEnumerable<ItemZapasy>> GetZapasy();

        Task<ItemZapasy> GetZapasById(int id);
    }
}