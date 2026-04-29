using GameStore.Models;

namespace GameStore.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        User? GetByEmail(string email); // synchronous for seed
        Task AddAsync(User user);
        void Add(User user); // synchronous for seed
    }
}
