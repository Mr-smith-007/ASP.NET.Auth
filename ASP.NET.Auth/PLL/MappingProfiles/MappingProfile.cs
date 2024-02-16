using ASP.NET.Auth.BLL.Models;
using ASP.NET.Auth.BLL.ViewModels;
using AutoMapper;

namespace ASP.NET.Auth.PLL.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>().ConstructUsing(v => new UserViewModel(v));
        }
    }
}
