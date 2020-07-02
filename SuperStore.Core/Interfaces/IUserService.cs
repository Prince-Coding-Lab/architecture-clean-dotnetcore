using SuperStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperStore.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> UserExistsAsync(string userName);
        Task<User> LoginAsync(string username, string password);
        // Task<User> DeleteUserAsync(User user);
    }
}
