﻿namespace QuirkyCarRepair.BLL.Areas.Warehouse.DTO
{
    public class OrderDTO
    {
        public string OrderType { get; set; }
        public int ServiceOrderId { get; set; }
        public List<OrderPartsDTO> OrderParts { get; set; }
    }
}