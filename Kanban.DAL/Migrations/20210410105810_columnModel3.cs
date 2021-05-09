using Microsoft.EntityFrameworkCore.Migrations;

namespace Kanban.DAL.Migrations
{
    public partial class ColumnModel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskColumns_TaskColumnID",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "TaskColumnID",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskColumns_TaskColumnID",
                table: "Tasks",
                column: "TaskColumnID",
                principalTable: "TaskColumns",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskColumns_TaskColumnID",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "TaskColumnID",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskColumns_TaskColumnID",
                table: "Tasks",
                column: "TaskColumnID",
                principalTable: "TaskColumns",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
