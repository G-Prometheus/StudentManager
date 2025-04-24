using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Models.ViewModels
{
    public class StudentVM
    {
        public Students Students { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ClassroomList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> FacultyList { get; set; }

    }
}
