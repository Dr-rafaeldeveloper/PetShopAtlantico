using System.Threading.Tasks;
using PetShopAtlantico.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Persistence.Contratos;
using PetShopAtlantico.Persistence.Contexto;

namespace PetShopAtlantico.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly PetAlojContext _context;
        public GeralPersist(PetAlojContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRanger<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}