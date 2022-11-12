using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Day15EFCore.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationtoStudentAddressAndCreateTableStudentAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentAddresses",
                schema: "dbo",
                columns: table => new
                {
                    StudentAddressId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address1 = table.Column<string>(type: "VarChar(200)", nullable: true),
                    Address2 = table.Column<string>(type: "VarChar(200)", nullable: true),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAddresses", x => x.StudentAddressId);
                    table.ForeignKey(
                        name: "FK_StudentAddresses_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "dbo",
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_StudentId",
                schema: "dbo",
                table: "StudentAddresses",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAddresses",
                schema: "dbo");
        }
    }
}
