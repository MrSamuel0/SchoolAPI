using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Migrations
{
    /// <inheritdoc />
    public partial class SchoolMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SchoolSubjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Math = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Portuguese = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    English = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Chemistry = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Physics = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Biology = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Geography = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    History = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolSubjects", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SchoolReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SchoolName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SchoolYear = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SchoolClass = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SchoolGradesId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolReport_SchoolSubjects_SchoolGradesId",
                        column: x => x.SchoolGradesId,
                        principalTable: "SchoolSubjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolReport_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolReport_SchoolGradesId",
                table: "SchoolReport",
                column: "SchoolGradesId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolReport_StudentId",
                table: "SchoolReport",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolReport");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "SchoolSubjects");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
