using System.Threading.Tasks;
using PetShopAtlantico.Domain;

namespace PetShopAtlantico.Application.Contratos
{
    public interface IPetAlojService
    {
         Task<PetAloj> AddPetAlojs(PetAloj model);
         Task<PetAloj> UpdatePetAloj(int petalojId, PetAloj model);
         Task<bool> DeletePetAloj(int petalojId);
         
         Task<PetAloj[]> GetAllPetAlojsAsync();
         Task<PetAloj[]> GetAllPetAlojsByNomeAsync(string nome);
         Task<PetAloj> GetPetAlojsByIdAsync(int petAlojId);
    }
}