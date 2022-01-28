using HotChocolateGraphqlDemo.Api.Src.Data.Entities;

using GreenDonut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolateGraphqlDemo.Api.Src.Data.Repositories;

namespace HotChocolateGraphqlDemo.Api.Src.Graphql.DataLoaders
{
    public class AccountsByOwnerIdGroupedDataLoader : GroupedDataLoader<Guid, Account>
    {
        private readonly IRepository _repo;

        public AccountsByOwnerIdGroupedDataLoader(
            IRepository repository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options
        ) : base(batchScheduler, options)
        {
            _repo = repository;
        }

        protected override async Task<ILookup<Guid, Account>> LoadGroupedBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken
        )
        {
            IEnumerable<Account> data = await _repo.Accounts.FindAllAsync(entity => keys.Contains(entity.OwnerId));
            return data.ToLookup(entity => entity.OwnerId);
        }
    }
}
