using JwtApp.Back.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JwtApp.Back.Persistence.Context
{
    public class JwtAppContext : DbContext
    {
        public JwtAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
