﻿using JwtApp.Back.Core.Application.Features.CQRS.Queries.CheckUser;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtApp.Back.Infrastructure.Token
{
    public class JwtGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Core.Application.DTOs.Token CreateAccessToken(CheckUserQueryResponse response)
        {

            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(response.Role))
                claims.Add(new Claim(ClaimTypes.Role, response.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, response.Id.ToString()));

            if (!string.IsNullOrEmpty(response.Username))
                claims.Add(new Claim("Username", response.Username));

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Core.Application.DTOs.Token token = new();
            token.Expiration = DateTime.UtcNow.AddDays(5);

            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials,
                claims: claims
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
