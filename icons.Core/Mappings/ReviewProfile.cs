using AutoMapper;
using icons.Core.ViewModels.Reviews;
using icons.Data.Models;

namespace icons.Core.Mappings
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewViewModel>();
            CreateMap<Review, ReviewInputModel>();
            CreateMap<Review, ReviewUserProfileViewModel>();
        }
    }
}
