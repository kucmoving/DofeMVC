using Microsoft.EntityFrameworkCore;
using PetCafe_Remake_.Data;
using PetCafe_Remake_.Interface;
using PetCafe_Remake_.Models;


namespace PetCafe_Remake_.Repository
{

    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Event _event)
        {
            _context.Add(_event);
            return Save();
        }

        public bool Delete(Event _event)
        {
            _context.Remove(_event);
            return Save();
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetByIdAsync(int id) //return single item / one to many relationship (join and inclue)
        {
            return await _context.Events.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Event> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Events.Where(i => i.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public async Task<IEnumerable<Event>> GetEventByCity(string region)
        {
            return await _context.Events.Where(c => c.Region.Contains(region)).Distinct().ToListAsync();
        }

        public bool Update(Event _event)
        {
            _context.Update(_event);
            return Save();
        }

    }
}
