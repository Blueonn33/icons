using AutoMapper;
using icons.Core.Dtos.Icon;
using icons.Models.Icons;

namespace icons.Mappings
{
    public class IconProfile : Profile
    {
        public IconProfile()
        {
            CreateMap<IconGetDto, IconViewModel>();
            CreateMap<IconUserProfileGetDto, IconViewModel>();
        }
    }
}
