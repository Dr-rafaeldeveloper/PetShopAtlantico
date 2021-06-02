using System.Threading.Tasks;
using PetShopAtlantico.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Persistence.Contratos;
using PetShopAtlantico.Persistence.Contexto;

namespace PetShopAtlantico.Persistence
{
    public class PetAlojPersist : IPetAlojPersist
    {
        private readonly PetAlojContext _context;
        public PetAlojPersist(PetAlojContext context)
        {
            _context = context;
        }

        public async Task<PetAloj[]> GetAllPetAlojsAsync()
        {
            IQueryable<PetAloj> query = _context.PetAlojs;
            query = query.AsNoTracking().OrderBy(p => p.Id);
            return await query.ToArrayAsync();
        }

        public async Task<PetAloj[]> GetAllPetAlojsByNomeAsync(string nome)
        {
            IQueryable<PetAloj> query = _context.PetAlojs;
            query = query.AsNoTracking().OrderBy(p => p.Id)
                        .Where(p => p.AnimalName.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<PetAloj> GetPetAlojsByIdAsync(int petalojId)
        {
            IQueryable<PetAloj> query = _context.PetAlojs;
            query = query.AsNoTracking().OrderBy(p => p.Id)
                        .Where(p => p.Id == petalojId);
            return await query.FirstOrDefaultAsync();
        }

    }
}