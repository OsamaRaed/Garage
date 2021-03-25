using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage.Api.Data.Migrations
{
    public partial class m8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServices_MaintenanceReports_MaintenanceReportId",
                table: "MaintenanceServices");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceServices_MaintenanceReportId",
                table: "MaintenanceServices");

            migrationBuilder.DropColumn(
                name: "MaintenanceReportId",
                table: "MaintenanceServices");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceServiceId",
                table: "MaintenanceReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceReports_MaintenanceServiceId",
                table: "MaintenanceReports",
                column: "MaintenanceServiceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceReports_MaintenanceServices_MaintenanceServiceId",
                table: "MaintenanceReports",
                column: "MaintenanceServiceId",
                principalTable: "MaintenanceServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceReports_MaintenanceServices_MaintenanceServiceId",
                table: "MaintenanceReports");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceReports_MaintenanceServiceId",
                table: "MaintenanceReports");

            migrationBuilder.DropColumn(
                name: "MaintenanceServiceId",
                table: "MaintenanceReports");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceReportId",
                table: "MaintenanceServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServices_MaintenanceReportId",
                table: "MaintenanceServices",
                column: "MaintenanceReportId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceServices_MaintenanceReports_MaintenanceReportId",
                table: "MaintenanceServices",
                column: "MaintenanceReportId",
                principalTable: "MaintenanceReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
