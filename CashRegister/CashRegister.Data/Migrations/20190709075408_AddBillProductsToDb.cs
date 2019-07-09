using Microsoft.EntityFrameworkCore.Migrations;

namespace CashRegister.Data.Migrations
{
    public partial class AddBillProductsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillProduct_Bills_BillId",
                table: "BillProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BillProduct_Products_BillId",
                table: "BillProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillProduct",
                table: "BillProduct");

            migrationBuilder.RenameTable(
                name: "BillProduct",
                newName: "BillProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillProducts",
                table: "BillProducts",
                columns: new[] { "BillId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BillProducts_Bills_BillId",
                table: "BillProducts",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillProducts_Products_BillId",
                table: "BillProducts",
                column: "BillId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillProducts_Bills_BillId",
                table: "BillProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_BillProducts_Products_BillId",
                table: "BillProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillProducts",
                table: "BillProducts");

            migrationBuilder.RenameTable(
                name: "BillProducts",
                newName: "BillProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillProduct",
                table: "BillProduct",
                columns: new[] { "BillId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BillProduct_Bills_BillId",
                table: "BillProduct",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillProduct_Products_BillId",
                table: "BillProduct",
                column: "BillId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
