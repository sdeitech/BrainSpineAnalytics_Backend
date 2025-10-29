using BrainSpineAnalytics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainSpineAnalytics.Infrastructure.Data
{
    public class BrainSpineDBContext:DbContext
    {
        public BrainSpineDBContext(DbContextOptions<BrainSpineDBContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleMapping> UserRoleMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example configuration for User
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users"); // <-- FIX: Use .ToTable() from Microsoft.EntityFrameworkCore

                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId)
                      .ValueGeneratedOnAdd();

                entity.HasIndex(e => e.Email)
                      .IsUnique()
                      .HasFilter("[IsActive] = 1");

                entity.Property(e => e.IsActive)
                      .HasDefaultValue(true);

                entity.Property(e => e.IsDeleted)
                      .HasDefaultValue(false);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("GETDATE()");

            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(e => e.RoleId);
                entity.Property(e => e.RoleId)
                      .ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<UserRoleMapping>(entity =>
            {
                entity.ToTable("UserRoleMappings");
                entity.HasKey(e => e.UserRoleMappingId);
                entity.Property(e => e.UserRoleMappingId)
                      .ValueGeneratedOnAdd();

                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Role)
                      .WithMany()
                      .HasForeignKey(e => e.RoleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
