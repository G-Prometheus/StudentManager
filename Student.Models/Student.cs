using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Mã sinh viên")]
        public int StudentCode { get; set; }
        [Required]
        [DisplayName("Tên sinh viên")]
        public string FullName { get; set; }
        [Required]
        [DisplayName("Giới tính")]
        public string Gender { get; set; }
        [Required]
        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Email")]
        [EmailAddress]
        public string? Email { get; set; }
        [DisplayName("Số điện thoại")]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Required]
        [DisplayName("CCCD")]
        [StringLength(12, MinimumLength = 9, ErrorMessage = "CCCD phải từ 9 đến 12 số")]
        public string CCCD { get; set; }
        [DisplayName("Lớp")]
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        
        [ValidateNever]
        public Classroom Classroom { get; set; }
        [DisplayName("Khoa/Viện")]
        public int FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        [ValidateNever]
        public Faculty Faculty { get; set; }
        [ValidateNever]
        [DisplayName("Hình ảnh")]
        public string ImageUrl { get; set; }

    }
}
