using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day15EFCore.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNullableAddressFieldInStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "Students",
                type: "VarChar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar(200)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "Students",
                type: "VarChar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VarChar(200)",
                oldNullable: true);
        }
    }
}
