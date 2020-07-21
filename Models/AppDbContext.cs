using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// This allows a sub class to call the base class 'DbContext' non typed constructor
        /// This is need because instances of the subclasses will use a specifc typed DbContextOptions
        /// which can not be converted into the paramter in the above constructor
        /// </summary>
        /// <param name="options"></param>
        protected AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Student> StudentDB { get; set; }
        public DbSet<Competition> CompetitionDB { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            throw new Exception("This method must be overriden as we have database typenames which need to be defined");
        }

    }

    public class AppDbContextSQLServer : AppDbContext
    {

        public AppDbContextSQLServer(DbContextOptions<AppDbContextSQLServer> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

    }

    public class AppDbContextPostGresSQL : AppDbContext
    {
        /// <summary>
        /// Options will be of this specific type and we pass this to the protected not typed base class constructor
        /// </summary>
        /// <param name="options"></param>
        public AppDbContextPostGresSQL(DbContextOptions<AppDbContextPostGresSQL> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
