using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pvms.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecializationInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializationInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStatistics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartCount = table.Column<int>(type: "int", nullable: false),
                    BachelorCount = table.Column<int>(type: "int", nullable: false),
                    MasterCount = table.Column<int>(type: "int", nullable: false),
                    B121Count = table.Column<int>(type: "int", nullable: false),
                    B122Count = table.Column<int>(type: "int", nullable: false),
                    B123Count = table.Column<int>(type: "int", nullable: false),
                    M121Count = table.Column<int>(type: "int", nullable: false),
                    M122Count = table.Column<int>(type: "int", nullable: false),
                    M123Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatistics", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecializationInfos");

            migrationBuilder.DropTable(
                name: "UserStatistics");
        }
    }
}
