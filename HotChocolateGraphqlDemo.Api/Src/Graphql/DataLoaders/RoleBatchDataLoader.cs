using GreenDonut;

using HotChocolateGraphqlDemo.Api.Src.Data.Entities;
using HotChocolateGraphqlDemo.Api.Src.Data.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Graphql.DataLoaders
{
    public class RoleBatchDataLoader : BatchDataLoader<Guid, Role>
    {
        private readonly IRepository _repo;

        public RoleBatchDataLoader(
            IRepository repository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options
        ) : base(batchScheduler, options)
        {
            _repo = repository;
        }

        protected override async Task<IReadOnlyDictionary<Guid, Role>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken
        )
        {
            IEnumerable<Role> data = await _repo.Roles.FindAllAsync(entity => keys.Contains(entity.Id));
            return data.ToDictionary(entity => entity.Id);
        }
    }
}
