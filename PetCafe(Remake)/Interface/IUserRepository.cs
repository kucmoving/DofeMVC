using PetCafe_Remake_.Models;

namespace PetCafe_Remake_.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<AppUser> GetUserById(string id);

        bool Update(AppUser user);

        bool Save();
    }
}
