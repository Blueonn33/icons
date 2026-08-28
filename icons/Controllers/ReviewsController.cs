using icons.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService _service;

        public ReviewsController(IReviewService service)
        {
            _service = service;
        }
    }
}
