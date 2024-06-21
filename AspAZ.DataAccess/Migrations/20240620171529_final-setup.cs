using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspAZ.DataAccess.Migrations
{
    public partial class finalsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("14ad4c13-8054-4056-9a13-c2b603679fa6"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c6b03d5a-9dbf-4041-a089-b512b880e82c"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c6b03d5a-9dbf-4041-a089-b512b880e82c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("14ad4c13-8054-4056-9a13-c2b603679fa6"));
        }
    }
}
