using HotChocolateGraphqlDemo.Api.Src.Data.Repositories;
using HotChocolateGraphqlDemo.Api.Src.Data.Entities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IRepository _repo;

        public OwnerService(IRepository apiRepo)
        {
            _repo = apiRepo;
        }

        public async Task<Owner> CreateOwnerAsync(Owner owner)
        {
            await _repo.Owners.AddAsync(owner);
            await _repo.SaveChangesAsync();
            return owner;
        }

        public async Task<string> DeleteOwnerAsync(Guid ownerId)
        {
            var dbOwner = await _repo.Owners.FindByIdAsync(ownerId);
            _repo.Owners.Remove(dbOwner);
            await _repo.SaveChangesAsync();
            return $"The owner with the id: {ownerId} has been successfully deleted from db.";
        }

        public async Task<Owner> GetOwnerAsync(Guid ownerId)
        {
            var owner = await _repo.Owners.FindByIdAsync(ownerId);
            return owner;
        }

        public async Task<IEnumerable<Owner>> GetOwnersAsync()
        {
            var owners = await _repo.Owners.FindAllAsync();
            return owners;
        }

        public async Task<Owner> UpdateOwnerAsync(Owner owner)
        {
            var dbOwner = await _repo.Owners.FindByIdAsync(owner.Id);
            dbOwner.Name = owner.Name ?? dbOwner.Name;
            dbOwner.Address = owner.Address ?? dbOwner.Address;
            await _repo.SaveChangesAsync();
            return dbOwner;
        }
    }
}
