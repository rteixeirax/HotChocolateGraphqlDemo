using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;

namespace HotChocolateGraphqlDemo.Api.Src.Data.Entities
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public IEnumerable<User> Users { get; set; }
    }

    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Code)
                .IsRequired();

            // Constraints
            builder
                .HasIndex(x => x.Code)
                .IsUnique()
                .HasDatabaseName("UniqueCode");

            builder
                .HasMany(x => x.Users)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
