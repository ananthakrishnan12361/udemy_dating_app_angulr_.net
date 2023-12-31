﻿using System.Security.Cryptography;
using System.Text;
using API.Controllers;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API;

public class AccountController : BaseApiController  //the url like /api/account/+url  the api come from BaseApiController,Account come from this AccountController Account
{
    private readonly DataContext _context;

    public AccountController(DataContext context)
    {
        _context = context;
    }
    [HttpPost("register")] // api/account/register
    public async Task<ActionResult<AppUser>>Register(string username,string password)
    {
            using  var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = username,
                PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt=hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;

    }
}
