using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
                
        }
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasOne(x => x.UserAddress)
                        .WithOne()
                        .HasForeignKey<UserAddress>(x => x.UserId);
                        //.Navigation(x => x.UserAddress)
                        //.UsePropertyAccessMode(PropertyAccessMode.Property);

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
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }

    }
}
