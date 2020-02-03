using System.Threading.Tasks;
using Application.Common.Models;

namespace Application.Common.Interfaces
{
    public interface IUserManagerService
    {
        Task<bool> CreateUserAsync(string userName, string password, string email = "");
        Task<Result> DeleteUserAsync(string userName);
        Task<IApplicationUser> FindByNameAsync(string userName);
        Task<Result> ChangePasswordAsync(string userName, string currentPassword, string newPassword);
        Task<Result> GenerateChangeEmailTokenAsync(string userName, string newEmail);
        Task<string> CheckPasswordAsync(string userName, string password);
    }
}