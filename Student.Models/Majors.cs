using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Models
{
    public class Majors
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Mã ngành đào tạo")]
        public int majors_id { get; set; }
        [Required]
        [DisplayName("Tên ngành đào tạo")]
        public string majors_name { get; set; }
    }
}
