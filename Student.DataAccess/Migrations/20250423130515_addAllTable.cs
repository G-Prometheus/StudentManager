using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Student.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addAllTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    faculty_id = table.Column<int>(type: "int", nullable: false),
                    faculty_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    majors_id = table.Column<int>(type: "int", nullable: false),
                    majors_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<int>(type: "int", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Leader = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecializationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecializationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MajorsId = table.Column<int>(type: "int", nullable: false),
                    ClassCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specializations_Majors_MajorsId",
                        column: x => x.MajorsId,
                        principalTable: "Majors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classrooms_Specializations_Specialization_Id",
                        column: x => x.Specialization_Id,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "faculty_id", "faculty_name" },
                values: new object[,]
                {
                    { 1, 11, "Khoa công nghệ thông tin" },
                    { 2, 12, "Viện cơ khí" }
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "Id", "majors_id", "majors_name" },
                values: new object[,]
                {
                    { 1, 7580203, "Công nghệ thông tin" },
                    { 2, 7520320, "Kỹ thuật xây dựng" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CourseCode", "Credits", "SubjectName" },
                values: new object[,]
                {
                    { 1, 17500, 3, "Toán rời rạc" },
                    { 2, 17501, 3, "Tin học văn phòng" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentId", "DepartmentName", "FacultyId", "Leader" },
                values: new object[,]
                {
                    { 1, 111, "Khoa học máy tính", 1, "Ths. Nguyễn Hữu Tuân" },
                    { 2, 112, "Hệ thống thông tin", 1, "Ths. Phạm Trung Minh" }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "ClassCode", "MajorsId", "SpecializationCode", "SpecializationName" },
                values: new object[,]
                {
                    { 1, "CNT", 1, "D403", "Công nghệ thông tin" },
                    { 2, "KPM", 1, "D403", "Công nghệ phần mềm" }
                });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "ClassId", "NameClass", "Specialization_Id" },
                values: new object[,]
                {
                    { 1, "CNT62CL", "Công nghệ thông tin khóa 62", 1 },
                    { 2, "CNT62CL", "Công nghệ thông tin khóa 61", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_Specialization_Id",
                table: "Classrooms",
                column: "Specialization_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyId",
                table: "Departments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_MajorsId",
                table: "Specializations",
                column: "MajorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CourseCode",
                table: "Subjects",
                column: "CourseCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Majors");
        }
    }
}
