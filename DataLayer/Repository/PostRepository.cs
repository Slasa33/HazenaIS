using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Items;
using DataLayer.Repository.Interface;
using ORM;

namespace DataLayer.Repository
{
    public class PostRepository<T> : IPostRepository<T> where T : class
    {
        private readonly ReflectiveOrm<ItemPost> _context;
        
        public PostRepository(ReflectiveOrm<ItemPost> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemPost>> GetPost()
        {
            return await Task.Run(() => _context.Get());
        }
    }
}