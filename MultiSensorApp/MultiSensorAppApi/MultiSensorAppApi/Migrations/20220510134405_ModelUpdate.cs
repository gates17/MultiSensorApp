using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiSensorAppApi.Migrations
{
    public partial class ModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Categories_Type",
                table: "Categories",
                column: "Type",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_Type",
                table: "Categories");
        }
    }
}
