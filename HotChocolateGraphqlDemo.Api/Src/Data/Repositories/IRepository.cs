using System.Threading.Tasks;

namespace HotChocolateGraphqlDemo.Api.Src.Data.Repositories
{
    public interface IRepository
    {
        IAccountRepository Accounts { get; }
        IOwnerRepository Owners { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }

        Task<int> SaveChangesAsync();
    }
}
