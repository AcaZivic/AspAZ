using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspAZ.DataAccess.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("56752990-91e8-43af-ab01-bdeaeb4186b3"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("14ad4c13-8054-4056-9a13-c2b603679fa6"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("14ad4c13-8054-4056-9a13-c2b603679fa6"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("56752990-91e8-43af-ab01-bdeaeb4186b3"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldNullable: true);
        }
    }
}
