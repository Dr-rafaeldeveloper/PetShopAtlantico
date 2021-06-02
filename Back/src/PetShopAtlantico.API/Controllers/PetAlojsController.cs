using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShopAtlantico.Persistence;
using PetShopAtlantico.Domain;
using PetShopAtlantico.Persistence.Contexto;
using PetShopAtlantico.Application.Contratos;
using Microsoft.AspNetCore.Http;

namespace PetShopAtlantico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetAlojsController : ControllerBase
    {
        private readonly IPetAlojService _petAlojService;
        public PetAlojsController(IPetAlojService petAlojService)
        {
            _petAlojService = petAlojService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var petalojs = await _petAlojService.GetAllPetAlojsAsync();
                if(petalojs == null) return NotFound("Nenhum alojamento encontrado.");

                return Ok(petalojs);
            }
            catch (Exception ex)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar alojamentos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var petaloj = await _petAlojService.GetPetAlojsByIdAsync(id);
                if(petaloj == null) return NotFound("Alojamento por Id não encontrado.");

                return Ok(petaloj);
            }
            catch (Exception ex)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar alojamentos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var petaloj = await _petAlojService.GetAllPetAlojsByNomeAsync(nome);
                if(petaloj == null) return NotFound("Alojamentos por nome não encontrados.");

                return Ok(petaloj);
            }
            catch (Exception ex)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar alojamentos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PetAloj model)
        {
            try
            {
                var petaloj = await _petAlojService.AddPetAlojs(model);
                if(petaloj == null) return BadRequest("Erro ao tentar adicionar alojamento");

                return Ok(petaloj);
            }
            catch (Exception ex)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar alojamentos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PetAloj model)
        {
             try
            {
                var petaloj = await _petAlojService.UpdatePetAloj(id, model);
                if(petaloj == null) return BadRequest("Erro ao tentar adicionar alojamento");

                return Ok(petaloj);
            }
            catch (Exception ex)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar alojamentos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             try
            {
                if(await _petAlojService.DeletePetAloj(id))
                    return Ok("Deletado");
                else
                    return BadRequest("Alojamento não deletado");
            }
            catch (Exception ex)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar alojamentos. Erro: {ex.Message}");
            }
        }
    }
}
