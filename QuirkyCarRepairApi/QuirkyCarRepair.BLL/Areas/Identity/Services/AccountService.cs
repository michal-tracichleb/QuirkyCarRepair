﻿using AutoMapper;
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
        private readonly IUserContextService _userContextService;

        public AccountService(IPasswordHasher<User> passwordHasher,
            IAccountRepostiory accountRepostiory,
            IMapper mapper,
            AuthenticationSettings authenticationSettings,
            IUserContextService userContextService)
        {
            _passwordHasher = passwordHasher;
            _accountRepostiory = accountRepostiory;
            _mapper = mapper;
            _authenticationSettings = authenticationSettings;
            _userContextService = userContextService;
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                UserName = dto.UserName,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                RoleId = 1,
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
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                new Claim("UserId", user.Id.ToString()),
                new Claim("UserRole", $"{user.Role.Name}")
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

        public UserDetailsDto GetUserDetails(int id)
        {
            if (_userContextService.GetUserId != id)
                throw new BadRequestException("Invalid user Id");

            var user = _accountRepostiory.Get(id);
            if (user == null)
                throw new NotFoundException("User cannot found");

            return new UserDetailsDto()
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}