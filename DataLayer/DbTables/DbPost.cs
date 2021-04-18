using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.DbTables.Interface;
using DataLayer.Items;
using ORM;

namespace DataLayer.DbTables
{
    public class PostRepository<T> : IPost<T> where T : class
    {
        private readonly ReflectiveOrm<ItemPost> _context;
        
        public PostRepository(ReflectiveOrm<ItemPost> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemPost>> GetPost()
        {
            return await Task.Run(() => _context.Select());
        }
    }
}