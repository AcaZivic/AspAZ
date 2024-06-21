using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspAZ.DataAccess.Migrations
{
    public partial class fixingissues12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyCategory_Categories_PropertyId",
                table: "PropertyCategory");

            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c6dbe125-0f71-482b-9a4a-4140e6def16e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("96c132ca-4fb2-4901-bb21-bf3a92ad557d"));

            migrationBuilder.CreateIndex(
                name: "IX_PropertyCategory_CategoryId",
                table: "PropertyCategory",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyCategory_Categories_CategoryId",
                table: "PropertyCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyCategory_Categories_CategoryId",
                table: "PropertyCategory");

            migrationBuilder.DropIndex(
                name: "IX_PropertyCategory_CategoryId",
                table: "PropertyCategory");

            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("96c132ca-4fb2-4901-bb21-bf3a92ad557d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c6dbe125-0f71-482b-9a4a-4140e6def16e"));

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyCategory_Categories_PropertyId",
                table: "PropertyCategory",
                column: "PropertyId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
