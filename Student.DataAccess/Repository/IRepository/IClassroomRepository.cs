
using Student.Models;
using StudentManager.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.DataAccess.Repository.IRepository
{
    public interface IClassroomRepository : IRepository<Classroom>
    {
        void Update(Classroom obj);
    }
}
