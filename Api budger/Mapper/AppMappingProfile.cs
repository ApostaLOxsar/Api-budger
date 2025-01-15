using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using AutoMapper;

namespace Api_budger.Mapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<InputBudger, Budger>();
            CreateMap<InputBudgerCategory, BudgerCategory>();
            CreateMap<InputFamily, Family>();
            CreateMap<InputIncom, Incom>();
            CreateMap<InputIncomCategory, IncomCategory>();
            CreateMap<InputRole, Role>();
            CreateMap<InputUser, User>();
        }
    }
}
