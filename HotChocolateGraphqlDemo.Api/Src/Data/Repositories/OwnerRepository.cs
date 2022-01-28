using HotChocolateGraphqlDemo.Api.Src.Data.Entities;

using System;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Data.Repositories
{
    public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(ApiDbContext context) : base(context)
        {
        }

        public override async Task AddAsync(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            await _context.Owners.AddAsync(owner);
        }
    }
}
