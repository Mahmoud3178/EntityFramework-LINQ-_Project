using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project1_EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Location = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    ClintId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Clints_ClintId",
                        column: x => x.ClintId,
                        principalTable: "Clints",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Clints",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "Cairo", "Mahmoud" },
                    { 2, "Qena", "Ahmed" },
                    { 3, "BaniSwif", "Mariam" },
                    { 4, "Asuit", "Osama" },
                    { 5, "Giza", "Yousif" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Cairo", "IT" },
                    { 2, "Qena", "CS" },
                    { 3, "BaniSwif", "AI" },
                    { 4, "Asuit", "IS" },
                    { 5, "Giza", "QQ" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "DepartmentId", "Name", "ProjectId", "Salary", "Status" },
                values: new object[,]
                {
                    { 1, 25, 1, "Mahmoud", null, 10000m, true },
                    { 2, 30, 2, "Ahmed", null, 15000m, true }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "DepartmentId", "Name", "ProjectId", "Salary" },
                values: new object[] { 3, 28, 1, "Sara", null, 12000m });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "DepartmentId", "Name", "ProjectId", "Salary", "Status" },
                values: new object[] { 4, 32, 3, "Mona", null, 20000m, true });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Budget", "ClintId", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, 50000m, 1, 1, "E-Commerce System" },
                    { 2, 80000m, 2, 3, "AI Chatbot" },
                    { 3, 60000m, 1, 2, "University Portal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectId",
                table: "Employees",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClintId",
                table: "Projects",
                column: "ClintId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DepartmentId",
                table: "Projects",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Clints");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
