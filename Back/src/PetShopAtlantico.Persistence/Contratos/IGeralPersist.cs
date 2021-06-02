using System.Threading.Tasks;
using PetShopAtlantico.Domain;

namespace PetShopAtlantico.Persistence.Contratos
{
    public interface IGeralPersist
    {
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         void DeleteRanger<T>(T[] entity) where T: class;
         Task<bool> SaveChangesAsync();
    }
}