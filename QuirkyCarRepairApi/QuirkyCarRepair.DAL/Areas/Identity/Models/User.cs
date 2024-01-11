using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Shared.Models;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Identity.Models
{
    public class User : IModelBase
    {
        public User()
        {
            TransactionStatuses = new HashSet<TransactionStatus>();
            ServiceOrderStatuses = new HashSet<ServiceOrderStatus>();
            Vehicles = new HashSet<Vehicle>();
            OrderOwners = new HashSet<OrderOwner>();
        }

        public int Id { get; set; }
        public int RoleId { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailIsConfirmed { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string PasswordHash { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<TransactionStatus> TransactionStatuses { get; set; }
        public virtual ICollection<ServiceOrderStatus> ServiceOrderStatuses { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<OrderOwner> OrderOwners { get; set; }
    }
}