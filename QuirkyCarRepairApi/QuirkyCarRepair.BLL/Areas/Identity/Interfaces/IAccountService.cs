using QuirkyCarRepair.BLL.Areas.Identity.DTO;

namespace QuirkyCarRepair.BLL.Areas.Identity.Interfaces
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);

        public string GenerateJwt(LoginDto dto);

        public UserDetailsDto GetUserDetails(int id);
    }
}