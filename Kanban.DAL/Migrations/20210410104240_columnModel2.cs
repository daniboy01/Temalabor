using Microsoft.EntityFrameworkCore.Migrations;

namespace Kanban.DAL.Migrations
{
    public partial class columnModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskColumnID",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TaskColumns",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskColumns", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskColumnID",
                table: "Tasks",
                column: "TaskColumnID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskColumns_TaskColumnID",
                table: "Tasks",
                column: "TaskColumnID",
                principalTable: "TaskColumns",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskColumns_TaskColumnID",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskColumns");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskColumnID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskColumnID",
                table: "Tasks");
        }
    }
}
