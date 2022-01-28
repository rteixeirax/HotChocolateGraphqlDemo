using HotChocolateGraphqlDemo.Api.Src.Data.Entities;
using HotChocolateGraphqlDemo.Api.Src.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace HotChocolateGraphqlDemo.Api.Src.Data.Seeds
{
    class UserSeed : IEntityTypeConfiguration<User>
    {
        private readonly Guid _adminRoleId;

        public UserSeed(Guid adminRoleId)
        {
            _adminRoleId = adminRoleId;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Status = EnumUserStatus.Active,
                    Name = "Admin",
                    Email = "admin@mail.com",
                    Password = "123",
                    RoleId = _adminRoleId,
                }
            );
        }
    }
}
