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
    public class FacultyRepository : Repository<Faculty>, IFacultyRepository
    {
        readonly ApplicationDbContext _db;
        public FacultyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Faculty obj)
        {
            _db.Faculties.Update(obj);
        }
    }
}
