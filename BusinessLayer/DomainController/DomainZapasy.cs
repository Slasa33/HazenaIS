using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Items;

namespace BusinessLayer.DomainController
{
    public class DomainZapasy
    {
        private readonly UnitOfWork<ItemZapasy> _unitOfWork;


        public DomainZapasy()
        {
            _unitOfWork = new UnitOfWork<ItemZapasy>(new HazenaContext());
        }
        
        public async Task<IEnumerable<ItemZapasy>> SelectZapasy()
        {
            return await _unitOfWork.Zapasy.GetZapasy();
        }

        public async Task<ItemZapasy> GetZapasById(int id)
        {
           return await _unitOfWork.Zapasy.GetZapasById(id);
        }
        
    }
}