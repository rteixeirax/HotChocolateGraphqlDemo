using HotChocolate;
using HotChocolate.Data;

using HotChocolateGraphqlDemo.Api.Src.Graphql.DataLoaders;
using HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.RoleSchema;
using HotChocolateGraphqlDemo.Api.Src.Models;

using System;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.UserSchema
{
    public class UserType
    {
        public Guid Id { get; set; }

        public EnumUserStatus Status { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        [IsProjected(true)]
        public Guid RoleId { get; set; }

        public async Task<RoleType> Role([Service] RoleBatchDataLoader dataLoader)
        {
            var data = await dataLoader.LoadAsync(RoleId);

            return new RoleType()
            {
                Id = data.Id,
                Name = data.Name,
                Code = data.Code
            };
        }
    }
}
