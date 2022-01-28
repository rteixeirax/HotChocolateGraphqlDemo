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
    public class UsersByRoleIdGroupedDataLoader : GroupedDataLoader<Guid, User>
    {
        private readonly IRepository _repo;

        public UsersByRoleIdGroupedDataLoader(
            IRepository repository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options
        ) : base(batchScheduler, options)
        {
            _repo = repository;
        }

        protected override async Task<ILookup<Guid, User>> LoadGroupedBatchAsync(
             IReadOnlyList<Guid> keys,
             CancellationToken cancellationToken
         )
        {
            IEnumerable<User> data = await _repo.Users.FindAllAsync(entity => keys.Contains(entity.RoleId));
            return data.ToLookup(entity => entity.RoleId);
        }
    }
}
