using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuirkyCarRepair.BLL.Areas.Identity.DTO;
using QuirkyCarRepair.BLL.Areas.Identity.Interfaces;

namespace QuirkyCarRepair.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);
        }

        [HttpGet]
        [Route("Details")]
        [Authorize]
        public ActionResult Details(int id)
        {
            var userDetails = _accountService.GetUserDetails(id);
            return Ok(userDetails);
        }

        [HttpPost]
        [Route("Edit")]
        [Authorize]
        public ActionResult Edit(int id, [FromBody] UserDetailsDto userDetails)
        {
            _accountService.Edit(id, userDetails);
            return Ok(userDetails);
        }

        [HttpPost]
        [Route("ChangePassword")]
        [Authorize]
        public ActionResult ChangePassword(int id, [FromBody] ChangePasswordDto changePassword)
        {
            _accountService.ChangePassword(id, changePassword);
            return Ok();
        }
    }
}