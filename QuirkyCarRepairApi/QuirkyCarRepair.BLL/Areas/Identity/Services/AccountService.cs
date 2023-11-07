using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QuirkyCarRepair.BLL.Areas.Identity.DTO;
using QuirkyCarRepair.BLL.Areas.Identity.Interfaces;
using QuirkyCarRepair.DAL.Areas.Identity.Interfaces;
using QuirkyCarRepair.DAL.Areas.Identity.Models;

namespace QuirkyCarRepair.BLL.Areas.Identity.Services
{
    internal class AccountService : IAccountService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IAccountRepostiory _accountRepostiory;
        private readonly IMapper _mapper;

        public AccountService(IPasswordHasher<User> passwordHasher,
            IAccountRepostiory accountRepostiory,
            IMapper mapper)
        {
            _passwordHasher = passwordHasher;
            _accountRepostiory = accountRepostiory;
            _mapper = mapper;
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
    }
}