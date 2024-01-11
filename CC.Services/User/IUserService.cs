
using CC.Models.User;

namespace CC.Services.User;

public interface IUserService
{
    Task<bool> RegisterUserAsync(UserRegister model);
    Task<UserDetail?> GetUserByIdAsync(int userId);
    Task<bool> DeleteUserAsync(int userId);
}