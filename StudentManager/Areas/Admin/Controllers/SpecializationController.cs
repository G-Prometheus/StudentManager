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
    public class SpecializationController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        public SpecializationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Specialization> objSpecializationList = _unitOfWork.Specialization.GetAll(includeProperties: "Majors").ToList();
            return View(objSpecializationList);
        }
        public IActionResult Upsert(int? id)
        {
            SpecializationVM specializationVM = new()
            {
                MajorsList = _unitOfWork.Majors.GetAll()
                .Select(i => new SelectListItem
                {
                    Text = i.majors_name,
                    Value = i.Id.ToString()
                }),
                Specialization = new()
            };

            if (id == 0 || id == null)
            {
                return View(specializationVM);
            }
            else
            {
                specializationVM.Specialization = _unitOfWork.Specialization.Get(u => u.Id == id);
                return View(specializationVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(SpecializationVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Specialization.Id == 0)
                {
                    _unitOfWork.Specialization.Add(obj.Specialization);
                    TempData["success"] = "Thêm chuyên ngành thành công";
                }
                else
                {
                    _unitOfWork.Specialization.Update(obj.Specialization);
                    TempData["success"] = "Cập nhật chuyên ngành thành công";
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
            Specialization? specializationFromDb = _unitOfWork.Specialization.Get(u => u.Id == id);
            if (specializationFromDb == null) return Json(new { success = false, message = "Xóa thất bại" });
            _unitOfWork.Specialization.Remove(specializationFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Xóa thành công" });
        }
        #endregion
    }
}
