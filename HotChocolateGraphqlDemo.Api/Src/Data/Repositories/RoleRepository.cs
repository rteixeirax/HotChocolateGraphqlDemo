using HotChocolateGraphqlDemo.Api.Src.Data.Entities;

using System;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Data.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApiDbContext context) : base(context)
        {
        }

        public override async Task AddAsync(Role role)
        {
            role.Id = Guid.NewGuid();
            await _context.Roles.AddAsync(role);
        }
    }
}
