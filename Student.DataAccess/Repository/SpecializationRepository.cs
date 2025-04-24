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
    public class SpecializationRepository : Repository<Specialization>, ISpecializationRepository
    {
        readonly ApplicationDbContext _db;
        public SpecializationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Specialization obj)
        {
            var objFromDb = _db.Specializations.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.SpecializationCode = obj.SpecializationCode;
                objFromDb.SpecializationName = obj.SpecializationName;
                objFromDb.ClassCode = obj.ClassCode;
                objFromDb.MajorsId = obj.MajorsId;
            }
        }
    }
}
