using HotChocolate;
using HotChocolate.Data;

using HotChocolateGraphqlDemo.Api.Src.Graphql.DataLoaders;
using HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.AccountSchema;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.OwnerSchema
{
    public class OwnerType
    {
        [IsProjected(true)]
        public Guid Id { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public async Task<IEnumerable<AccountType>> Accounts([Service] AccountsByOwnerIdGroupedDataLoader dataLoader)
        {
            var data = await dataLoader.LoadAsync(Id);

            return data.Select(account => new AccountType()
            {
                Id = account.Id,
                Description = account.Description,
                Type = account.Type,
                OwnerId = account.OwnerId
            });
        }
    }
}
