using BrainSpineAnalytics.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrainSpineAnalytics.Infrastructure.Data
{
    public class BrainSpineDbContext : DbContext
    {
        public BrainSpineDbContext(DbContextOptions<BrainSpineDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleMapping> UserRoleMappings { get; set; }
        public DbSet<DummyFactRevenue> DummyFactRevenue { get; set; }
        public DbSet<DummyDimClinic> DummyDimClinic { get; set; }
        public DbSet<DummyDimProvider> DummyDimProvider { get; set; }
        public DbSet<DummyDimPayer> DummyDimPayer { get; set; }
        public DbSet<DummyDimProcedure> DummyDimProcedure { get; set; }
        public DbSet<DummyFactAppointments> DummyFactAppointments { get; set; }
        public DbSet<DummyDimUserRole> DummyDimUserRoles { get; set; }
        public DbSet<DummyDimUser> DummyDimUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).ValueGeneratedOnAdd();

                // Provider-agnostic filters are tricky; for Npgsql use this expression string:
                entity.HasIndex(e => e.Email)
                      .IsUnique()
                      .HasFilter("\"IsActive\" = TRUE AND \"IsDeleted\" = FALSE");

                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);

                // Use PostgreSQL now() for timestamp default
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(e => e.RoleId);
                entity.Property(e => e.RoleId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<UserRoleMapping>(entity =>
            {
                entity.ToTable("UserRoleMapping");
                entity.HasKey(e => e.UserRoleMappingId);
                entity.Property(e => e.UserRoleMappingId).ValueGeneratedOnAdd();

                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Role)
                      .WithMany()
                      .HasForeignKey(e => e.RoleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<DummyDimUser>()
             .ToTable("dummy_dim_user");


        }
    }
}
