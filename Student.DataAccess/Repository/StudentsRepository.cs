using Book.DataAccess.Repository.IRepository;
using Student.Models;
using StudentManager.DataAccess.Data;
using StudentManager.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.DataAccess.Repository
{
    public class StudentsRepository : Repository<Students>, IStudentsRepository
    {
        readonly ApplicationDbContext _db;
        public StudentsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Students obj)
        {
            _db.Students.Update(obj);
        }
    }
}
