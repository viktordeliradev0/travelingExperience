using Microsoft.EntityFrameworkCore;
using travelingExperience.DbConnetion;
using travelingExperience.Entity;


namespace travelingExperience.Data.Services
{
    public class TravelsService : ITravelsService
    {

        private readonly AppDbContext _context;
        public TravelsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Travel travel)
        {
            await _context.Travels.AddAsync(travel);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var result = await _context.Travels.FirstOrDefaultAsync(x => x.Id == id);
            _context.Travels.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Travel>> GetAllAsync()
        {
            var result = await _context.Travels.ToListAsync();
            return result;
        }

        public async Task<Travel> GetByIdAsync(int id)
        {
            var result = await _context.Travels.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Travel> UpdateAsync(int id, Travel newTravel)
        {
            _context.Travels.AddAsync(newTravel);
            await _context.SaveChangesAsync();
            return newTravel;
        }
    }
}
