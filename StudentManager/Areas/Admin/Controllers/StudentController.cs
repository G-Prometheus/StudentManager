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
    public class StudentController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IWebHostEnvironment _webHostEnvironment;
        public StudentController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            
            List<Students> objStudentList = _unitOfWork.Students.GetAll(includeProperties: "Classroom,Faculty").ToList();
            return View(objStudentList);
        }
        public IActionResult Upsert(int? id)
        {
            StudentVM studentVM = new()
            {
                ClassroomList = _unitOfWork.Classroom.GetAll()
                .Select(i => new SelectListItem
                {
                    Text = i.NameClass,
                    Value = i.Id.ToString()
                }),
                FacultyList = _unitOfWork.Faculty.GetAll()
                .Select(i => new SelectListItem
                {
                    Text = i.faculty_name,
                    Value = i.Id.ToString()
                }),
                Students = new()
            };

            if (id == 0 || id == null)
            {
                return View(studentVM);
            }
            else
            {
                studentVM.Students = _unitOfWork.Students.Get(u => u.Id == id);
                return View(studentVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(StudentVM studentVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;//path wwwroot
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string studentPath = Path.Combine(wwwRootPath, @"images\student");
                    if (!string.IsNullOrEmpty(studentVM.Students.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, studentVM.Students.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(studentPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    studentVM.Students.ImageUrl = @"\images\student\" + fileName;
                }
                if (studentVM.Students.Id == 0)
                {
                    _unitOfWork.Students.Add(studentVM.Students);
                    TempData["success"] = "Thêm sinh viên thành công";
                }
                else
                {
                    _unitOfWork.Students.Update(studentVM.Students);
                    TempData["success"] = "Cập nhật sinh viên thành công";
                }
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(studentVM);
        }
        #region API CALLS
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            Students? studentFromDb = _unitOfWork.Students.Get(u => u.Id == id);
            if (studentFromDb == null) return Json(new { success = false, message = "Xóa thất bại" });
            _unitOfWork.Students.Remove(studentFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Xóa thành công" });
        }
        #endregion
    }
}
