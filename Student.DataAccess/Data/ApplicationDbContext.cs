using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Student.Models;

namespace StudentManager.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Majors> Majors { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Students> Students { get; set; }

        public DbSet<Grades> Grades { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Grades>()
                .HasOne(g => g.Students)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction); // 👈 Tắt CASCADE cho Student

            modelBuilder.Entity<Grades>()
                .HasOne(g => g.Subject)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    CourseCode = 17500,
                    SubjectName = "Toán rời rạc",
                    Credits = 3,
                    DepartmentCode = 1
                },
                new Subject
                {
                    Id = 2,
                    CourseCode = 17501,
                    SubjectName = "Tin học văn phòng",
                    Credits = 3,
                    DepartmentCode = 1
                }
                );
            modelBuilder.Entity<Majors>().HasData(
                new Majors
                {
                    Id = 1,
                    majors_id = 7580203,
                    majors_name = "Công nghệ thông tin",
                },
                new Majors
                {
                    Id = 2,
                    majors_id = 7520320,
                    majors_name = "Kỹ thuật xây dựng",
                }
                );
            modelBuilder.Entity<Faculty>().HasData(
                new Faculty
                {
                    Id = 1,
                    faculty_id = 11,
                    faculty_name = "Khoa công nghệ thông tin",
                },
                new Faculty
                {
                    Id = 2,
                    faculty_id = 12,
                    faculty_name = "Viện cơ khí",
                }
                );
            modelBuilder.Entity<Specialization>().HasData(
                new Specialization
                {
                    Id = 1,
                    SpecializationCode = "D403",
                    SpecializationName = "Công nghệ thông tin",
                    MajorsId = 1,
                    ClassCode = "CNT"
                },
                new Specialization
                {
                    Id = 2,
                    SpecializationCode = "D403",
                    SpecializationName = "Công nghệ phần mềm",
                    MajorsId = 1,
                    ClassCode = "KPM"
                }
                );
            modelBuilder.Entity<Classroom>().HasData(
                new Classroom
                {
                    Id = 1,
                    ClassId = "CNT62CL",
                    NameClass = "Công nghệ thông tin khóa 62",
                    Specialization_Id = 1,
                },
                new Classroom
                {
                    Id = 2,
                    ClassId = "CNT62CL",
                    NameClass = "Công nghệ thông tin khóa 61",
                    Specialization_Id = 1,
                }
                );
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    DepartmentId = 111,
                    DepartmentName = "Khoa học máy tính",
                    Leader = "Ths. Nguyễn Hữu Tuân",
                    FacultyId = 1,
                },
                new Department
                {
                    Id = 2,
                    DepartmentId = 112,
                    DepartmentName = "Hệ thống thông tin",
                    Leader = "Ths. Phạm Trung Minh",
                    FacultyId = 1,
                }
                );
            modelBuilder.Entity<Students>().HasData(
                new Students
                {
                    Id = 1,
                    StudentCode = 90510,
                    FullName = "Nguyễn Văn A",
                    Gender = "Nam",
                    DateOfBirth = new DateTime(2003, 5, 10),
                    Email = "nguyenvana@example.com",
                    PhoneNumber = "0912345678",
                    CCCD = "123456789012",
                    ClassId = 1,
                    FacultyId = 1,
                    ImageUrl = "/images/students/nguyenvana.jpg"
                }

                );
            modelBuilder.Entity<Grades>().HasData(
                new Grades
                {
                    Id = 1,
                    StudentId = 1,
                    SubjectId = 1,
                    grade = 8.5
                }

                );

        }
    }
}
