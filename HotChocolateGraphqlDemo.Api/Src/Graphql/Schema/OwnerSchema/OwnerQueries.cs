using HotChocolate.Types;

using HotChocolateGraphqlDemo.Api.Src.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.OwnerSchema
{
    [ExtendObjectType(GraphqlConstants.Query)]
    public class OwnerQueries
    {
        private readonly IOwnerService _ownerService;

        public OwnerQueries(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public async Task<OwnerType> GetOwner(Guid ownerId)
        {
            var owner = await _ownerService.GetOwnerAsync(ownerId);

            return new OwnerType()
            {
                Id = owner.Id,
                Name = owner.Name,
                Address = owner.Address
            };
        }

        public async Task<IEnumerable<OwnerType>> GetOwners()
        {
            var owners = await _ownerService.GetOwnersAsync();

            return owners.Select(account => new OwnerType()
            {
                Id = account.Id,
                Name = account.Name,
                Address = account.Address
            });
        }
    }
}
