using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.DbTables.Interface;
using DataLayer.Items;
using ORM;

namespace DataLayer.DbTables
{
    public class ZapasyRepository<T> : IZapasy<T> where T : class
    {
        private readonly ReflectiveOrm<ItemZapasy> _context;
        
        public ZapasyRepository(ReflectiveOrm<ItemZapasy> context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<ItemZapasy>> GetZapasy()
        {
            return await Task.Run(() => _context.JoinedSelect());
        }

        public async Task<ItemZapasy> GetZapasById(int id)
        {
            return await Task.Run(() => _context.Where(zapasy => zapasy.Zid == id).JoinedSelect().ToList()[0]);
        }
        
        
    }
}