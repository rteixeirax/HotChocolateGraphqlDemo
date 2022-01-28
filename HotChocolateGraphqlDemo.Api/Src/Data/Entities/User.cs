using HotChocolateGraphqlDemo.Api.Src.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace HotChocolateGraphqlDemo.Api.Src.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public Guid RoleId { get; set; }

        public EnumUserStatus Status { get; set; }
    }

    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
               .HasKey(x => x.Id);

            builder
                .Property(x => x.Status)
                .HasDefaultValue(EnumUserStatus.Active);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .IsRequired();

            builder
                .Property(x => x.Password)
                .IsRequired();

            builder
               .Property(x => x.RoleId)
               .IsRequired();

            // Contraints
            builder
                .HasIndex(x => x.Email)
                .IsUnique()
                .HasDatabaseName("UniqueUserEmail");

            builder
                .HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
