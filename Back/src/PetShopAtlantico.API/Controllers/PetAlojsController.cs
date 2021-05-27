using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShopAtlantico.API.Data;
using PetShopAtlantico.API.Models;

namespace PetShopAtlantico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetAlojsController : ControllerBase
    {
        private readonly DataContext _context;
        public PetAlojsController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<PetAloj> Get()
        {
            return _context.PetAlojs;
        }

        [HttpGet("{id}")]
        public PetAloj GetById(int id)
        {
            return _context.PetAlojs.FirstOrDefault(petaloj => petaloj.PetAlojId == id);
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
