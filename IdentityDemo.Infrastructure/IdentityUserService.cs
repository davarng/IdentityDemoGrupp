using IdentityDemo.Application.Dtos;
using IdentityDemo.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using IdentityDemo.Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDemo.Infrastructure;

public class IdentityUserService
    (
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager
    ) : IIdentityUserService
{
    public async Task<UserResultDto> CreateUserAsync(UserProfileDto user, string password, Claim[] claimArray)
    {
        var applicationUser = new ApplicationUser
        {
            UserName = user.Email,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };

        var result = await userManager.CreateAsync(applicationUser, password);

        if (!result.Succeeded)
            return new UserResultDto(result.Errors.FirstOrDefault()?.Description);


        await userManager.AddClaimsAsync(applicationUser, claimArray);

        return new UserResultDto(null);
    }

    public async Task<UserResultDto> SignInAsync(string email, string password)
    {
        var result = await signInManager.PasswordSignInAsync(email, password, false, false);
        return new UserResultDto(result.Succeeded ? null : "Invalid user credentials");
    }
}
