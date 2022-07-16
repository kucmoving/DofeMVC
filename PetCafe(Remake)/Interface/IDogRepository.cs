using PetCafe_Remake_.Models;

namespace PetCafe_Remake_.Interface
{
    public interface IDogRepository
    {
        Task<IEnumerable<Dog>> GetAll();
        Task<Dog> GetByIdAsync(int id);

        Task<Dog> GetByIdAsyncNoTracking(int id);
        bool Add(Dog dog);
        bool Update(Dog dog);
        bool Delete(Dog dog);
        bool Save();

    }
}
