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
    public class SubjectController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        public SubjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Subject> objSubjectList = _unitOfWork.Subject.GetAll(includeProperties: "Department").ToList();
            return View(objSubjectList);
        }
        public IActionResult Upsert(int? id)
        {
            SubjectVM subjectVM = new()
            {
                DepartmentList = _unitOfWork.Department.GetAll()
                .Select(i => new SelectListItem
                {
                    Text = i.DepartmentName,
                    Value = i.Id.ToString()
                }),
                Subject = new()
            };

            if (id == 0 || id == null)
            {
                return View(subjectVM);
            }
            else
            {
                subjectVM.Subject = _unitOfWork.Subject.Get(u => u.Id == id);
                return View(subjectVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(SubjectVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Subject.Id == 0)
                {
                    _unitOfWork.Subject.Add(obj.Subject);
                    TempData["success"] = "Thêm môn học thành công";
                }
                else
                {
                    _unitOfWork.Subject.Update(obj.Subject);
                    TempData["success"] = "Cập nhật môn học thành công";
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
            Subject? subjectFromDb = _unitOfWork.Subject.Get(u => u.Id == id);
            if (subjectFromDb == null) return Json(new { success = false, message = "Xóa thất bại" });
            _unitOfWork.Subject.Remove(subjectFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Xóa thành công" });
        }
        #endregion
    }
}
