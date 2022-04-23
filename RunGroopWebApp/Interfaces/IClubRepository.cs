using RunGroopWebApp.Data.Enum;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetAll();

        Task<IEnumerable<Club>> GetSliceAsync(int offset, int size);

        Task<IEnumerable<Club>> GetClubsByState(string state);

        Task<IEnumerable<Club>> GetClubsByCategoryAndSliceAsync(ClubCategory category, int offset, int size);

        Task<List<State>> GetAllStates();

        Task<List<City>> GetAllCitiesByState(string state);

        Task<Club?> GetByIdAsync(int id);

        Task<Club?> GetByIdAsyncNoTracking(int id);

        Task<IEnumerable<Club>> GetClubByCity(string city);

        Task<int> GetCountAsync();

        Task<int> GetCountByCategoryAsync(ClubCategory category);

        bool Add(Club club);

        bool Update(Club club);

        bool Delete(Club club);

        bool Save();
    }
}