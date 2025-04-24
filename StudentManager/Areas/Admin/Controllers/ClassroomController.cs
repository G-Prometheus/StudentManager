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
    public class ClassroomController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        public ClassroomController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Classroom> objClassroomList = _unitOfWork.Classroom.GetAll(includeProperties: "Specialization").ToList();
            return View(objClassroomList);
        }
        public IActionResult Upsert(int? id)
        {
            ClassroomVM classroomVM = new()
            {
                SpecializationList = _unitOfWork.Specialization.GetAll()
                .Select(i => new SelectListItem
                {
                    Text = i.SpecializationName,
                    Value = i.Id.ToString()
                }),
                Classroom = new()
            };

            if (id == 0 || id == null)
            {
                return View(classroomVM);
            }
            else
            {
                classroomVM.Classroom = _unitOfWork.Classroom.Get(u => u.Id == id);
                return View(classroomVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ClassroomVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Classroom.Id == 0)
                {
                    _unitOfWork.Classroom.Add(obj.Classroom);
                    TempData["success"] = "Thêm lớp thành công";
                }
                else
                {
                    _unitOfWork.Classroom.Update(obj.Classroom);
                    TempData["success"] = "Cập nhật lớp thành công";
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
            Classroom? classroomFromDb = _unitOfWork.Classroom.Get(u => u.Id == id);
            if (classroomFromDb == null) return Json(new { success = false, message = "Xóa thất bại" });
            _unitOfWork.Classroom.Remove(classroomFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Xóa thành công" });
        }
        #endregion
    }
}
