using Microsoft.EntityFrameworkCore;
using PetCafe_Remake_.Data;
using PetCafe_Remake_.Interface;
using PetCafe_Remake_.Models;

namespace PetCafe_Remake_.Repository
{
    public class DogRepository : IDogRepository
    {
        private readonly ApplicationDbContext _context;

        public DogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Dog dog)
        {
            _context.Add(dog);
            return Save();
        }

        public bool Delete(Dog dog)
        {
            _context.Remove(dog);
            return Save();
        }

        public async Task<IEnumerable<Dog>> GetAll() //return list 
        {
            return await _context.Dogs.ToListAsync();
        }

        public async Task<Dog> GetByIdAsync(int id) //return single item //return single item / one to many relationship (join and inclue)
        {
            return await _context.Dogs.Include(i => i.VisitTime).FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Dog> GetByIdAsyncNoTracking(int id) // no tracking in editing , 否則會重疊
        {
            return await _context.Dogs.Include(i => i.VisitTime).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Dog dog)
        {
            _context.Update(dog);
            return Save();
        }
    }
}



