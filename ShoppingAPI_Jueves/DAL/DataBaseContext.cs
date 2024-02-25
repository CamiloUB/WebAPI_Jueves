using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves.DAL.Entities;

namespace ShoppingAPI_Jueves.DAL
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)       
        {
         
        }
        // Método(de EF Core) me sirve para configurar unos indices de cada campo de una tabla en BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        }

        #region DbSets

        public DbSet<Country> Countries { get; set; }
        // public DbSet<City> Cities { get; set; }
        // public DbSet<User> Users { get; set; }




        #endregion
    }
}
