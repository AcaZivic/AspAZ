﻿using AspAZ.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Api.Core
{
    public class JwtManager
    {
        private readonly GameKingdomContext _context;
        private readonly string _issuer= "asp_api";
        private readonly string _secretKey="asp123";
        //, string issuer, string secretKey

        public JwtManager(GameKingdomContext context)
        {
            _context = context;
            //_issuer = issuer;
            //_secretKey = secretKey;
        }

        public string MakeToken(string username, string password)
        {
            var user = _context.Employees.Include(u => u.UseCases)
                .FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
            {
                return null;
            }

            var actor = new JwtActor
            {
                Id = user.Id,
                AllowedUseCases = user.UseCases.Select(x => x.UseCaseId),
                Username = user.Username
            };

            var claims = new List<Claim> // Jti : "", 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, _issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, _issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey+"potrebnoRadiRadaTokena-velicina-mora-biti-veca-od-256-bita"));
            
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(300),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
