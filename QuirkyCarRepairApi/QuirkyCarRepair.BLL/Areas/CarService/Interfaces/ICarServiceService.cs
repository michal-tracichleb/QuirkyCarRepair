﻿using QuirkyCarRepair.BLL.Areas.CarService.DTO;
using QuirkyCarRepair.BLL.Areas.CarService.Entities;
using QuirkyCarRepair.BLL.Areas.Shared;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;

namespace QuirkyCarRepair.BLL.Areas.CarService.Interfaces
{
    public interface ICarServiceService
    {
        public DetailsServiceOrderDTO NewOrderService(CreateServiceOrderDTO createServiceOrder);

        public PageList<ServiceOrderDTO> GetOrdersPage(GetServiceOrderPage getOrdersServicePageDTO);

        public DetailsServiceOrderDTO GetDetailsServiceOrder(int id);

        public List<MainCategoryServiceEntity> GetAllMainCategoryService();

        public List<ServiceOfferEntity> GetServiceOfferByMainCategory(int mainCategoryId);

        public List<ServiceOfferEntity> GetAllServiceOffer();
    }
}