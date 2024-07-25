using TestRestautantProductOnly.Model;

namespace TestRestautantProductOnly.Repository
{
    public interface  IUserRepository
    {
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(int id);
        Task AddAsync(Users user);
        Task UpdateAsync(Users user);
        Task DeleteAsync(int id);
    }
}
