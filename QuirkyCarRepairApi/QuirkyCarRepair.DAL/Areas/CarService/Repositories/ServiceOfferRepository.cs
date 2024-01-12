using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.CarService.Repositories
{
    internal class ServiceOfferRepository : Repository<ServiceOffer>, IServiceOfferRepository
    {
        public ServiceOfferRepository(QuirkyCarRepairContext context) : base(context)
        {
        }

        public ICollection<ServiceOffer> GetByMainCategoryId(int mainCategoryId)
        {
            return _context.ServiceOffers.Where(x => x.MainCategoryServiceId == mainCategoryId).ToList();
        }
    }
}