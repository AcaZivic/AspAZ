using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspAZ.DataAccess.Migrations
{
    public partial class fixingissues14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ShopStorage");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ShopStorage");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShopStorage");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ShopStorage");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ShopStorage");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ShopStorage");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "ShopStorage");

            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("1f2e564c-0456-4984-92f2-e065e08eb88d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b8b86aa8-ec78-4552-aa06-836662d4bb66"));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "isActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ShopStorage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ShopStorage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ShopStorage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ShopStorage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ShopStorage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ShopStorage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "ShopStorage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b8b86aa8-ec78-4552-aa06-836662d4bb66"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("1f2e564c-0456-4984-92f2-e065e08eb88d"));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "isActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "isActive",
                value: false);
        }
    }
}
