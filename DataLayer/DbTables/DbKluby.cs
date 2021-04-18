using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.DbTables.Interface;
using DataLayer.Items;
using ORM;

namespace DataLayer.DbTables
{
    public class DbKluby<T> : IKluby<T> where T : class
    {
        private readonly ReflectiveOrm<ItemKlub> _context;
        public DbKluby(ReflectiveOrm<ItemKlub> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemKlub>> GetKlub()
        {
            return await Task.Run(() => _context.Select());
        }

        public async Task<IEnumerable<ItemKlub>> GetKlubByName(string name)
        {
            return await Task.Run(() => _context.Where(klub => klub.KlubName == name).JoinedSelect());
        }

        public async Task<IEnumerable<ItemKlub>> GetKlubById(int id)
        {
            return await Task.Run(() => _context.Where(klub => klub.Kid == id).JoinedSelect());
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