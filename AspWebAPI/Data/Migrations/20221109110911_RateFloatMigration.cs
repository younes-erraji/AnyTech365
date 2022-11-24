using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspWebAPI.Data.Migrations
{
    public partial class RateFloatMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Readers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Rate",
                table: "Books",
                type: "real",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creater_at",
                value: new DateTimeOffset(new DateTime(2022, 11, 9, 12, 9, 9, 378, DateTimeKind.Unspecified).AddTicks(5948), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverUrl", "Created_at", "Genre" },
                values: new object[] { null, new DateTimeOffset(new DateTime(2022, 11, 9, 12, 9, 9, 389, DateTimeKind.Unspecified).AddTicks(5118), new TimeSpan(0, 1, 0, 0, 0)), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Readers");

            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creater_at",
                value: new DateTimeOffset(new DateTime(2022, 11, 8, 19, 45, 35, 84, DateTimeKind.Unspecified).AddTicks(9715), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverUrl", "Created_at", "Genre" },
                values: new object[] { "", new DateTimeOffset(new DateTime(2022, 11, 8, 19, 45, 35, 96, DateTimeKind.Unspecified).AddTicks(298), new TimeSpan(0, 1, 0, 0, 0)), "" });
        }
    }
}
