using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalProyect.Migrations
{
    /// <inheritdoc />
    public partial class PruebaInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecialtyModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialtyModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffCategoryModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffCategoryModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffCategoryId = table.Column<int>(type: "int", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffModel_SpecialtyModel_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "SpecialtyModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StaffModel_StaffCategoryModel_StaffCategoryId",
                        column: x => x.StaffCategoryId,
                        principalTable: "StaffCategoryModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffModel_SpecialtyId",
                table: "StaffModel",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffModel_StaffCategoryId",
                table: "StaffModel",
                column: "StaffCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffModel");

            migrationBuilder.DropTable(
                name: "SpecialtyModel");

            migrationBuilder.DropTable(
                name: "StaffCategoryModel");
        }
    }
}
