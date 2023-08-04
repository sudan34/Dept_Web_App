using Dept_Web_App.Data;
using Dept_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Dept_Web_App.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetEmployeeFromAndList()
        {
            ViewBag.DepartmentList = new SelectList(_context.Departments.ToList(), "DId", "Name");
            return PartialView();
        }
        [HttpGet]
        public IActionResult GetEmployeeList()
        {
            var list = _context.Employees.Include(m => m.Department)
                  .Select(x => new
                  {
                      EmpId = x.EmpId,
                      FullName = x.FullName,
                      Contact = x.Contact,
                      Email = x.Email,
                      Address = x.Address,
                      Department = x.Department.Name
                  }).ToList();
            return Json(list);
        }
        [HttpPost]
        public IActionResult SaveEmployee(Employees model)
        {
            try
            {
                if (model.EmpId > 0)
                {
                    _context.Employees.Update(model);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Employees.Add(model);
                    _context.SaveChanges();
                }
                return Json(new JsonResponse() { IsSuccess = true, Message = "Recored saved successfully.", Data = new
                {
                    EmpId = model.EmpId,
                    FullName = model.FullName,
                    Contact = model.Contact,
                    Email = model.Email,
                    Address = model.Address,
                    Department = _context.Departments.Where(x => x.DId == model.DId).FirstOrDefault().Name
                }
                });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return Json(new JsonResponse() { IsSuccess = false, Data = msg });
            }
        }
    }
}
