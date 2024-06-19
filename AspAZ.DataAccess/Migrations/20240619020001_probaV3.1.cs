using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspAZ.DataAccess.Migrations
{
    public partial class probaV31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUseCase_Employees_UserId",
                table: "UserUseCase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUseCase",
                table: "UserUseCase");

            migrationBuilder.RenameTable(
                name: "UserUseCase",
                newName: "UserUseCases");

            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c6b03d5a-9dbf-4041-a089-b512b880e82c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e8bc984a-cf97-4c2b-b392-64830ecef2a4"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUseCases",
                table: "UserUseCases",
                columns: new[] { "UserId", "UseCaseId" });

            migrationBuilder.CreateTable(
                name: "UseCaseLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UseCaseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UseCaseData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseCaseLogs", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserUseCases_Employees_UserId",
                table: "UserUseCases",
                column: "UserId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUseCases_Employees_UserId",
                table: "UserUseCases");

            migrationBuilder.DropTable(
                name: "UseCaseLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUseCases",
                table: "UserUseCases");

            migrationBuilder.RenameTable(
                name: "UserUseCases",
                newName: "UserUseCase");

            migrationBuilder.AlterColumn<Guid>(
                name: "ErrorId",
                table: "ErrorLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e8bc984a-cf97-4c2b-b392-64830ecef2a4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c6b03d5a-9dbf-4041-a089-b512b880e82c"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUseCase",
                table: "UserUseCase",
                columns: new[] { "UserId", "UseCaseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserUseCase_Employees_UserId",
                table: "UserUseCase",
                column: "UserId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
