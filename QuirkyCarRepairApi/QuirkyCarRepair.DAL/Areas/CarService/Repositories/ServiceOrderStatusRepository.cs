﻿using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.CarService.Repositories
{
    internal class ServiceOrderStatusRepository : Repository<ServiceOrderStatus>, IServiceOrderStatusRepository
    {
        public ServiceOrderStatusRepository(QuirkyCarRepairContext context) : base(context)
        {
        }
    }
}