using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Student.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Mã bộ môn")]
        public int DepartmentId { get; set; }
        [Required]
        [DisplayName("Tên bộ môn")]
        public string DepartmentName { get; set; }
        [Required]
        [DisplayName("Trưởng bộ môn")]
        [MaxLength(30)]
        public string Leader { get; set; }
        [DisplayName("Khoa/Viện")]
        public int FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        [ValidateNever]
        public Faculty Faculty { get; set; }
    }
}
