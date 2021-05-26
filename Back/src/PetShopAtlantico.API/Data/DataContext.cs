using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.API.Models;

namespace PetShopAtlantico.API.Data
{
    
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<PetAloj> PetAlojs { get; set; }
    }
}