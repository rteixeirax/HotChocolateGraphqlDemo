using HotChocolate.Types;

using HotChocolateGraphqlDemo.Api.Src.Data.Entities;
using HotChocolateGraphqlDemo.Api.Src.Services;

using System;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.AccountSchema
{
    [ExtendObjectType(GraphqlConstants.Mutation)]
    public class AccountMutations
    {
        private readonly IAccountService _accountService;

        public AccountMutations(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<AccountType> AccountCreateAsync(AccountInsertInput data)
        {
            Account entity = new()
            {
                Description = data.Description,
                Type = data.Type,
                OwnerId = data.OwnerId
            };

            await _accountService.CreateAccountAsync(entity);

            return new AccountType()
            {
                Id = entity.Id,
                Description = entity.Description,
                Type = entity.Type,
                OwnerId = entity.OwnerId
            };
        }

        public async Task<AccountType> AccountUpdateAsync(AccountUpdateInput data)
        {
            Account entity = new()
            {
                Id = data.Id,
                Description = data.Description,
                Type = data.Type,
                OwnerId = data.OwnerId
            };

            Account updatedEntity = await _accountService.UpdateAccountAsync(entity);

            return new AccountType()
            {
                Id = updatedEntity.Id,
                Description = updatedEntity.Description,
                Type = updatedEntity.Type,
                OwnerId = updatedEntity.OwnerId
            };
        }

        public async Task<string> AccountDeleteAsync(Guid accountId)
        {
            return await _accountService.DeleteAccountAsync(accountId);
        }
    }
}
