using AutoMapper;
using QuirkyCarRepair.BLL.Areas.Identity.DTO;
using QuirkyCarRepair.DAL.Areas.Identity.Models;

namespace QuirkyCarRepair.BLL.Areas.Identity.Mapper
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<Role, RoleDto>();
        }
    }
}