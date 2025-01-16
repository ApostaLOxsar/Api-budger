using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Models.output;
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
            
            CreateMap<User, OutputUser>();
            CreateMap<Role, OutputRole>();
            CreateMap<Family, OutputFamily>();
            CreateMap<Budger, OutputBudger>();
            CreateMap<BudgerCategory, OutputBudgerCategory>();
            CreateMap<Incom, OutputIncom>();
            CreateMap<IncomCategory, OutputIncomCategory>();
        }
    }
}
