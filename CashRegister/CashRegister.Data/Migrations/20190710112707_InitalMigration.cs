using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashRegister.Data.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cashiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Tax = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashierRegisters",
                columns: table => new
                {
                    CashierId = table.Column<int>(nullable: false),
                    RegisterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashierRegisters", x => new { x.CashierId, x.RegisterId });
                    table.ForeignKey(
                        name: "FK_CashierRegisters_Cashiers_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Cashiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashierRegisters_Registers_RegisterId",
                        column: x => x.RegisterId,
                        principalTable: "Registers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    TotalPriceWithoutTax = table.Column<double>(nullable: false),
                    ExciseDutyAmount = table.Column<double>(nullable: false),
                    ValueAddedTaxAmount = table.Column<double>(nullable: false),
                    CustomTaxAmount = table.Column<double>(nullable: false),
                    TotalPriceWithTax = table.Column<double>(nullable: false),
                    CashierRegisterCashierId = table.Column<int>(nullable: true),
                    CashierRegisterRegisterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_CashierRegisters_CashierRegisterCashierId_CashierRegisterRegisterId",
                        columns: x => new { x.CashierRegisterCashierId, x.CashierRegisterRegisterId },
                        principalTable: "CashierRegisters",
                        principalColumns: new[] { "CashierId", "RegisterId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillProducts",
                columns: table => new
                {
                    BillId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    PriceAtPurchase = table.Column<double>(nullable: false),
                    TaxAtPurchase = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillProducts", x => new { x.BillId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BillProducts_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillProducts_ProductId",
                table: "BillProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CashierRegisterCashierId_CashierRegisterRegisterId",
                table: "Bills",
                columns: new[] { "CashierRegisterCashierId", "CashierRegisterRegisterId" });

            migrationBuilder.CreateIndex(
                name: "IX_CashierRegisters_RegisterId",
                table: "CashierRegisters",
                column: "RegisterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillProducts");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CashierRegisters");

            migrationBuilder.DropTable(
                name: "Cashiers");

            migrationBuilder.DropTable(
                name: "Registers");
        }
    }
}
