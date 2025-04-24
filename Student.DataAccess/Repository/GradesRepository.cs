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
    public class GradesRepository : Repository<Grades>, IGradesRepository
    {
        readonly ApplicationDbContext _db;
        public GradesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Grades obj)
        {
            _db.Grades.Update(obj);
        }
    }
}
