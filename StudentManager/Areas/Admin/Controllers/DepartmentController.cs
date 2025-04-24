using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student.Models;
using Student.Models.ViewModels;
using Student.Utility;
using StudentManager.DataAccess.Repository.IRepository;

namespace StudentManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class DepartmentController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Department> objDepartmentList = _unitOfWork.Department.GetAll(includeProperties: "Faculty").ToList();
            return View(objDepartmentList);
        }
        public IActionResult Upsert(int? id)
        {
            DepartmentVM departmentVM = new()
            {
                FacultyList = _unitOfWork.Faculty.GetAll()
                .Select(i => new SelectListItem
                {
                    Text = i.faculty_name,
                    Value = i.Id.ToString()
                }),
                Department = new()
            };

            if (id == 0 || id == null)
            {
                return View(departmentVM);
            }
            else
            {
                departmentVM.Department = _unitOfWork.Department.Get(u => u.Id == id);
                return View(departmentVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(DepartmentVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Department.Id == 0)
                {
                    _unitOfWork.Department.Add(obj.Department);
                    TempData["success"] = "Thêm bộ môn thành công";
                }
                else
                {
                    _unitOfWork.Department.Update(obj.Department);
                    TempData["success"] = "Cập nhật bộ môn thành công";
                }
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(obj);
        }
        #region API CALLS
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            Department? departmentFromDb = _unitOfWork.Department.Get(u => u.Id == id);
            if (departmentFromDb == null) return Json(new { success = false, message = "Xóa thất bại" });
            _unitOfWork.Department.Remove(departmentFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Xóa thành công" });
        }
        #endregion
    }
}
