using Microsoft.AspNetCore.Http;
using QuirkyCarRepair.BLL.Areas.Identity.Interfaces;
using System.Security.Claims;

namespace QuirkyCarRepair.BLL.Areas.Identity.Services
{
    internal class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public int GetUserId =>
            User is null ? 0 : int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
    }
}