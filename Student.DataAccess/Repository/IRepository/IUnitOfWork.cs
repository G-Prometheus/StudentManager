using Book.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IMajorsRepository Majors { get; }
        ISubjectRepository Subject { get; }
        IFacultyRepository Faculty { get; }
        ISpecializationRepository Specialization { get; }
        IClassroomRepository Classroom { get; }
        IDepartmentRepository Department { get; }
        IStudentsRepository Students { get; }
        IGradesRepository Grades { get; }
        void Save();
    }
}
