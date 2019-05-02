using CozyCo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CozyCo.Data.Context
{
    // DbContext -> represent a session to a db and provides APIs
    // to communicate with db
    public class CozyCoDbContext : DbContext
    {
        // Represents a collection (table) of a giving entity/model
        // They map to table by default
        public DbSet<Property> Properties { get; set; }

        // Virtual method designed to be overridden
        // You can provide configuration information for the context
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string is divided in 3 elements
            // server - database - authentication
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=cozyco;Trusted_Connection=true");
        }
    }
}
