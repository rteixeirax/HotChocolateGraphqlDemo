using HotChocolateGraphqlDemo.Api.Src.Data.Entities;
using HotChocolateGraphqlDemo.Api.Src.Data.Repositories;
using HotChocolateGraphqlDemo.Api.Src.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository _repo;

        public AccountService(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            await _repo.Accounts.AddAsync(account);
            await _repo.SaveChangesAsync();
            return account;
        }

        public async Task<string> DeleteAccountAsync(Guid accountId)
        {
            var dbAccount = await _repo.Accounts.FindByIdAsync(accountId);
            _repo.Accounts.Remove(dbAccount);
            await _repo.SaveChangesAsync();
            return $"The account with the id: {accountId} has been successfully deleted from db.";
        }

        public async Task<Account> GetAccountAsync(Guid accountId)
        {
            var account = await _repo.Accounts.FindByIdAsync(accountId);
            return account;
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            var accounts = await _repo.Accounts.FindAllAsync();
            return accounts;
        }

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            var dbAccount = await _repo.Accounts.FindByIdAsync(account.Id);
            dbAccount.Description = account.Description ?? dbAccount.Description;
            dbAccount.Type = Enum.IsDefined(typeof(EnumAccountType), account.Type) ? account.Type : dbAccount.Type;
            dbAccount.OwnerId = account.OwnerId != Guid.Empty ? account.OwnerId : dbAccount.OwnerId;
            await _repo.SaveChangesAsync();
            return dbAccount;
        }
    }
}
