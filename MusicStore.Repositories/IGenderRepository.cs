using MusicStore.Entities;

namespace MusicStore.Repositories
{
    public interface IGenderRepository
    {
        Task<ICollection<Gender>> ListAsync();
        Task<Gender?> GetAsync(int id);
        Task<int> AddAsync (Gender gender);
        Task UpdateAsync ();
        Task DeleteAsync (int id);
    }
}
