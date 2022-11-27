using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Project7wmbRESTApi.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "m_customer",
                schema: "dbo",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "VarChar(50)", nullable: false),
                    MobilePhone = table.Column<string>(type: "VarChar(20)", nullable: false),
                    IsMember = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "m_discount",
                schema: "dbo",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiscDesciption = table.Column<string>(type: "VarChar(50)", nullable: true),
                    Percent = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_discount", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "m_menu",
                schema: "dbo",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MenuCode = table.Column<string>(type: "VarChar(5)", nullable: false),
                    MenuName = table.Column<string>(type: "VarChar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_menu", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "m_table",
                schema: "dbo",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TableName = table.Column<string>(type: "VarChar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_table", x => x.TableId);
                });

            migrationBuilder.CreateTable(
                name: "m_trans_type",
                schema: "dbo",
                columns: table => new
                {
                    TransTypeId = table.Column<string>(type: "VarChar(3)", nullable: false),
                    Description = table.Column<string>(type: "VarChar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_trans_type", x => x.TransTypeId);
                });

            migrationBuilder.CreateTable(
                name: "m_customer_discount",
                schema: "dbo",
                columns: table => new
                {
                    CustDiscountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiscountId = table.Column<int>(type: "integer", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_customer_discount", x => x.CustDiscountId);
                    table.ForeignKey(
                        name: "FK_m_customer_discount_m_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "dbo",
                        principalTable: "m_customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_m_customer_discount_m_discount_DiscountId",
                        column: x => x.DiscountId,
                        principalSchema: "dbo",
                        principalTable: "m_discount",
                        principalColumn: "DiscountId");
                });

            migrationBuilder.CreateTable(
                name: "m_menu_price",
                schema: "dbo",
                columns: table => new
                {
                    MenuPriceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MenuId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<float>(type: "Float4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_menu_price", x => x.MenuPriceId);
                    table.ForeignKey(
                        name: "FK_m_menu_price_m_menu_MenuId",
                        column: x => x.MenuId,
                        principalSchema: "dbo",
                        principalTable: "m_menu",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_bill",
                schema: "dbo",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    TableId = table.Column<int>(type: "integer", nullable: true),
                    TransTypeId = table.Column<string>(type: "VarChar(3)", nullable: false),
                    IsPayment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_bill", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_t_bill_m_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "dbo",
                        principalTable: "m_customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_bill_m_table_TableId",
                        column: x => x.TableId,
                        principalSchema: "dbo",
                        principalTable: "m_table",
                        principalColumn: "TableId");
                    table.ForeignKey(
                        name: "FK_t_bill_m_trans_type_TransTypeId",
                        column: x => x.TransTypeId,
                        principalSchema: "dbo",
                        principalTable: "m_trans_type",
                        principalColumn: "TransTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_bill_detail",
                schema: "dbo",
                columns: table => new
                {
                    BillDetailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BillId = table.Column<int>(type: "integer", nullable: false),
                    MenuPriceId = table.Column<int>(type: "integer", nullable: false),
                    Qty = table.Column<float>(type: "Float4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_bill_detail", x => x.BillDetailId);
                    table.ForeignKey(
                        name: "FK_t_bill_detail_m_menu_price_MenuPriceId",
                        column: x => x.MenuPriceId,
                        principalSchema: "dbo",
                        principalTable: "m_menu_price",
                        principalColumn: "MenuPriceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_bill_detail_t_bill_BillId",
                        column: x => x.BillId,
                        principalSchema: "dbo",
                        principalTable: "t_bill",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_customer_discount_CustomerId",
                schema: "dbo",
                table: "m_customer_discount",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_m_customer_discount_DiscountId",
                schema: "dbo",
                table: "m_customer_discount",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_m_menu_price_MenuId",
                schema: "dbo",
                table: "m_menu_price",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_t_bill_CustomerId",
                schema: "dbo",
                table: "t_bill",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_t_bill_TableId",
                schema: "dbo",
                table: "t_bill",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_t_bill_TransTypeId",
                schema: "dbo",
                table: "t_bill",
                column: "TransTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_t_bill_detail_BillId",
                schema: "dbo",
                table: "t_bill_detail",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_t_bill_detail_MenuPriceId",
                schema: "dbo",
                table: "t_bill_detail",
                column: "MenuPriceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_customer_discount",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "t_bill_detail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "m_discount",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "m_menu_price",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "t_bill",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "m_menu",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "m_customer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "m_table",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "m_trans_type",
                schema: "dbo");
        }
    }
}
