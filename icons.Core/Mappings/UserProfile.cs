using AutoMapper;
using icons.Core.ViewModels.Users;
using icons.Data.Models;

namespace icons.Core.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserProfileViewModel>();
        }
    }
}
