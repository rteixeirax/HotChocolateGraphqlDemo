using HotChocolate.Types;

using HotChocolateGraphqlDemo.Api.Src.Data.Entities;
using HotChocolateGraphqlDemo.Api.Src.Services;

using System;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.OwnerSchema
{
    [ExtendObjectType(GraphqlConstants.Mutation)]
    public class OwnerMutations
    {
        private readonly IOwnerService _ownerService;

        public OwnerMutations(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public async Task<OwnerType> OwnerCreateAsync(OwnerInsertInput data)
        {
            Owner entity = new()
            {
                Name = data.Name,
                Address = data.Address
            };

            await _ownerService.CreateOwnerAsync(entity);

            return new OwnerType()
            {
                Id = entity.Id,
                Name = entity.Name,
                Address = entity.Address
            };
        }

        public async Task<OwnerType> OwnerUpdateAsync(OwnerUpdateInput data)
        {
            Owner entity = new()
            {
                Id = data.Id,
                Name = data.Name,
                Address = data.Address
            };

            Owner updatedEntity = await _ownerService.UpdateOwnerAsync(entity);

            return new OwnerType()
            {
                Id = updatedEntity.Id,
                Name = updatedEntity.Name,
                Address = updatedEntity.Address
            };
        }

        public async Task<string> OwnerDeleteAsync(Guid ownerId)
        {
            return await _ownerService.DeleteOwnerAsync(ownerId);
        }
    }
}
