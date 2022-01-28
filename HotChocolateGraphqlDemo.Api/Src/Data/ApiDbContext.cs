using HotChocolateGraphqlDemo.Api.Src.Data.Entities;
using HotChocolateGraphqlDemo.Api.Src.Data.Seeds;

using Microsoft.EntityFrameworkCore;

using System;

namespace HotChocolateGraphqlDemo.Api.Src.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ids = new Guid[] { Guid.NewGuid(), Guid.NewGuid() };
            var adminRoleId = Guid.NewGuid();

            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            // Seed
            modelBuilder.ApplyConfiguration(new AccountSeed(ids));
            modelBuilder.ApplyConfiguration(new OwnerSeed(ids));
            modelBuilder.ApplyConfiguration(new RoleSeed(adminRoleId));
            modelBuilder.ApplyConfiguration(new UserSeed(adminRoleId));
        }
    }
}
