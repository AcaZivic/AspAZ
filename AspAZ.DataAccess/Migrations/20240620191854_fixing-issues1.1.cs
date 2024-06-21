using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspAZ.DataAccess.Migrations
{
    public partial class fixingissues11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("96c132ca-4fb2-4901-bb21-bf3a92ad557d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("56752990-91e8-43af-ab01-bdeaeb4186b3"));

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("56752990-91e8-43af-ab01-bdeaeb4186b3"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("96c132ca-4fb2-4901-bb21-bf3a92ad557d"));

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
