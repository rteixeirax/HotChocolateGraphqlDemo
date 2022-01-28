using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly ApiDbContext _context;
        private IAccountRepository _accountRepository;
        private IOwnerRepository _ownerRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;

        public Repository(IDbContextFactory<ApiDbContext> context)
        {
            _context = context.CreateDbContext();
        }

        public IAccountRepository Accounts => _accountRepository = _accountRepository ?? new AccountRepository(_context);

        public IOwnerRepository Owners => _ownerRepository = _ownerRepository ?? new OwnerRepository(_context);

        public IRoleRepository Roles => _roleRepository = _roleRepository ?? new RoleRepository(_context);

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
