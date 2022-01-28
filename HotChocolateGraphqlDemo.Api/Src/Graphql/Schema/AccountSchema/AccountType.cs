using HotChocolate;
using HotChocolate.Data;

using HotChocolateGraphqlDemo.Api.Src.Graphql.DataLoaders;
using HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.OwnerSchema;
using HotChocolateGraphqlDemo.Api.Src.Models;

using System;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.AccountSchema
{
    public class AccountType
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public EnumAccountType Type { get; set; }

        [IsProjected(true)]
        public Guid OwnerId { get; set; }

        public async Task<OwnerType> Owner([Service] OwnerBatchDataLoader dataLoader)
        {
            var data = await dataLoader.LoadAsync(OwnerId);

            return new OwnerType()
            {
                Id = data.Id,
                Name = data.Name,
                Address = data.Address
            };
        }
    }
}
