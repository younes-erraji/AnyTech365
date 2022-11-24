using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspWebAPI.Data.Migrations
{
    public partial class ReadersMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BooksReaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReaderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    Read_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ExperationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksReaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksReaders_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksReaders_Readers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 8, 18, 27, 29, 764, DateTimeKind.Local).AddTicks(7321));

            migrationBuilder.CreateIndex(
                name: "IX_BooksReaders_BookId",
                table: "BooksReaders",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksReaders_ReaderId",
                table: "BooksReaders",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Readers_Mail",
                table: "Readers",
                column: "Mail",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksReaders");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 6, 17, 48, 14, 861, DateTimeKind.Local).AddTicks(5360));
        }
    }
}
