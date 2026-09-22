using AutoMapper;
using icons.Core.Dtos.Review;
using icons.Models.Reviews;

namespace icons.Mappings
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewGetDto, ReviewViewModel>();
        }
    }
}
