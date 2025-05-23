﻿using BLL.IRepositories;
using DAL.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;
        public TokenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateJwtToken(ApplicationUser User, List<string> Roles)
        {
            // Create Claims

            var claims = new List<Claim> {
            new Claim(ClaimTypes.Email, User.Email),
            new Claim(ClaimTypes.Name, User.UserName), 
            new Claim(ClaimTypes.NameIdentifier, User.Id)
            };


            claims.AddRange(Roles.Select(role => new Claim(ClaimTypes.Role,role)));

            // Jwt Security Token Parameters

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentilas = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentilas
                );

            // Return Token

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
