using HotChocolateGraphqlDemo.Api.Src.Data.Entities;
using HotChocolateGraphqlDemo.Api.Src.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace HotChocolateGraphqlDemo.Api.Src.Data.Seeds
{
    class RoleSeed : IEntityTypeConfiguration<Role>
    {
        private readonly Guid _adminRoleId;

        public RoleSeed(Guid adminRoleId)
        {
            _adminRoleId = adminRoleId;
        }

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Id = _adminRoleId,
                    Name = EnumRoleCode.Admin.ToString(),
                    Code = EnumRoleCode.Admin.ToString().ToLower(),
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = EnumRoleCode.User.ToString(),
                    Code = EnumRoleCode.User.ToString().ToLower(),
                }
            );
        }
    }
}
