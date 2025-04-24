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
    public class GradesController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        public GradesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Grades> objGradesList = _unitOfWork.Grades.GetAll(includeProperties: "Students,Subject").ToList();
            return View(objGradesList);
        }
        public IActionResult Upsert(int? id)
        {
            GradesVM gradesVM = new()
            {
                StudentsList = _unitOfWork.Students.GetAll()
                .Select(i => new SelectListItem
                {
                    Text = i.FullName,
                    Value = i.Id.ToString()
                }),
                SubjectList = _unitOfWork.Subject.GetAll()
                .Select(i => new SelectListItem
                {
                    Text = i.SubjectName,
                    Value = i.Id.ToString()
                }),
                Grades = new()
            };

            if (id == 0 || id == null)
            {
                return View(gradesVM);
            }
            else
            {
                gradesVM.Grades = _unitOfWork.Grades.Get(u => u.Id == id);
                return View(gradesVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(GradesVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Grades.Id == 0)
                {
                    _unitOfWork.Grades.Add(obj.Grades);
                    TempData["success"] = "Thêm điểm thành công";
                }
                else
                {
                    _unitOfWork.Grades.Update(obj.Grades);
                    TempData["success"] = "Cập nhật điểm thành công";
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
            Grades? gradesFromDb = _unitOfWork.Grades.Get(u => u.Id == id);
            if (gradesFromDb == null) return Json(new { success = false, message = "Xóa thất bại" });
            _unitOfWork.Grades.Remove(gradesFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Xóa thành công" });
        }
        #endregion
    }
}
