using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoreApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_Info_In_Author_Description_In_Book : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortInfo",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "ShortInfo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "ShortInfo",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortInfo",
                table: "Authors");
        }
    }
}
