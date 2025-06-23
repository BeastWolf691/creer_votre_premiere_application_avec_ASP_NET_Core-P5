using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5CreateFirstAppDotNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpVehicleBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleBrandId",
                table: "VehicleBrands");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleBrandId",
                table: "VehicleBrands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 1,
                column: "VehicleBrandId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 2,
                column: "VehicleBrandId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 3,
                column: "VehicleBrandId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 4,
                column: "VehicleBrandId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 5,
                column: "VehicleBrandId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 6,
                column: "VehicleBrandId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 7,
                column: "VehicleBrandId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 8,
                column: "VehicleBrandId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 9,
                column: "VehicleBrandId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 10,
                column: "VehicleBrandId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 11,
                column: "VehicleBrandId",
                value: 0);
        }
    }
}
