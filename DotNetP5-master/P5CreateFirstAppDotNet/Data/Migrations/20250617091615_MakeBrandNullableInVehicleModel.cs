using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5CreateFirstAppDotNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeBrandNullableInVehicleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModels_Brands_BrandId",
                table: "VehicleModels");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModels_Name_BrandId",
                table: "VehicleModels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VehicleModels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "VehicleModels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModels_Brands_BrandId",
                table: "VehicleModels",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModels_Brands_BrandId",
                table: "VehicleModels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VehicleModels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "VehicleModels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_Name_BrandId",
                table: "VehicleModels",
                columns: new[] { "Name", "BrandId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModels_Brands_BrandId",
                table: "VehicleModels",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
