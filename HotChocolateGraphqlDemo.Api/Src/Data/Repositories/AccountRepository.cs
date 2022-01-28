using HotChocolateGraphqlDemo.Api.Src.Data.Entities;

using System;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Data.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApiDbContext context) : base(context)
        {
        }

        public override async Task AddAsync(Account account)
        {
            account.Id = Guid.NewGuid();
            await _context.Accounts.AddAsync(account);
        }
    }
}
