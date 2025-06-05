using System.Security.Claims;
using IdentityDemo.Application.Dtos;

namespace IdentityDemo.Application.Users;

public interface IIdentityUserService
{
    Task<UserResultDto> CreateUserAsync(UserProfileDto user, string password, Claim[] claimArray);

    Task<UserResultDto> SignInAsync(string email, string password);

    Task SignOutAsync();
}