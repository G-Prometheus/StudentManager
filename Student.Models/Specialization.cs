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
    public class Specialization
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Mã chuyên ngành")]
        public string SpecializationCode { get; set; }
        [Required]
        [DisplayName("Tên chuyên ngành")]
        public string SpecializationName { get; set; }
        [DisplayName("Ngành đào tạo")]
        public int MajorsId { get; set; }
        [ForeignKey("MajorsId")]
        [ValidateNever]
        public Majors Majors { get; set; }
        [DisplayName("Ký hiệu lớp")]
        public string ClassCode { get; set; }
    }
}
