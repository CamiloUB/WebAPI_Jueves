using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves.DAL.Entities;

namespace ShoppingAPI_Jueves.DAL
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)       
        {
         
        }

        #region DbSets

        public DbSet<Country> Countries { get; set; }
        // public DbSet<City> Cities { get; set; }
        // public DbSet<User> Users { get; set; }




        #endregion
    }
}
