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
    public class OwnerBatchDataLoader : BatchDataLoader<Guid, Owner>
    {
        private readonly IRepository _repo;

        public OwnerBatchDataLoader(
            IRepository repository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options
        ) : base(batchScheduler, options)
        {
            _repo = repository;
        }

        protected override async Task<IReadOnlyDictionary<Guid, Owner>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken
        )
        {
            IEnumerable<Owner> data = await _repo.Owners.FindAllAsync(entity => keys.Contains(entity.Id));
            return data.ToDictionary(entity => entity.Id);
        }
    }
}
