using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashRegister.Data.Migrations
{
    public partial class TaxEvasion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Bills_BillId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BillId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ExciseDuty",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ValueAddedTax",
                table: "Products",
                newName: "Tax");

            migrationBuilder.AddColumn<double>(
                name: "ExciseDutyAmount",
                table: "Bills",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Bills",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "ValueAddedTaxAmount",
                table: "Bills",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceAtPurchase",
                table: "BillProduct",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TaxAtPurchase",
                table: "BillProduct",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExciseDutyAmount",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "ValueAddedTaxAmount",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PriceAtPurchase",
                table: "BillProduct");

            migrationBuilder.DropColumn(
                name: "TaxAtPurchase",
                table: "BillProduct");

            migrationBuilder.RenameColumn(
                name: "Tax",
                table: "Products",
                newName: "ValueAddedTax");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExciseDuty",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BillId",
                table: "Products",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Bills_BillId",
                table: "Products",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
