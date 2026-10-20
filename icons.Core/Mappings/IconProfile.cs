using AutoMapper;
using icons.Core.ViewModels.Home;
using icons.Core.ViewModels.Icons;
using icons.Data.Models;

namespace icons.Core.Mappings
{
    public class IconProfile : Profile
    {
        public IconProfile()
        {
            CreateMap<Icon, IconViewModel>();
            CreateMap<Icon, Top3IconsViewModel>();
        }
    }
}
