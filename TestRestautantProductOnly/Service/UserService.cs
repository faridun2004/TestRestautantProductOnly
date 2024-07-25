using TestRestautantProductOnly.Model;
using TestRestautantProductOnly.Repository;

namespace TestRestautantProductOnly.Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Users user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(Users user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
