using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Rotina.Domain.Commands;
using Rotina.Domain.Entities;
using Rotina.DomainService.Expressions;
using Rotina.DomainService.Helpers;
using Rotina.DomainService.IRepositories;
using Rotina.DomainService.IServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rotina.Service.Services
{
    public class LoginService : ServiceBase, ILoginService
    {
        private readonly IUserService _svcUser;

        public LoginService(IUnitOfWork repUnitOfWork, IUserService svcUser) 
            : base(repUnitOfWork)
        {
            _svcUser = svcUser;
        }

        private async Task Add(Guid idUser)
        {
            LoginEntity loginEntity = new(idUser, "");

            await _repUnitOfWork.Login.AddAsync(loginEntity);
        }

        public async Task<TokenEntity> GenerateToken(LoginCommand command)
        {
            UserEntity user = await _svcUser.FindByEmail(command.Email);

            if (user == null || user.Password != command.Senha)
                GenerateError("Username or password is invalid");

            string token = GenerateToken(user);

            await Add(user.Id);

            return new TokenEntity(user.Id, "bearer", token, DateTime.Now.AddHours(1));
        }

        private static string GenerateToken(UserEntity cliente)
        {
            var claims = new List<Claim>();

            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Helper.ApiSecret());

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid, cliente.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<List<LoginEntity>> FindAllByUser(decimal idUser)
        {
            return await _repUnitOfWork.Login.FindAllAsync(LoginExpression.FindByUser(idUser));
        }
    }
}
