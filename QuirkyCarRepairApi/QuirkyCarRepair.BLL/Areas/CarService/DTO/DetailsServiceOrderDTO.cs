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

        public OrderOwnerDTO UserData { get; set; }
        public VehicleDataDTO VehicleData { get; set; }

        public decimal TotalPrice
        {
            get
            {
                decimal partsPrice = 0;
                decimal servicesPrice = 0;
                if (Parts != null && Parts.Count != 0)
                {
                    partsPrice = Parts.Select(x => x.TotalPrice).Sum();
                }
                if (ServiceTransactions != null && ServiceTransactions.Count != 0)
                {
                    servicesPrice = ServiceTransactions.Select(x => x.TotalPrice).Sum();
                }
                return partsPrice + servicesPrice;
            }
        }

        public List<PartDTO> Parts { get; set; }
        public List<ServiceTransactionDTO> ServiceTransactions { get; set; }
        public List<ServiceOrderStatusEntity> ServiceOrderStatuses { get; set; }
    }
}