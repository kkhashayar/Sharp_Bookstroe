using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoreApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GuidId_In_Book_And_Author : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Books");
        }
    }
}
