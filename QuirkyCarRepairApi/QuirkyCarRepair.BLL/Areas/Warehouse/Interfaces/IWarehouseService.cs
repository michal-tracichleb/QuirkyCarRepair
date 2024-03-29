﻿using QuirkyCarRepair.BLL.Areas.Shared;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces
{
    public interface IWarehouseService
    {
        public List<PartCategoryEntity> GetPrimaryCategories();

        public PartCategoryStructureDTO GetPartCategoryStructure(int id);

        public PageList<PartEntity> GetPartsPage(GetPartsPageDTO getPartsPageDTO);

        public PageList<OperationalDocumentDTO> GetOrdersPage(GetOrdersPageDTO getOrdersPageDTO);

        public void DeliveryParts(List<DeliveryPartDTO> deliveryPartsDTO);

        public void OrderParts(OrderDTO orderDTO);

        public void CancelOrder(int id);

        public DetailsOrderDTO DetailsOrder(int id);

        public DetailsOrderDTO ArrangeOrder(int id);

        public DetailsOrderDTO ReadyForPickup(int id);

        public DetailsOrderDTO OrderCompleted(int id);
    }
}