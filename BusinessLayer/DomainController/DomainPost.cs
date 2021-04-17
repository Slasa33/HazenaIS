using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Items;

namespace BusinessLayer.DomainController
{
    public class DomainPost
    {
        private readonly UnitOfWork<ItemPost> _unitOfWork;
        
        public DomainPost()
        {
            _unitOfWork = new UnitOfWork<ItemPost>(new HazenaContext());
        }
        
        
        public async Task<IEnumerable<ItemPost>> SelectPosty()
        {
           return await _unitOfWork.Post.GetPost();
        }
        
        
    }
}