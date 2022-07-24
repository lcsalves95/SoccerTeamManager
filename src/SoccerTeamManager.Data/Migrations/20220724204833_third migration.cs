using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerTeamManager.Infra.Data.Migrations
{
    public partial class thirdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "manager",
                table: "Tournament",
                keyColumn: "Id",
                keyValue: new Guid("bbaedea6-04f8-4343-a832-314482933a1b"));

            migrationBuilder.InsertData(
                schema: "manager",
                table: "Tournament",
                columns: new[] { "Id", "CreatedAt", "Name", "Prize", "UpdatedAt" },
                values: new object[] { new Guid("90908e45-35f8-4b60-a1a3-a71a4b15f48a"), new DateTime(2022, 7, 24, 17, 48, 33, 133, DateTimeKind.Local).AddTicks(9386), "Amistoso", 0.0, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "manager",
                table: "Tournament",
                keyColumn: "Id",
                keyValue: new Guid("90908e45-35f8-4b60-a1a3-a71a4b15f48a"));

            migrationBuilder.InsertData(
                schema: "manager",
                table: "Tournament",
                columns: new[] { "Id", "CreatedAt", "Name", "Prize", "UpdatedAt" },
                values: new object[] { new Guid("bbaedea6-04f8-4343-a832-314482933a1b"), new DateTime(2022, 7, 24, 17, 26, 1, 444, DateTimeKind.Local).AddTicks(1026), "Amistoso", 0.0, null });
        }
    }
}
