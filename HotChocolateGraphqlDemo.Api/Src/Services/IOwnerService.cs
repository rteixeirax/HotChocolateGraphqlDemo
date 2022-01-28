using HotChocolateGraphqlDemo.Api.Src.Data.Entities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Services
{
    public interface IOwnerService
    {
        Task<Owner> CreateOwnerAsync(Owner owner);

        Task<string> DeleteOwnerAsync(Guid ownerId);

        Task<Owner> GetOwnerAsync(Guid ownerId);

        Task<IEnumerable<Owner>> GetOwnersAsync();

        Task<Owner> UpdateOwnerAsync(Owner owner);
    }
}
