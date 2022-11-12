using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day15EFCore.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAddressNullableDoBAndByteGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DoB",
                schema: "dbo",
                table: "Students",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar(200)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DoB",
                schema: "dbo",
                table: "Students",
                type: "VarChar(200)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
