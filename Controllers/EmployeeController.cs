using Microsoft.AspNetCore.Mvc;

namespace Dept_Web_App.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
