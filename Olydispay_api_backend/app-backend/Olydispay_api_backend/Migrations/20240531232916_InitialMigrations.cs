using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Olydispay_api_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    jobTitle = table.Column<string>(type: "TEXT", nullable: true),
                    contractStartDate = table.Column<string>(type: "TEXT", nullable: true),
                    contractEndDate = table.Column<string>(type: "TEXT", nullable: true),
                    managerId = table.Column<int>(type: "INTEGER", nullable: true),
                    listOfPersonManaged = table.Column<string>(type: "TEXT", nullable: true),
                    DepartmentID = table.Column<int>(type: "INTEGER", nullable: true),
                    firstName = table.Column<string>(type: "TEXT", nullable: true),
                    lastName = table.Column<string>(type: "TEXT", nullable: true),
                    gender = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_employees_departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "departments",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateTable(
                name: "gradeHistories",
                columns: table => new
                {
                    GradeHistoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    grade = table.Column<string>(type: "TEXT", nullable: true),
                    fromDate = table.Column<string>(type: "TEXT", nullable: true),
                    toDate = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeeID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gradeHistories", x => x.GradeHistoryID);
                    table.ForeignKey(
                        name: "FK_gradeHistories_employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_DepartmentID",
                table: "employees",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_gradeHistories_EmployeeID",
                table: "gradeHistories",
                column: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gradeHistories");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
