
using Book.DataAccess.Repository;
using Book.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
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
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _db;
        public IMajorsRepository Majors { get; private set; }

        public ISubjectRepository Subject { get; private set; }

        public IFacultyRepository Faculty { get; private set; }

        public ISpecializationRepository Specialization { get; private set; }

        public IClassroomRepository Classroom  { get; private set; }

        public IDepartmentRepository Department { get; private set; }

        public IStudentsRepository Students { get; private set; }

        public IGradesRepository Grades { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Majors = new MajorsRepository(_db);
            Subject = new SubjectRepository(_db);
            Faculty = new FacultyRepository(_db);
            Specialization = new SpecializationRepository(_db);
            Classroom = new ClassroomRepository(_db);
            Department = new DepartmentRepository(_db);
            Students = new StudentsRepository(_db);
            Grades = new GradesRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
//luong hoat dong
//1.unitOfWork.Category.GetAll()
//2.CategoryRepository.GetAll()
//3.Repository<Category>.GetAll()
//4.dbSet.ToList()
//5.DbContext thực thi truy vấn SQL