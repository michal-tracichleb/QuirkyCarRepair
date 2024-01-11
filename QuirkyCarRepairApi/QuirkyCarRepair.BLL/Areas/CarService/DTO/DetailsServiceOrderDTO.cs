using QuirkyCarRepair.BLL.Areas.CarService.Entities;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;

namespace QuirkyCarRepair.BLL.Areas.CarService.DTO
{
    public class DetailsServiceOrderDTO
    {
        public int ServiceOrderId { get; set; }

        public string DocumentNumber { get; set; }
        public DateTime DateStartRepair { get; set; }

        public DateTime StatusStartDate { get; set; }
        public string Status { get; set; }
        public string OrderDescription { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public string Vin { get; set; }
        public string PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public List<PartsDTO> Parts { get; set; }
        public List<ServiceTransactionDTO> ServiceTransactions { get; set; }
        public List<ServiceOrderStatusEntity> ServiceOrderStatuses { get; set; }
    }
}