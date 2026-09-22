using AutoMapper;
using icons.Core.Contracts;
using icons.Models;
using icons.Models.Home;
using icons.Models.Icons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace icons.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IIconService _service;
        private readonly IMapper _mapper;

        public HomeController(IIconService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var dtos = await _service.GetTop3IconsAsync();

            var model = new Top3IconsViewModel
            {
                Top3Icons = _mapper.Map<IEnumerable<IconViewModel>>(dtos)
            };

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
