using TestRestautantProductOnly.Model;

namespace TestRestautantProductOnly.Service
{
    public interface IUserService
    {
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(int id);
        Task AddAsync(Users user);
        Task UpdateAsync(Users user);
        Task DeleteAsync(int id);
    }
}
