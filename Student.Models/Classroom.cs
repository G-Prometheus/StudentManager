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
    public class Classroom
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Mã lớp")]
        public string ClassId { get; set; }
        [Required]
        [DisplayName("Tên lớp")]
        public string NameClass { get; set; }
        [DisplayName("Chuyên ngành")]
        public int Specialization_Id { get; set; }
        [ForeignKey("Specialization_Id")]
        [ValidateNever]
        public Specialization Specialization { get; set; }
    }
}
