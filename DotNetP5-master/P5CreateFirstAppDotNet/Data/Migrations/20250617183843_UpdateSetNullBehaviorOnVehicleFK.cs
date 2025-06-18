using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5CreateFirstAppDotNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSetNullBehaviorOnVehicleFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Statuses_StatusId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Trims_TrimId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleModels_VehicleModelId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleModelId",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TrimId",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Statuses_StatusId",
                table: "Vehicles",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Trims_TrimId",
                table: "Vehicles",
                column: "TrimId",
                principalTable: "Trims",
                principalColumn: "TrimId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleModels_VehicleModelId",
                table: "Vehicles",
                column: "VehicleModelId",
                principalTable: "VehicleModels",
                principalColumn: "VehicleModelId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Statuses_StatusId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Trims_TrimId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleModels_VehicleModelId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleModelId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrimId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Statuses_StatusId",
                table: "Vehicles",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Trims_TrimId",
                table: "Vehicles",
                column: "TrimId",
                principalTable: "Trims",
                principalColumn: "TrimId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleModels_VehicleModelId",
                table: "Vehicles",
                column: "VehicleModelId",
                principalTable: "VehicleModels",
                principalColumn: "VehicleModelId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
