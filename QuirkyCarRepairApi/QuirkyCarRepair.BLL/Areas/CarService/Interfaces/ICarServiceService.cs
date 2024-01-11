using QuirkyCarRepair.BLL.Areas.CarService.DTO;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;

namespace QuirkyCarRepair.BLL.Areas.CarService.Interfaces
{
    public interface ICarServiceService
    {
        public DetailsServiceOrderDTO NewOrderService(CreateServiceOrderDTO createServiceOrder);
    }
}