using HotChocolate.Types;

using HotChocolateGraphqlDemo.Api.Src.Services;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.UserSchema
{
    [ExtendObjectType(GraphqlConstants.Query)]
    public class UserQueries
    {
        private readonly IUserService _userService;

        public UserQueries(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<UserType>> GetUsers()
        {
            var users = await _userService.GetAllAsync();

            return users.Select(user => new UserType()
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
