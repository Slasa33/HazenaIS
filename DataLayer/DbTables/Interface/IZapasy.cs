using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Items;

namespace DataLayer.DbTables.Interface
{
    public interface IZapasy<T> where T : class
    {
        Task<IEnumerable<ItemZapasy>> GetZapasy();

        Task<ItemZapasy> GetZapasById(int id);
    }
}