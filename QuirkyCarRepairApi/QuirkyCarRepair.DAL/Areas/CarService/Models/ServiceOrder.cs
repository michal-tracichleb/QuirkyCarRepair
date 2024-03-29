﻿using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Shared.Models;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.CarService.Models
{
    public class ServiceOrder : IModelBase
    {
        public ServiceOrder()
        {
            ServiceOrderStatuses = new HashSet<ServiceOrderStatus>();
            OperationalDocuments = new HashSet<OperationalDocument>();
            ServiceTransactions = new HashSet<ServiceTransaction>();
        }

        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int OrderOwnerId { get; set; }

        public string OrderNumber { get; set; }
        public string OrderDescription { get; set; }
        public DateTime DateStartRepair { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual OrderOwner OrderOwner { get; set; }
        public virtual ICollection<ServiceOrderStatus> ServiceOrderStatuses { get; set; }
        public virtual ICollection<OperationalDocument> OperationalDocuments { get; set; }
        public virtual ICollection<ServiceTransaction> ServiceTransactions { get; set; }
    }
}