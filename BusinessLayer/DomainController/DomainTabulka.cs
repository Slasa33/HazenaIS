using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Items;

namespace BusinessLayer.DomainController
{
    public class DomainTabulka
    {
        private readonly UnitOfWork<ItemTabulka> _unitOfWork;

        public DomainTabulka()
        {
            _unitOfWork = new UnitOfWork<ItemTabulka>(new DbContext());
        }
        
        public async Task<IEnumerable<ItemTabulka>> SelectTabulku()
        {
            return await _unitOfWork.Tabulka.GetTabulku();
        }
        
    }
}