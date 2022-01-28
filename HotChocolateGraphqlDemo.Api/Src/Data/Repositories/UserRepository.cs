using HotChocolateGraphqlDemo.Api.Src.Data.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApiDbContext context) : base(context)
        {
        }

        public override async Task AddAsync(User user)
        {
            user.Id = Guid.NewGuid();
            await _context.Users.AddAsync(user);
        }

        public async Task<IEnumerable<User>> FindAllWithRoleAsync(Expression<Func<User, bool>> expression)
        {
            return await _context.Users.Include(x => x.Role).Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<User>> FindAllWithRoleAsync()
        {
            return await _context.Users.Include(x => x.Role).ToListAsync();
        }

        public async Task<User> FindByIdWithRoleAsync(Guid id)
        {
            return await _context.Users
                .Include(user => user.Role)
                .Where(user => user.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<User> FindOneWithRoleAsync(Expression<Func<User, bool>> expression)
        {
            return await _context.Users.Include(x => x.Role).SingleOrDefaultAsync(expression);
        }
    }
}
