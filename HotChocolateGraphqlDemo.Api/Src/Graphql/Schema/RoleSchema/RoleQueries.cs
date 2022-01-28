using HotChocolate.Types;

using HotChocolateGraphqlDemo.Api.Src.Services;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.RoleSchema
{
    [ExtendObjectType(GraphqlConstants.Query)]
    public class RoleQueries
    {
        private readonly IRoleService _roleService;

        public RoleQueries(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<IEnumerable<RoleType>> GetRoles()
        {
            var roles = await _roleService.GetAllAsync();

            return roles.Select(role => new RoleType()
            {
                Id = role.Id,
                Name = role.Name,
                Code = role.Code
            });
        }
    }
}
