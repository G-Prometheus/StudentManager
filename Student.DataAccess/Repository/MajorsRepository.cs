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
    public class MajorsRepository : Repository<Majors>, IMajorsRepository
    {
        readonly ApplicationDbContext _db;
        public MajorsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Majors obj)
        {
            _db.Majors.Update(obj);
        }
    }
}
