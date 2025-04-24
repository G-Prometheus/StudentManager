using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Models.ViewModels
{
    public class SpecializationVM
    {
        public Specialization Specialization { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> MajorsList { get; set; }
    }
}
