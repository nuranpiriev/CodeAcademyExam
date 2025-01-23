using ExamCake.BL.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace ExamCake.Mvc.Controllers
{
    public class HomeController : Controller
    {
        readonly IChiefService _service;

        public HomeController(IChiefService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            if(!ModelState.IsValid)
            {
                throw new Exception("not found");

            }
            var chiefs=await _service.GetAllChiefAsync();
            return View(chiefs);
        }
    }
}
