using HotChocolate.Types;

using HotChocolateGraphqlDemo.Api.Src.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.AccountSchema
{
    [ExtendObjectType(GraphqlConstants.Query)]
    public class AccountQueries
    {
        private readonly IAccountService _accountService;

        public AccountQueries(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<AccountType> GetAccount(Guid accountId)
        {
            var account = await _accountService.GetAccountAsync(accountId);

            return new AccountType()
            {
                Id = account.Id,
                Description = account.Description,
                Type = account.Type,
                OwnerId = account.OwnerId
            };
        }

        public async Task<IEnumerable<AccountType>> GetAccounts()
        {
            var accounts = await _accountService.GetAccountsAsync();

            return accounts.Select(account => new AccountType()
            {
                Id = account.Id,
                Description = account.Description,
                Type = account.Type,
                OwnerId = account.OwnerId
            });
        }
    }
}
