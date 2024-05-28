using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entidade in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var propriedade in entidade.GetProperties())
                {
                    // datetime conversion
                    if (propriedade.Name == "CreatedOn" || propriedade.Name == "UpdatedOn")
                    {
                        propriedade.SetColumnType("datetime");
                    }
                }
            }
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

    }
}
