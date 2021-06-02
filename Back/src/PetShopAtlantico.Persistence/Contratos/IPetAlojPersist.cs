using System.Threading.Tasks;
using PetShopAtlantico.Domain;

namespace PetShopAtlantico.Persistence.Contratos
{
    public interface IPetAlojPersist
    {
         Task<PetAloj[]> GetAllPetAlojsByNomeAsync(string nome);
         Task<PetAloj[]> GetAllPetAlojsAsync();
         Task<PetAloj> GetPetAlojsByIdAsync(int petalojId);
    }
}