using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Data.Enum;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _context;

        public ClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Club club)
        {
            _context.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
            _context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<List<State>> GetAllStates()
        {
            return await _context.States.ToListAsync();
        }

        public async Task<IEnumerable<Club>> GetSliceAsync(int offset, int size)
        {
            return await _context.Clubs.Include(i => i.Address).Skip(offset).Take(size).ToListAsync();
        }

        public async Task<IEnumerable<Club>> GetClubsByCategoryAndSliceAsync(ClubCategory category, int offset, int size)
        {
            return await _context.Clubs
                .Include(i => i.Address)
                .Where(c => c.ClubCategory == category)
                .Skip(offset)
                .Take(size)
                .ToListAsync();
        }

        public async Task<int> GetCountByCategoryAsync(ClubCategory category)
        {
            return await _context.Clubs.CountAsync(c => c.ClubCategory == category);
        }

        public async Task<Club?> GetByIdAsync(int id)
        {
            return await _context.Clubs.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Club?> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Clubs.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _context.Clubs.Where(c => c.Address.City.Contains(city)).Distinct().ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Club club)
        {
            _context.Update(club);
            return Save();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Clubs.CountAsync();
        }

        public async Task<IEnumerable<Club>> GetClubsByState(string state)
        {
            return await _context.Clubs.Where(c => c.Address.State.Contains(state)).ToListAsync();
        }

        public async Task<List<City>> GetAllCitiesByState(string state)
        {
            return await _context.Cities.Where(c => c.StateCode.Contains(state)).ToListAsync();
        }
    }
}