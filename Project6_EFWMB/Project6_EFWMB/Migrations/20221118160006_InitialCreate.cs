using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Project6EFWMB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_customer",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "VarChar(50)", nullable: false),
                    MobilePhone = table.Column<string>(type: "VarChar(20)", nullable: false),
                    IsMember = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_customer", x => x.CustomersId);
                });

            migrationBuilder.CreateTable(
                name: "m_discount",
                columns: table => new
                {
                    DiscountsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiscDesciption = table.Column<string>(type: "VarChar(50)", nullable: true),
                    Percent = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_discount", x => x.DiscountsId);
                });

            migrationBuilder.CreateTable(
                name: "m_menu",
                columns: table => new
                {
                    MenusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MenuCode = table.Column<string>(type: "VarChar(10)", nullable: false),
                    MenuName = table.Column<string>(type: "VarChar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_menu", x => x.MenusId);
                });

            migrationBuilder.CreateTable(
                name: "m_table",
                columns: table => new
                {
                    TablesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TableName = table.Column<string>(type: "VarChar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_table", x => x.TablesId);
                });

            migrationBuilder.CreateTable(
                name: "m_trans_type",
                columns: table => new
                {
                    TransTypesId = table.Column<string>(type: "VarChar(3)", nullable: false),
                    Description = table.Column<string>(type: "VarChar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_trans_type", x => x.TransTypesId);
                });

            migrationBuilder.CreateTable(
                name: "m_customer_discount",
                columns: table => new
                {
                    CustDiscountsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiscountsId = table.Column<int>(type: "integer", nullable: true),
                    CustomersId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_customer_discount", x => x.CustDiscountsId);
                    table.ForeignKey(
                        name: "FK_m_customer_discount_m_customer_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "m_customer",
                        principalColumn: "CustomersId");
                    table.ForeignKey(
                        name: "FK_m_customer_discount_m_discount_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "m_discount",
                        principalColumn: "DiscountsId");
                });

            migrationBuilder.CreateTable(
                name: "m_menu_price",
                columns: table => new
                {
                    MenuPricesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MenusId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<float>(type: "Float4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_menu_price", x => x.MenuPricesId);
                    table.ForeignKey(
                        name: "FK_m_menu_price_m_menu_MenusId",
                        column: x => x.MenusId,
                        principalTable: "m_menu",
                        principalColumn: "MenusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_bill",
                columns: table => new
                {
                    BillsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomersId = table.Column<int>(type: "integer", nullable: false),
                    TablesId = table.Column<int>(type: "integer", nullable: true),
                    TransTypesId = table.Column<string>(type: "VarChar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_bill", x => x.BillsId);
                    table.ForeignKey(
                        name: "FK_t_bill_m_customer_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "m_customer",
                        principalColumn: "CustomersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_bill_m_table_TablesId",
                        column: x => x.TablesId,
                        principalTable: "m_table",
                        principalColumn: "TablesId");
                    table.ForeignKey(
                        name: "FK_t_bill_m_trans_type_TransTypesId",
                        column: x => x.TransTypesId,
                        principalTable: "m_trans_type",
                        principalColumn: "TransTypesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_bill_detail",
                columns: table => new
                {
                    BillDetailsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BillsId = table.Column<int>(type: "integer", nullable: false),
                    MenuPricesId = table.Column<int>(type: "integer", nullable: false),
                    Qty = table.Column<float>(type: "Float4", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_bill_detail", x => x.BillDetailsId);
                    table.ForeignKey(
                        name: "FK_t_bill_detail_m_menu_price_MenuPricesId",
                        column: x => x.MenuPricesId,
                        principalTable: "m_menu_price",
                        principalColumn: "MenuPricesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_bill_detail_t_bill_BillsId",
                        column: x => x.BillsId,
                        principalTable: "t_bill",
                        principalColumn: "BillsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_customer_discount_CustomersId",
                table: "m_customer_discount",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_m_customer_discount_DiscountsId",
                table: "m_customer_discount",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_m_menu_price_MenusId",
                table: "m_menu_price",
                column: "MenusId");

            migrationBuilder.CreateIndex(
                name: "IX_t_bill_CustomersId",
                table: "t_bill",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_t_bill_TablesId",
                table: "t_bill",
                column: "TablesId");

            migrationBuilder.CreateIndex(
                name: "IX_t_bill_TransTypesId",
                table: "t_bill",
                column: "TransTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_t_bill_detail_BillsId",
                table: "t_bill_detail",
                column: "BillsId");

            migrationBuilder.CreateIndex(
                name: "IX_t_bill_detail_MenuPricesId",
                table: "t_bill_detail",
                column: "MenuPricesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_customer_discount");

            migrationBuilder.DropTable(
                name: "t_bill_detail");

            migrationBuilder.DropTable(
                name: "m_discount");

            migrationBuilder.DropTable(
                name: "m_menu_price");

            migrationBuilder.DropTable(
                name: "t_bill");

            migrationBuilder.DropTable(
                name: "m_menu");

            migrationBuilder.DropTable(
                name: "m_customer");

            migrationBuilder.DropTable(
                name: "m_table");

            migrationBuilder.DropTable(
                name: "m_trans_type");
        }
    }
}
