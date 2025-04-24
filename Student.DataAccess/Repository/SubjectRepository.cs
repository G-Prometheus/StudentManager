
using Student.Models;
using StudentManager.DataAccess.Data;
using StudentManager.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.DataAccess.Repository
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        readonly ApplicationDbContext _db;
        public SubjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Subject obj)
        {
            var objFromDb = _db.Subjects.FirstOrDefault(u => u.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.CourseCode = obj.CourseCode;
                objFromDb.SubjectName = obj.SubjectName;
                objFromDb.Credits = obj.Credits;
            }
        }
    }
}
