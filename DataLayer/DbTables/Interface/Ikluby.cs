using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Items;

namespace DataLayer.DbTables.Interface
{
    public interface IKluby<T> where T : class
    {
        Task<IEnumerable<ItemKlub>> GetKlub();

        Task<IEnumerable<ItemKlub>> GetKlubByName(string name);

        Task<IEnumerable<ItemKlub>> GetKlubById(int id);
        Task InsertKlub(ItemKlub klub);
        Task UpdateKlub(ItemKlub klub);
        Task DeleteKlub(ItemKlub klub);
    }
}