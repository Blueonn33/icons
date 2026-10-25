using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace icons.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        protected bool IsUserAuthenticated
            => User.Identity?.IsAuthenticated ?? false;
    }
}
