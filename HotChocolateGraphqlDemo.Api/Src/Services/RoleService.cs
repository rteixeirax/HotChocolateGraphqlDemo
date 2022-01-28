using HotChocolateGraphqlDemo.Api.Src.Data.Entities;
using HotChocolateGraphqlDemo.Api.Src.Data.Repositories;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository _repo;

        public RoleService(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Role> CreateAsync(Role role)
        {
            await _repo.Roles.AddAsync(role);
            await _repo.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteAsync(Guid[] roleIds)
        {
            for (int i = 0; i < roleIds.Length; i++)
            {
                await DeleteAsync(roleIds[i]);
            }

            return true;
        }

        public async Task<string> DeleteAsync(Guid roleId)
        {
            var dataModel = await _repo.Roles.FindByIdAsync(roleId);
            _repo.Roles.Remove(dataModel);
            await _repo.SaveChangesAsync();
            return $"The role with the id: '{roleId}' has been successfully deleted from db.";
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var dataModels = await _repo.Roles.FindAllAsync();
            return dataModels;
        }

        public async Task<Role> GetByIdAsync(Guid roleId)
        {
            var dataModel = await _repo.Roles.FindByIdAsync(roleId);
            return dataModel;
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            var dataModel = await _repo.Roles.FindByIdAsync(role.Id);
            dataModel.Name = role.Name ?? dataModel.Name;
            dataModel.Code = role.Code ?? dataModel.Code;
            await _repo.SaveChangesAsync();
            return dataModel;
        }
    }
}
