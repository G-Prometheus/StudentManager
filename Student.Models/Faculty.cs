using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Mã khoa/ngành")]
        public int faculty_id { get; set; }
        [Required]
        [DisplayName("Tên khoa/ngành")]
        public string faculty_name { get; set; }
    }
}
