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
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        readonly ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Department obj)
        {
            _db.Departments.Update(obj);
        }
    }
}
