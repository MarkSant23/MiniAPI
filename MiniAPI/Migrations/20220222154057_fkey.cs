using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniAPI.Migrations
{
    public partial class fkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_superheroes_BranchId",
                table: "superheroes",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_superheroes_branchs_BranchId",
                table: "superheroes",
                column: "BranchId",
                principalTable: "branchs",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_superheroes_branchs_BranchId",
                table: "superheroes");

            migrationBuilder.DropIndex(
                name: "IX_superheroes_BranchId",
                table: "superheroes");
        }
    }
}
