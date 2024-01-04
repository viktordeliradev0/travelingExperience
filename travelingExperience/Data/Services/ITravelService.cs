using travelingExperience.Entity;


namespace travelingExperience.Data.Services
{
    public interface ITravelsService

    {
        Task<IEnumerable<Travel>> GetAllAsync();
        Task<Travel> GetByIdAsync(int id);

        Task AddAsync(Travel travel);

        Task<Travel> UpdateAsync(int id,Travel travel);

        Task DeleteAsync(int id);
      
    }
}
