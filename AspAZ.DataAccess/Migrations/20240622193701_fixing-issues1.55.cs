using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspAZ.DataAccess.Migrations
{
    public partial class fixingissues155 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopStorage_Products_ProductId",
                table: "ShopStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopStorage_RetailShops_RetailShopId",
                table: "ShopStorage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopStorage",
                table: "ShopStorage");

            migrationBuilder.RenameTable(
                name: "ShopStorage",
                newName: "ShopStorages");

            migrationBuilder.RenameIndex(
                name: "IX_ShopStorage_RetailShopId",
                table: "ShopStorages",
                newName: "IX_ShopStorages_RetailShopId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9d2e8abe-196d-474c-be0a-c38c826ea586"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("61333c88-aaa4-4106-9e92-39128edc6514"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopStorages",
                table: "ShopStorages",
                columns: new[] { "ProductId", "RetailShopId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopStorages_Products_ProductId",
                table: "ShopStorages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopStorages_RetailShops_RetailShopId",
                table: "ShopStorages",
                column: "RetailShopId",
                principalTable: "RetailShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopStorages_Products_ProductId",
                table: "ShopStorages");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopStorages_RetailShops_RetailShopId",
                table: "ShopStorages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopStorages",
                table: "ShopStorages");

            migrationBuilder.RenameTable(
                name: "ShopStorages",
                newName: "ShopStorage");

            migrationBuilder.RenameIndex(
                name: "IX_ShopStorages_RetailShopId",
                table: "ShopStorage",
                newName: "IX_ShopStorage_RetailShopId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("61333c88-aaa4-4106-9e92-39128edc6514"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9d2e8abe-196d-474c-be0a-c38c826ea586"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopStorage",
                table: "ShopStorage",
                columns: new[] { "ProductId", "RetailShopId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopStorage_Products_ProductId",
                table: "ShopStorage",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopStorage_RetailShops_RetailShopId",
                table: "ShopStorage",
                column: "RetailShopId",
                principalTable: "RetailShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
