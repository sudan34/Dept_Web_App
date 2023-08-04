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
                var list = _context.Departments.ToList();
                return Json(new JsonResponse() { IsSuccess = true, Data = list });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return Json(new JsonResponse() { IsSuccess = false, Data = msg });
            }
        }
        [HttpGet]
        public IActionResult Edit(int dId)
        {
            try
            {
                var obj = _context.Departments.Find(dId);
                return Json(new JsonResponse() { IsSuccess = true, Data = obj });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return Json(new JsonResponse() { IsSuccess = false, Data = msg });
            }
        }
        [HttpPost]
        public IActionResult SaveDepartment(Departments model)
        {
            try
            {
                if (model.DId > 0)
                {
                    _context.Departments.Update(model);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Departments.Add(model);
                    _context.SaveChanges();
                }
                return Json(new JsonResponse() { IsSuccess = true, Message = "Recored saved successfully.", Data = model });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return Json(new JsonResponse() { IsSuccess = false, Data = msg });
            }
        }
        [HttpPost]
        public IActionResult Delete(long _id)
        {
            try
            {
                var obj = _context.Departments.Find(_id);
                _context.Departments.Remove(obj);
                _context.SaveChanges();
                return Json(new { status = true, Message = "Recored delated successfully." });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return Json(new JsonResponse() { IsSuccess = false, Data = msg });
            }
        }
    }
}
