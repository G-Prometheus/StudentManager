using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Models
{
    [Index(nameof(CourseCode), IsUnique = true)]
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        [DisplayName("Mã học phần")]
        public int CourseCode { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Tên học phần")]
        public string SubjectName { get; set; }
        [Required][Range(1, 5, ErrorMessage ="Số tín chỉ phải nằm trong khoảng từ 1-5")]
        [DisplayName("Số tín chỉ")]
        public int Credits { get; set; }
        [DisplayName("Bộ môn")]
        public int DepartmentCode { get; set; }
        [ForeignKey("DepartmentCode")]
        [ValidateNever]
        public Department Department { get; set; }

    }
}
