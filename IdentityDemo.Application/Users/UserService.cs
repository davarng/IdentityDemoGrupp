﻿using IdentityDemo.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDemo.Application.Users;
public class UserService(IIdentityUserService identityUserService) : IUserService
{
    public async Task<UserResultDto> CreateUserAsync(UserProfileDto user, string password)
    {
        return await identityUserService.CreateUserAsync(user, password, [new Claim("Department", "IT"),
            new Claim("ShoeSize", "42"), new Claim("First name", user.FirstName), new Claim("Last name", user.LastName)]);
    }

    public async Task<UserResultDto> SignInAsync(string email, string password) =>
        await identityUserService.SignInAsync(email, password);

    public async Task SignOutAsync() => await identityUserService.SignOutAsync();
}