using Dept_Web_App.Data;
using Dept_Web_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dept_Web_App.Controllers
{
    

    public class DepartmentController : Controller
    {
        private ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetDepartmentFromAndList()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult GetDepartmentList()
        {
            try
            {
               // var list = _context.Departments.ToList();
                var list = new List<Departments>()
                {
                    new Departments() { DId=1,Name="IT"},
                    new Departments() { DId=2,Name="CS"},
                    new Departments() { DId=3,Name="Development"},
                };
                return Json(new JsonResponse() { IsSuccess = true, Data = list });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return Json(new JsonResponse() { IsSuccess=false, Data = msg });
            }
        }
    }
}
