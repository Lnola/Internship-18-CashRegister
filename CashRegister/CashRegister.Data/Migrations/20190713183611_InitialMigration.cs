using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashRegister.Data.Migrations
{
    public partial class InitialMigration : Migration
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
                    AmountBought = table.Column<int>(nullable: false),
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

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "CashierRegisterCashierId", "CashierRegisterRegisterId", "CustomTaxAmount", "ExciseDutyAmount", "Guid", "IssueDate", "TotalPriceWithTax", "TotalPriceWithoutTax", "ValueAddedTaxAmount" },
                values: new object[,]
                {
                    { 1, null, null, 1.0, 1.0, new Guid("b9fe028f-0a8a-4dfd-9bc7-bb9b01d6e47b"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 28, null, null, 1.0, 1.0, new Guid("83d8da67-17e2-4c78-a5da-eb4ba6837e8d"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 29, null, null, 1.0, 1.0, new Guid("fb82b33a-0b21-4d45-a084-5518cc9b35ba"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 30, null, null, 1.0, 1.0, new Guid("b32626cc-190b-4abc-b5ba-020fee380298"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 31, null, null, 1.0, 1.0, new Guid("1011cbc1-0599-4da6-9ca3-961440752154"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 32, null, null, 1.0, 1.0, new Guid("e557e42f-03a8-4b52-9d73-73b0846edd6a"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 33, null, null, 1.0, 1.0, new Guid("4a693771-a06e-4f64-9e51-8eb250c41a33"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 34, null, null, 1.0, 1.0, new Guid("7b1abb10-4d5a-4fd9-b64a-76f878cb7930"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 35, null, null, 1.0, 1.0, new Guid("40e3b300-19b3-4716-8ab6-e76cc450e6b6"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 36, null, null, 1.0, 1.0, new Guid("09c9abef-2227-497f-a2cd-98768f75edde"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 37, null, null, 1.0, 1.0, new Guid("facbaded-87c3-491d-bed6-70cde8506acf"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 38, null, null, 1.0, 1.0, new Guid("623799bc-45a9-46b0-bda0-547857dfd261"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 39, null, null, 1.0, 1.0, new Guid("cb54ba42-2606-428c-8e81-987a9afa2c34"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 40, null, null, 1.0, 1.0, new Guid("8ad0cd02-9b10-402b-bcca-d5b07cfeccef"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 41, null, null, 1.0, 1.0, new Guid("c816b4ac-5390-4e2c-8ed9-30cb2b9c5853"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 42, null, null, 1.0, 1.0, new Guid("9b3bb25c-a7e1-4c71-b637-dcf065b4247c"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 44, null, null, 1.0, 1.0, new Guid("cadcdb0f-e7ca-4136-99da-04e99c22cc12"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 45, null, null, 1.0, 1.0, new Guid("beb35f10-1b3d-460e-bc4b-a7581868eba7"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 46, null, null, 1.0, 1.0, new Guid("f30314f2-e89a-470f-8d4c-9e020a94611c"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 47, null, null, 1.0, 1.0, new Guid("fe6d7e9a-652c-4c1d-81aa-8360fb0b6566"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 48, null, null, 1.0, 1.0, new Guid("bab2e215-0c35-4f50-bc1b-325e1d831a12"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 49, null, null, 1.0, 1.0, new Guid("843d2ef9-629e-486c-929a-24940907ccd0"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 27, null, null, 1.0, 1.0, new Guid("49b239f3-b53a-4b17-b9ef-dd91e5dbd67e"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 26, null, null, 1.0, 1.0, new Guid("d4e1cc8f-e4f2-4433-a276-c7fc28b4b8b7"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 43, null, null, 1.0, 1.0, new Guid("d3a30e31-526a-4d1c-b0ec-67d1e5a63ea7"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 24, null, null, 1.0, 1.0, new Guid("0a94ea27-0569-42e2-be8d-31b7380d6a31"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 2, null, null, 1.0, 1.0, new Guid("96b3568e-0177-4d75-8f1c-9087ca9b9cd6"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 3, null, null, 1.0, 1.0, new Guid("e5cfa92b-d278-40e1-8400-d54063472f3c"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 4, null, null, 1.0, 1.0, new Guid("226c03da-6c99-4018-b3ed-67e10aeb0a6c"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 5, null, null, 1.0, 1.0, new Guid("9e30c971-7de0-4ee5-9af5-eb5b4fe44b85"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 6, null, null, 1.0, 1.0, new Guid("2f14393d-e2b3-47b6-9674-d2dac7c19cbe"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 7, null, null, 1.0, 1.0, new Guid("dfdb8e4d-d232-4f6e-b078-0820f69c1816"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 8, null, null, 1.0, 1.0, new Guid("2cf63692-03a2-4fc1-8b8c-fa021cf96176"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 9, null, null, 1.0, 1.0, new Guid("e004dbd3-ddc6-4d2a-8428-c7acb364916d"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 10, null, null, 1.0, 1.0, new Guid("6f490d07-12fd-4e47-8b28-3951be06ec2b"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 25, null, null, 1.0, 1.0, new Guid("08470d06-31f6-4e15-90df-a46e7ee1e550"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 12, null, null, 1.0, 1.0, new Guid("2ff6ddbe-eff6-4165-81e0-e4e07938139a"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 11, null, null, 1.0, 1.0, new Guid("bc356974-6199-4811-b507-c1d3e4ddbc46"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 14, null, null, 1.0, 1.0, new Guid("cec9e087-c372-423f-9201-728415ad94f2"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 15, null, null, 1.0, 1.0, new Guid("80b08f98-a67f-4f8a-8499-322f270f99d5"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 16, null, null, 1.0, 1.0, new Guid("a0c645f1-93ab-4bdd-a435-72c2e7f2e857"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 17, null, null, 1.0, 1.0, new Guid("68719cda-cd0b-4ef0-94e0-3f847c7a2fcd"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 18, null, null, 1.0, 1.0, new Guid("aa9420b1-5134-4dcd-9d81-4f282be9d26d"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 19, null, null, 1.0, 1.0, new Guid("7529ab49-5a33-400d-9449-873f0e2e3261"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 20, null, null, 1.0, 1.0, new Guid("52d3cfd0-e18b-4a7a-8434-1129ecb034bc"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 21, null, null, 1.0, 1.0, new Guid("0cd8bba0-98c7-4874-9b80-4578ac4fcecd"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 22, null, null, 1.0, 1.0, new Guid("f64ff6d0-4cc7-46df-8d4c-3e964e115833"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 23, null, null, 1.0, 1.0, new Guid("5d09c71c-8bc8-4aeb-a32b-3196da9bddbe"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 },
                    { 13, null, null, 1.0, 1.0, new Guid("c2b831be-d1b7-4335-a9fc-2694ac282cf9"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20.0, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "Cashiers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "Teta Tetic" },
                    { 7, "Iva Ivic" },
                    { 5, "Ana Anic" },
                    { 6, "Mila Milic" },
                    { 3, "Stipe Stipic" },
                    { 2, "Jure Juric" },
                    { 1, "Mate Matic" },
                    { 4, "Tomo Tomic" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Barcode", "Name", "Price", "Tax" },
                values: new object[,]
                {
                    { 20, 100, "1111111111130", "Batteries", 42.0, 5 },
                    { 19, 100, "1111111111129", "Coffe", 34.0, 20 },
                    { 18, 100, "1111111111128", "Cigarettes", 24.0, 5 },
                    { 17, 100, "1111111111127", "Chips", 15.0, 25 },
                    { 16, 100, "1111111111126", "Wine", 137.0, 5 },
                    { 15, 100, "1111111111125", "Pepsi", 10.0, 25 },
                    { 14, 100, "1111111111124", "Orangina", 15.0, 25 },
                    { 13, 100, "1111111111123", "Coca Cola", 10.0, 25 },
                    { 11, 100, "1111111111121", "Sprite", 10.0, 25 },
                    { 12, 100, "1111111111122", "Fanta", 10.0, 25 },
                    { 9, 100, "1111111111119", "Apple pie", 27.0, 25 },
                    { 10, 100, "1111111111120", "Watermelon", 21.0, 25 },
                    { 2, 100, "1111111111112", "Orange", 4.0, 5 },
                    { 3, 100, "1111111111113", "Lemon", 3.0, 20 },
                    { 4, 100, "1111111111114", "Apple", 2.0, 25 },
                    { 1, 100, "1111111111111", "Banana", 3.0, 25 },
                    { 6, 100, "1111111111116", "Chewing gum", 7.0, 25 },
                    { 7, 100, "1111111111117", "Apple juice", 12.0, 25 },
                    { 8, 100, "1111111111118", "Apple cider", 15.0, 5 },
                    { 5, 100, "1111111111115", "Cherry", 5.0, 25 }
                });

            migrationBuilder.InsertData(
                table: "Registers",
                column: "Id",
                values: new object[]
                {
                    7,
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    8
                });

            migrationBuilder.InsertData(
                table: "BillProducts",
                columns: new[] { "BillId", "ProductId", "AmountBought", "PriceAtPurchase", "TaxAtPurchase" },
                values: new object[,]
                {
                    { 1, 1, 1, 1.0, 1 },
                    { 28, 1, 1, 1.0, 1 },
                    { 29, 1, 1, 1.0, 1 },
                    { 30, 1, 1, 1.0, 1 },
                    { 31, 1, 1, 1.0, 1 },
                    { 32, 1, 1, 1.0, 1 },
                    { 33, 1, 1, 1.0, 1 },
                    { 34, 1, 1, 1.0, 1 },
                    { 35, 1, 1, 1.0, 1 },
                    { 36, 1, 1, 1.0, 1 },
                    { 37, 1, 1, 1.0, 1 },
                    { 38, 1, 1, 1.0, 1 },
                    { 39, 1, 1, 1.0, 1 },
                    { 40, 1, 1, 1.0, 1 },
                    { 41, 1, 1, 1.0, 1 },
                    { 42, 1, 1, 1.0, 1 },
                    { 43, 1, 1, 1.0, 1 },
                    { 44, 1, 1, 1.0, 1 },
                    { 45, 1, 1, 1.0, 1 },
                    { 46, 1, 1, 1.0, 1 },
                    { 47, 1, 1, 1.0, 1 },
                    { 48, 1, 1, 1.0, 1 },
                    { 27, 1, 1, 1.0, 1 },
                    { 26, 1, 1, 1.0, 1 },
                    { 25, 1, 1, 1.0, 1 },
                    { 24, 1, 1, 1.0, 1 },
                    { 2, 1, 1, 1.0, 1 },
                    { 3, 1, 1, 1.0, 1 },
                    { 4, 1, 1, 1.0, 1 },
                    { 5, 1, 1, 1.0, 1 },
                    { 6, 1, 1, 1.0, 1 },
                    { 7, 1, 1, 1.0, 1 },
                    { 8, 1, 1, 1.0, 1 },
                    { 9, 1, 1, 1.0, 1 },
                    { 10, 1, 1, 1.0, 1 },
                    { 11, 1, 1, 1.0, 1 },
                    { 49, 1, 1, 1.0, 1 },
                    { 12, 1, 1, 1.0, 1 },
                    { 14, 1, 1, 1.0, 1 },
                    { 15, 1, 1, 1.0, 1 },
                    { 16, 1, 1, 1.0, 1 },
                    { 17, 1, 1, 1.0, 1 },
                    { 18, 1, 1, 1.0, 1 },
                    { 19, 1, 1, 1.0, 1 },
                    { 20, 1, 1, 1.0, 1 },
                    { 21, 1, 1, 1.0, 1 },
                    { 22, 1, 1, 1.0, 1 },
                    { 23, 1, 1, 1.0, 1 },
                    { 13, 1, 1, 1.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "CashierRegisters",
                columns: new[] { "CashierId", "RegisterId" },
                values: new object[] { 1, 1 });

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
