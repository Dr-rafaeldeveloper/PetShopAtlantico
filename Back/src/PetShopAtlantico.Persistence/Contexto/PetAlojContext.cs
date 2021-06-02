using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Domain;

namespace PetShopAtlantico.Persistence.Contexto
{
    
    public class PetAlojContext : DbContext
    {
        public PetAlojContext(DbContextOptions<PetAlojContext> options) : base(options) { }
        public DbSet<PetAloj> PetAlojs { get; set; }
    }
}