using MatchPointMasters.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MatchPointMasters.Controllers
{
    public class SetController : BaseController
    {
        private readonly ISetService service;

        public SetController(ISetService _service)
        {
            service = _service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
