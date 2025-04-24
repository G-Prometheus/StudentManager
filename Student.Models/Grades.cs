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
    public class Grades
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Sinh viên")]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        [ValidateNever]
        public Students Students { get; set; }
        [Required]
        [DisplayName("Môn học")]
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        [ValidateNever]
        public Subject Subject { get; set; }
        [Required]
        [DisplayName("Điểm")]
        [Range(0, 10, ErrorMessage = "Điểm phải từ 0 đến 10")]
        public double grade { get; set; }
    }
}
