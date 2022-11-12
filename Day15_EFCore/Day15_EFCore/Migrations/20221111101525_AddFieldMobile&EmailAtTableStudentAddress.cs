using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day15EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldMobileEmailAtTableStudentAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "StudentAddresses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                schema: "dbo",
                table: "StudentAddresses",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "StudentAddresses");

            migrationBuilder.DropColumn(
                name: "Mobile",
                schema: "dbo",
                table: "StudentAddresses");
        }
    }
}
