using HotChocolateGraphqlDemo.Api.Src.Data.Entities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Services
{
    public interface IAccountService
    {
        Task<Account> CreateAccountAsync(Account account);

        Task<string> DeleteAccountAsync(Guid accountId);

        Task<Account> GetAccountAsync(Guid accountId);

        Task<IEnumerable<Account>> GetAccountsAsync();

        Task<Account> UpdateAccountAsync(Account account);
    }
}
