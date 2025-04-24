using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student.Models;
using Student.Utility;
using StudentManager.DataAccess.Repository.IRepository;

namespace StudentManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class FacultyController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        public FacultyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Faculty> objMajorsList = _unitOfWork.Faculty.GetAll().ToList();
            return View(objMajorsList);
        }
        public IActionResult Upsert(int ? id)
        {
            if(id == 0 || id == null)
            {
                Faculty obj = new Faculty();
                return View(obj);
            }
            else
            {
                Faculty? facultyFromDb = _unitOfWork.Faculty.Get(u => u.Id == id);
                if (facultyFromDb == null) return NotFound();
                return View(facultyFromDb);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Faculty obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.Faculty.Add(obj);
                    TempData["success"] = "Thêm khoa/viện thành công";
                }
                else
                {
                    _unitOfWork.Faculty.Update(obj);
                    TempData["success"] = "Cập nhật khoa/viện thành công";
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
            Faculty? facultyFromDb = _unitOfWork.Faculty.Get(u => u.Id == id);
            if (facultyFromDb == null) return Json(new { success = false, message = "Xóa thất bại" });
            _unitOfWork.Faculty.Remove(facultyFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Xóa thành công" });
        }
        #endregion
    }
}
