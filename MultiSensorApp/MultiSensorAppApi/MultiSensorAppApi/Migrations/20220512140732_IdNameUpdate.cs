using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiSensorAppApi.Migrations
{
    public partial class IdNameUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlertConfigurationId",
                table: "AlertConfigurations",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AlertConfigurations",
                newName: "AlertConfigurationId");
        }
    }
}
