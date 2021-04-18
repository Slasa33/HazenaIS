using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.DbTables.Interface;
using DataLayer.Items;
using ORM;

namespace DataLayer.DbTables
{
    public class DbTabulka<T> : ITabulka<T> where T : class
    {
        private readonly ReflectiveOrm<ItemTabulka> _context;
        public DbTabulka(ReflectiveOrm<ItemTabulka> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemTabulka>> GetTabulku()
        {
            return await Task.Run(() => _context.JoinedSelect());
        }
    }
}