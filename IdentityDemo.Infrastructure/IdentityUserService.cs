using IdentityDemo.Application.Dtos;
using IdentityDemo.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using IdentityDemo.Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDemo.Infrastructure;

public class IdentityUserService
    (
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    RoleManager<ApplicationUser> roleManager
    ) : IIdentityUserService
{
    public async Task<UserResultDto> CreateUserAsync(UserProfileDto user, string password)
    {
        var result = await userManager.CreateAsync( new ApplicationUser
        {
            UserName = user.Email,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
        }, password);

        return new UserResultDto(result.Errors.FirstOrDefault()?.Description);
    }

    public Task<UserResultDto> SignInAsync(string email, string password)
    {
        throw new NotImplementedException();
    }
}
