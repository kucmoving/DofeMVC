using PetCafe_Remake_.Models;

namespace PetCafe_Remake_.Interface
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event> GetByIdAsync(int id);
        Task<IEnumerable<Event>> GetEventByCity(string region);
        Task<Event> GetByIdAsyncNoTracking(int id);
        bool Add(Event _event);
        bool Update(Event _event);
        bool Delete(Event _event);
        bool Save();
    }
}
