using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Items;
using ORM;

namespace BusinessLayer.DomainController
{
    public class DomainHraci
    {
        private readonly UnitOfWork<ItemHrac> _unitOfWork;

        public DomainHraci()
        {
            _unitOfWork = new UnitOfWork<ItemHrac>(new DbContext());
        }
        
        
        public async Task<ItemHrac> SelectHracById(int id)
        {
            return await _unitOfWork.Hraci.GetHracById(id);
        }

        public async Task<IEnumerable<ItemHrac>> SelectHraciByKlubId(int id)
        {
            return await _unitOfWork.Hraci.GetHraciByKlubId(id);
        }

        public async Task UpdateHrac(ItemHrac hrac)
        {
            await _unitOfWork.Hraci.UpdateHrac(hrac);
        }

        public async Task InsertHrac(ItemHrac hrac)
        {
            await _unitOfWork.Hraci.InsertHrac(hrac);
        }

        public async Task DeleteHrac(ItemHrac hrac)
        {
            await _unitOfWork.Hraci.DeleteHrac(hrac);
        }
    }
}