using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiSensorAppApi.Migrations
{
    public partial class ModelUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastAcsess",
                table: "AlertConfigurations",
                newName: "LastAccess");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastAccess",
                table: "AlertConfigurations",
                newName: "LastAcsess");
        }
    }
}
