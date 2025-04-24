using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student.Models;
using Student.Utility;
using StudentManager.DataAccess.Repository.IRepository;

namespace StudentManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class MajorsController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        public MajorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Majors> objMajorsList = _unitOfWork.Majors.GetAll().ToList();
            return View(objMajorsList);
        }
        public IActionResult Upsert(int ? id)
        {
            if(id == 0 || id == null)
            {
                Majors obj = new Majors();
                return View(obj);
            }
            else
            {
                Majors? majorsFromDb = _unitOfWork.Majors.Get(u => u.Id == id);
                if (majorsFromDb == null) return NotFound();
                return View(majorsFromDb);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Majors obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.Majors.Add(obj);
                    TempData["success"] = "Thêm ngành đào tạo thành công";
                }
                else
                {
                    _unitOfWork.Majors.Update(obj);
                    TempData["success"] = "Cập nhật ngành đào tạo thành công";
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
            Majors? majorsFromDb = _unitOfWork.Majors.Get(u => u.Id == id);
            if (majorsFromDb == null) return Json(new { success = false, message = "Xóa thất bại" });
            _unitOfWork.Majors.Remove(majorsFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Xóa thành công" });
        }
        #endregion
    }
}
