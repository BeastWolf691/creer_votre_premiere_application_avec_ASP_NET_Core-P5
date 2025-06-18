using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5CreateFirstAppDotNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeleteBehaviorOnTrimVehicleModelFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trims_Name_VehicleModelId",
                table: "Trims");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Trims",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Trims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Trims_Name_VehicleModelId",
                table: "Trims",
                columns: new[] { "Name", "VehicleModelId" },
                unique: true,
                filter: "[VehicleModelId] IS NOT NULL");
        }
    }
}
