using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateTableSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentCode",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DepartmentCode",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "DepartmentCode",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_DepartmentCode",
                table: "Subjects",
                column: "DepartmentCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Departments_DepartmentCode",
                table: "Subjects",
                column: "DepartmentCode",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Departments_DepartmentCode",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_DepartmentCode",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "DepartmentCode",
                table: "Subjects");
        }
    }
}
