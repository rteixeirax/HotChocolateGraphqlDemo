using HotChocolate;
using HotChocolate.Data;

using HotChocolateGraphqlDemo.Api.Src.Graphql.DataLoaders;
using HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.UserSchema;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.RoleSchema
{
    public class RoleType
    {
        [IsProjected(true)]
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public async Task<IEnumerable<UserType>> Users([Service] UsersByRoleIdGroupedDataLoader dataLoader)
        {
            var data = await dataLoader.LoadAsync(Id);

            return data.Select(user => new UserType()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Status = user.Status,
                RoleId = user.RoleId
            });
        }
    }
}
