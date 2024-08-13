using System.Threading.Tasks;

namespace SyncPro
{
    public interface IUsersRepository
    {
        Task<bool> Insert(UsersControl user);
        Task<bool> Update(UsersControl user);
        Task<bool> UpdatePassword(UsersControl user);
        Task<UsersControl> GetByUsername(string username);
        Task<UsersControl> GetByEmail(string email);
        Task<int> InsertAndGetId(UsersControl user);
    }
}
