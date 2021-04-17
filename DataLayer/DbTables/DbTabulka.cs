using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Items;
using DataLayer.Repository.Interface;
using ORM;

namespace DataLayer.Repository
{
    public class TabulkaRepository<T> : ITabulkaRepository<T> where T : class
    {
        private readonly ReflectiveOrm<ItemTabulka> _context;
        public TabulkaRepository(ReflectiveOrm<ItemTabulka> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemTabulka>> GetTabulku()
        {
            return await Task.Run(() => _context.JoinedSelect());
        }
    }
}