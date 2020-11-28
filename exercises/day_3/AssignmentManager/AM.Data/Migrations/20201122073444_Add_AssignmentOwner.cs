using Microsoft.EntityFrameworkCore.Migrations;

namespace AM.Data.Migrations
{
    public partial class Add_AssignmentOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnedBy",
                table: "Assignments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_OwnedBy",
                table: "Assignments",
                column: "OwnedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Users_OwnedBy",
                table: "Assignments",
                column: "OwnedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Users_OwnedBy",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_OwnedBy",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "OwnedBy",
                table: "Assignments");
        }
    }
}
