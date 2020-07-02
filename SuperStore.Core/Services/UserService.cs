using SuperStore.Core.Entities;
using SuperStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SuperStore.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IAsyncRepository<User> _userRepository;
        public UserService(IAsyncRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> CreateUserAsync(User user)
        {
          return await _userRepository.AddAsync(user);
        }

        public async Task<User> LoginAsync(string userName, string password)
        {
            var user = (await _userRepository.ListAllAsync()).Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            return user;
        }

        public Task<User> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExistsAsync(string userName)
        {
            var user = (await _userRepository.ListAllAsync()).Where(x => x.UserName == userName).FirstOrDefault();

            if (user!=null)
                return true;

            return false;
        }

    }
}
