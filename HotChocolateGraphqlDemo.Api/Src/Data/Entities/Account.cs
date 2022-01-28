using HotChocolateGraphqlDemo.Api.Src.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace HotChocolateGraphqlDemo.Api.Src.Data.Entities
{
    public class Account
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public EnumAccountType Type { get; set; }

        public Owner Owner { get; set; }

        public Guid OwnerId { get; set; }

    }

    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Type)
                .IsRequired();

            builder
               .Property(x => x.OwnerId)
               .IsRequired();

            // Constraints
            builder
                .HasOne(x => x.Owner)
                .WithMany(x => x.Accounts)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
