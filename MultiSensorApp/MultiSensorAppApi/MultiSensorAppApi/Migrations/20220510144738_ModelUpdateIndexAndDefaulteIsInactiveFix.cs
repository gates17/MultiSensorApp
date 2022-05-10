using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiSensorAppApi.Migrations
{
    public partial class ModelUpdateIndexAndDefaulteIsInactiveFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Alerts",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45);

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_Name",
                table: "Sensors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Type",
                table: "Roles",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Name",
                table: "Areas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_Value",
                table: "Alerts",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlertLevels_Level",
                table: "AlertLevels",
                column: "Level",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlertConfigurations_UserId",
                table: "AlertConfigurations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertConfigurations_Users_UserId",
                table: "AlertConfigurations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlertConfigurations_Users_UserId",
                table: "AlertConfigurations");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_Name",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_Roles_Type",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Areas_Name",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_Value",
                table: "Alerts");

            migrationBuilder.DropIndex(
                name: "IX_AlertLevels_Level",
                table: "AlertLevels");

            migrationBuilder.DropIndex(
                name: "IX_AlertConfigurations_UserId",
                table: "AlertConfigurations");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Alerts",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45,
                oldNullable: true);
        }
    }
}
