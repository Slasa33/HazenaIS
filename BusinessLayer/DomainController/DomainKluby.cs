using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Items;

namespace BusinessLayer.DomainController
{
    public class DomainKluby
    {
        private readonly UnitOfWork<ItemKlub> _unitOfWork;

        public DomainKluby()
        {
            _unitOfWork = new UnitOfWork<ItemKlub>(new HazenaContext());
        }

        public async Task<IEnumerable<ItemKlub>> SelectKluby()
        {
            return await _unitOfWork.Kluby.GetKlub();
        }

        public async Task<IEnumerable<ItemKlub>> SelectKlub(string name)
        {
            return await _unitOfWork.Kluby.GetKlubByName(name);
        }

        public async Task<IEnumerable<ItemKlub>> SelectKlubById(int id)
        {
           return await _unitOfWork.Kluby.GetKlubById(id);
        }

        public async Task InsertKlub(ItemKlub klub)
        {
            await _unitOfWork.Kluby.InsertKlub(klub);
        }

        public async Task UpdateKlub(ItemKlub klub)
        {
            await _unitOfWork.Kluby.UpdateKlub(klub);
        }

    }
}