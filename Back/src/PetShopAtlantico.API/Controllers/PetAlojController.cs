using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShopAtlantico.API.Models;

namespace PetShopAtlantico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetAlojController : ControllerBase
    {
        public IEnumerable<PetAloj> _petaloj = new PetAloj[]{

            new PetAloj() {
                PetAlojId = 1,
                AnimalName = "Pink",
                OwnerName = "Rafael",
                Telephone = 33360157,
                Address = "Rua Maria 51",
                State = "Recuperado",
                Reason = "Dor de barriga",
                Photo = "foto01.png" 
                },

            new PetAloj() {
                PetAlojId = 2,
                AnimalName = "Lisa",
                OwnerName = "Catarina",
                Telephone = 92124232,
                Address = "Rua Luiza 52",
                State = "Se recuperando",
                Reason = "Castração",
                Photo = "foto02.png" 
                }  
         };
        public PetAlojController()
        {
        }

        [HttpGet]
        public IEnumerable<PetAloj> Get()
        {
            return _petaloj;
        }

        [HttpGet("{id}")]
        public IEnumerable<PetAloj> GetById(int id)
        {
            return _petaloj.Where(petaloj => petaloj.PetAlojId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Delete com id = {id}";
        }
    }
}
