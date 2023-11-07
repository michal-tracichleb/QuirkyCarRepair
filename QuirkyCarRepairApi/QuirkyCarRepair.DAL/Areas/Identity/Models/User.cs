using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.Identity.Models
{
    public class User : IModelBase
    {
        public int Id { get; set; }
        public int RoleId { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string PasswordHash { get; set; }

        public virtual Role Role { get; set; }
    }
}