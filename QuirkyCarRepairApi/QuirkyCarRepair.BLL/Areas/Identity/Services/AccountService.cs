using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QuirkyCarRepair.BLL.Areas.Identity.DTO;
using QuirkyCarRepair.BLL.Areas.Identity.Interfaces;
using QuirkyCarRepair.DAL.Areas.Identity.Interfaces;
using QuirkyCarRepair.DAL.Areas.Identity.Models;
using QuirkyCarRepair.DAL.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuirkyCarRepair.BLL.Areas.Identity.Services
{
    internal class AccountService : IAccountService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IAccountRepostiory _accountRepostiory;
        private readonly IMapper _mapper;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(IPasswordHasher<User> passwordHasher,
            IAccountRepostiory accountRepostiory,
            IMapper mapper,
            AuthenticationSettings authenticationSettings)
        {
            _passwordHasher = passwordHasher;
            _accountRepostiory = accountRepostiory;
            _mapper = mapper;
            _authenticationSettings = authenticationSettings;
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                UserName = dto.UserName,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                RoleId = dto.RoleId,
            };

            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, dto.Password);

            _accountRepostiory.Add(_mapper.Map<User>(newUser));
        }

        public string GenerateJwt(LoginDto dto)
        {
            var user = _accountRepostiory.GetByEmail(dto.Email);
            if (user is null)
                throw new BadRequestException("Invalid username or password");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
                throw new BadRequestException("Invalid username or password");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.UserName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                new Claim("FirstName", user.FirstName ?? ""),
                new Claim("LastName", user.LastName ?? "")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: creds);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}