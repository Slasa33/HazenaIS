using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Items;

namespace DataLayer.Repository.Interface
{
    public interface IHraciRepository<T> where T : class
    {
        Task<ItemHrac> GetHracById(int id);

        Task<IEnumerable<ItemHrac>> GetHraciByKlubId(int id);
        Task InsertHrac(ItemHrac hrac);
        Task UpdateHrac(ItemHrac hrac);
        Task DeleteHrac(ItemHrac hrac);
    }
}