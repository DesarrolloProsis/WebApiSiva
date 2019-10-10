using Microsoft.EntityFrameworkCore;
using WebApiSiva.Models;

namespace WebApiSiva.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsRequired();

                entity.Property(e => e.PasswordHash)
                    .IsRequired();

                entity.Property(e => e.PasswordSalt)
                    .IsRequired();
            });
        }
    }
}