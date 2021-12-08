using Microsoft.EntityFrameworkCore.Migrations;

namespace LM.Data.Migrations
{
    public partial class AddBookRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnedBy",
                table: "Library",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Library_OwnedBy",
                table: "Library",
                column: "OwnedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Library_Users_OwnedBy",
                table: "Library",
                column: "OwnedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Library_Users_OwnedBy",
                table: "Library");

            migrationBuilder.DropIndex(
                name: "IX_Library_OwnedBy",
                table: "Library");

            migrationBuilder.DropColumn(
                name: "OwnedBy",
                table: "Library");
        }
    }
}
