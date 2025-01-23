using Microsoft.AspNetCore.Mvc;

namespace ExamCake.Mvc.Areas.Admin.Controllers
{
    public class DesignationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
