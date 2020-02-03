using System.Collections.Generic;
using System.Threading.Tasks;
using Application;
using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class UserManagerService : IUserManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public UserManagerService(UserManager<ApplicationUser> userManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<bool> CreateUserAsync(string userName, string password, string email = "")
        {
            var checkExist = await _userManager.FindByNameAsync(userName);

            if (checkExist == null)
            {
                var user = new ApplicationUser
                {
                UserName = userName,
                Email = email
                };

                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        public async Task<Result> DeleteUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);

                if (result != null)
                {
                    return result.ToApplicationResult();
                }

                return Result.Failure(new List<string> { "Delete could not be performed." });
            }

            return Result.Failure(new List<string> { "User could not be found." });
        }

        public async Task<IApplicationUser> FindByNameAsync(string userName)
        {
            var result = await _userManager.FindByNameAsync(userName);

            return result;
        }

        public async Task<Result> ChangePasswordAsync(string userName, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

                if (result.Succeeded)
                {
                    return Result.Success();
                }

                return Result.Failure(new List<string> { "ChangePasswordAsync failed." });
            }

            return Result.Failure(new List<string> { "Could not find the user to update." });
        }

        public async Task<Result> GenerateChangeEmailTokenAsync(string userName, string newEmail)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var token = await _userManager.GenerateChangeEmailTokenAsync(user, newEmail);

                if (token != null)
                {
                    var result = await _userManager.ChangeEmailAsync(user, newEmail, token);

                    if (result.Succeeded)
                    {
                        return Result.Success();
                    }

                    return Result.Failure(new List<string> { "Could change the email." });
                }

                return Result.Failure(new List<string> { "Could get token for email change." });
            }

            return Result.Failure(new List<string> { "Could not find the user." });
        }

        public async Task<string> CheckPasswordAsync(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, password);

                if (result)
                {
                    var token = _jwtGenerator.CreateToken(user);
                    return token;
                }

                return "";
            }

            return "";
        }
    }
}