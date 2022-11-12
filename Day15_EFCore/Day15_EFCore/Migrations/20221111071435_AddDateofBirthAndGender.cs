using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day15EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddDateofBirthAndGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DoB",
                schema: "dbo",
                table: "Students",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                schema: "dbo",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoB",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "dbo",
                table: "Students");
        }
    }
}
