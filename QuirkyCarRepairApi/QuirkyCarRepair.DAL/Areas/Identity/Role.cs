using Microsoft.AspNetCore.Identity;

namespace QuirkyCarRepair.DAL.Areas.Identity
{
    public class Role : IdentityRole<int>
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public virtual ICollection<User> Users { get; set; }
    }
}