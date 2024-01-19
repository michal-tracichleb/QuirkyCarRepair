using System.Security.Claims;

namespace QuirkyCarRepair.BLL.Areas.Identity.Interfaces
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
        int GetUserId { get; }
        public string GetRoleName { get; }
    }
}