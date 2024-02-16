using AutoMapper;

namespace ASP.NET.Auth
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>().ConstructUsing(v => new UserViewModel(v));            
        }
    }
}
