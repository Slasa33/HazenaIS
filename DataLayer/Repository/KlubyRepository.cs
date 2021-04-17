using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Items;
using DataLayer.Repository.Interface;
using ORM;

namespace DataLayer.Repository
{
    public class KlubyRepository<T> : IKlubyRepository<T> where T : class
    {
        private readonly ReflectiveOrm<ItemKlub> _context;
        public KlubyRepository(ReflectiveOrm<ItemKlub> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemKlub>> GetKlub()
        {
            return await Task.Run(() => _context.Get());
        }

        public async Task<IEnumerable<ItemKlub>> GetKlubByName(string name)
        {
            return await Task.Run(() => _context.Where(klub => klub.KlubName == name).Get());
        }

        public async Task<IEnumerable<ItemKlub>> GetKlubById(int id)
        {
            return await Task.Run(() => _context.Where(klub => klub.Kid == id).Get());
        }

        public async Task InsertKlub(ItemKlub klub)
        {
            await Task.Run(() => _context.Insert(klub));
        }

        public async Task UpdateKlub(ItemKlub klub)
        {
            await Task.Run(() => _context.Where(k => k.Kid == klub.Kid).Update(klub));
        }

        public async Task DeleteKlub(ItemKlub klub)
        {
            await Task.Run(() => _context.Where(k => k.Kid == klub.Kid).Delete());
        }
    }
}