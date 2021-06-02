using System;
using System.Threading.Tasks;
using PetShopAtlantico.Application.Contratos;
using PetShopAtlantico.Domain;
using PetShopAtlantico.Persistence;
using PetShopAtlantico.Persistence.Contratos;

namespace PetShopAtlantico.Application
{
    public class PetAlojService : IPetAlojService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPetAlojPersist _petAlojPersist;
        public PetAlojService(IGeralPersist geralPersist, IPetAlojPersist petAlojPersist)
        {
            _petAlojPersist = petAlojPersist;
            _geralPersist = geralPersist;


        }
        public async Task<PetAloj> AddPetAlojs(PetAloj model)
        {
            try
            {
                _geralPersist.Add<PetAloj>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _petAlojPersist.GetPetAlojsByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PetAloj> UpdatePetAloj(int petalojId, PetAloj model)
        {
            try
            {
                var petaloj = await _petAlojPersist.GetPetAlojsByIdAsync(petalojId);
                if (petaloj == null) return null;

                model.Id = petaloj.Id;

                _geralPersist.Update(model);
                 if (await _geralPersist.SaveChangesAsync())
                {
                    return await _petAlojPersist.GetPetAlojsByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePetAloj(int petalojId)
        {
            
          try
            {
                var petaloj = await _petAlojPersist.GetPetAlojsByIdAsync(petalojId);
                if (petaloj == null) throw new Exception("Evento para delete não encontrado.");

                _geralPersist.Delete<PetAloj>(petaloj);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PetAloj[]> GetAllPetAlojsAsync()
        {
            try
            {
                var petaloj = await _petAlojPersist.GetAllPetAlojsAsync();
                if (petaloj == null) return null;

                return petaloj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PetAloj[]> GetAllPetAlojsByNomeAsync(string nome)
        {
            try
            {
                var petaloj = await _petAlojPersist.GetAllPetAlojsByNomeAsync(nome);
                if (petaloj == null) return null;

                return petaloj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PetAloj> GetPetAlojsByIdAsync(int petalojId)
        {
            try
            {
                var petaloj = await _petAlojPersist.GetPetAlojsByIdAsync(petalojId);
                if (petaloj == null) return null;

                return petaloj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}