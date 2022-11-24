using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspWebAPI.Data.Migrations
{
    public partial class ReadersBooksRelationshipMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 8, 19, 43, 10, 809, DateTimeKind.Local).AddTicks(2809));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 8, 18, 27, 29, 764, DateTimeKind.Local).AddTicks(7321));
        }
    }
}
