using Microsoft.EntityFrameworkCore;
using MotoApp.Data.Entities;

namespace MotoApp.Data
{
    public class MotoAppDbContext: DbContext
    {
        public DbSet<Employee> Employee => Set<Employee>();

        public DbSet<BusinessPartner> BusinessPartners => Set<BusinessPartner>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb"); //nazwa bazy danych w pamięci
        }
    }
}
