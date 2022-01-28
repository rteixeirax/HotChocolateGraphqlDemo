using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;

namespace HotChocolateGraphqlDemo.Api.Src.Data.Entities
{
    public class Owner
    {
        public Guid Id { get; set; }

        public IEnumerable<Account> Accounts { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }
    }

    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired();

            // Constraints
            builder
                .HasMany(x => x.Accounts)
                .WithOne(x => x.Owner)
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
