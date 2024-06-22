using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspAZ.DataAccess.Migrations
{
    public partial class fixingissues148 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_TaxID",
                table: "Customers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("163a4545-3ac3-45d9-8134-f580f52b28a2"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2e990f93-cc68-4b6b-a582-18e0609c40a0"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2e990f93-cc68-4b6b-a582-18e0609c40a0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("163a4545-3ac3-45d9-8134-f580f52b28a2"));

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TaxID",
                table: "Customers",
                column: "TaxID",
                unique: true,
                filter: "[TaxID] IS NOT NULL");
        }
    }
}
