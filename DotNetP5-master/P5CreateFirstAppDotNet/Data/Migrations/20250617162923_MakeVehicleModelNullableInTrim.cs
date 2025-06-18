using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5CreateFirstAppDotNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeVehicleModelNullableInTrim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trims_VehicleModels_VehicleModelId",
                table: "Trims");

            migrationBuilder.DropIndex(
                name: "IX_Trims_Name_VehicleModelId",
                table: "Trims");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleModelId",
                table: "Trims",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Trims_Name_VehicleModelId",
                table: "Trims",
                columns: new[] { "Name", "VehicleModelId" },
                unique: true,
                filter: "[VehicleModelId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Trims_VehicleModels_VehicleModelId",
                table: "Trims",
                column: "VehicleModelId",
                principalTable: "VehicleModels",
                principalColumn: "VehicleModelId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trims_VehicleModels_VehicleModelId",
                table: "Trims");

            migrationBuilder.DropIndex(
                name: "IX_Trims_Name_VehicleModelId",
                table: "Trims");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleModelId",
                table: "Trims",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trims_Name_VehicleModelId",
                table: "Trims",
                columns: new[] { "Name", "VehicleModelId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trims_VehicleModels_VehicleModelId",
                table: "Trims",
                column: "VehicleModelId",
                principalTable: "VehicleModels",
                principalColumn: "VehicleModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
