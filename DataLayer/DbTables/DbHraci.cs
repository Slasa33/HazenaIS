using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Items;
using DataLayer.Repository.Interface;
using ORM;

namespace DataLayer.Repository
{
    public class HraciRepository<T> : IHraciRepository<T> where T : class
    {
        private readonly ReflectiveOrm<ItemHrac> _context;
        public HraciRepository(ReflectiveOrm<ItemHrac> context)
        {
            _context = context;
        }

        public async Task<ItemHrac> GetHracById(int id)
        {
            return await Task.Run(() => _context.Where(hrac => hrac.Hid == id).JoinedSelect().ToList()[0]);
        }

        public async Task<IEnumerable<ItemHrac>> GetHraciByKlubId(int id)
        {
            return await Task.Run(() => _context.Where(hrac => hrac.Klub.Kid == id).JoinedSelect());
        }

        public async Task InsertHrac(ItemHrac hrac)
        {
            await Task.Run(() => _context.Insert(hrac));
        }

        public async Task UpdateHrac(ItemHrac hrac)
        {
            await Task.Run(() => _context.Where(h => h.Hid == hrac.Hid).Update(hrac));
        }

        public async Task DeleteHrac(ItemHrac hrac)
        {
            await Task.Run(() => _context.Where(h => h.Hid == hrac.Hid).Delete());
        }
    }
}