using Microsoft.EntityFrameworkCore.Migrations;

namespace TM.Data.Migrations
{
    public partial class NewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnedBy",
                table: "Tasks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnedBy",
                table: "Tasks",
                column: "OwnedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_OwnedBy",
                table: "Tasks",
                column: "OwnedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_OwnedBy",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_OwnedBy",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "OwnedBy",
                table: "Tasks");
        }
    }
}
