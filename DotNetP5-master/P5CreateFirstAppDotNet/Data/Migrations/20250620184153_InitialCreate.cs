using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P5CreateFirstAppDotNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTrims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrimLabel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTrims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YearOfProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearOfProductions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfMediaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medias_TypeOfMedias_TypeOfMediaId",
                        column: x => x.TypeOfMediaId,
                        principalTable: "TypeOfMedias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleBrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleBrands_VehicleBrandId",
                        column: x => x.VehicleBrandId,
                        principalTable: "VehicleBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModelVehicleTrims",
                columns: table => new
                {
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    VehicleTrimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModelVehicleTrims", x => new { x.VehicleModelId, x.VehicleTrimId });
                    table.ForeignKey(
                        name: "FK_VehicleModelVehicleTrims_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleModelVehicleTrims_VehicleTrims_VehicleTrimId",
                        column: x => x.VehicleTrimId,
                        principalTable: "VehicleTrims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfProductionId = table.Column<int>(type: "int", nullable: false),
                    VehicleBrandId = table.Column<int>(type: "int", nullable: false),
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    VehicleTrimId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleBrands_VehicleBrandId",
                        column: x => x.VehicleBrandId,
                        principalTable: "VehicleBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTrims_VehicleTrimId",
                        column: x => x.VehicleTrimId,
                        principalTable: "VehicleTrims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_YearOfProductions_YearOfProductionId",
                        column: x => x.YearOfProductionId,
                        principalTable: "YearOfProductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepairCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repairs_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleMedias",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMedias", x => new { x.VehicleId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_VehicleMedias_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleMedias_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TypeOfMedias",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Image" },
                    { 2, "PDF" },
                    { 3, "Doc" }
                });

            migrationBuilder.InsertData(
                table: "VehicleBrands",
                columns: new[] { "Id", "Brand" },
                values: new object[,]
                {
                    { 1, "Toyota" },
                    { 2, "Ford" },
                    { 3, "Honda" },
                    { 4, "Chevrolet" },
                    { 5, "Nissan" },
                    { 6, "Volkswagen" },
                    { 7, "Renault" },
                    { 8, "Peugeot" },
                    { 9, "Citroën" },
                    { 10, "Jeep" },
                    { 11, "Mazda" }
                });

            migrationBuilder.InsertData(
                table: "VehicleTrims",
                columns: new[] { "Id", "TrimLabel" },
                values: new object[,]
                {
                    { 1, "Base" },
                    { 2, "SE" },
                    { 3, "LE" },
                    { 4, "S" },
                    { 5, "SE" },
                    { 6, "Titanium" },
                    { 7, "LX" },
                    { 8, "EX" },
                    { 9, "Touring" }
                });

            migrationBuilder.InsertData(
                table: "YearOfProductions",
                columns: new[] { "Id", "Year" },
                values: new object[,]
                {
                    { 1, 1990 },
                    { 2, 1991 },
                    { 3, 1992 },
                    { 4, 1993 },
                    { 5, 1994 },
                    { 6, 1995 },
                    { 7, 1996 },
                    { 8, 1997 },
                    { 9, 1998 },
                    { 10, 1999 },
                    { 11, 2000 },
                    { 12, 2001 },
                    { 13, 2002 },
                    { 14, 2003 },
                    { 15, 2004 },
                    { 16, 2005 },
                    { 17, 2006 },
                    { 18, 2007 },
                    { 19, 2008 },
                    { 20, 2009 },
                    { 21, 2010 },
                    { 22, 2011 },
                    { 23, 2012 },
                    { 24, 2013 },
                    { 25, 2014 },
                    { 26, 2015 },
                    { 27, 2016 },
                    { 28, 2017 },
                    { 29, 2018 },
                    { 30, 2019 },
                    { 31, 2020 },
                    { 32, 2021 },
                    { 33, 2022 },
                    { 34, 2023 },
                    { 35, 2024 },
                    { 36, 2025 }
                });

            migrationBuilder.InsertData(
                table: "Medias",
                columns: new[] { "Id", "Label", "Path", "TypeOfMediaId" },
                values: new object[,]
                {
                    { 1, "Car 1 Image", "/images/vehicles/Car (1).jpg", 1 },
                    { 2, "Car 2 Image", "/images/vehicles/Car (2).jpg", 1 },
                    { 3, "Car 3 Image", "/images/vehicles/Car (3).jpg", 1 },
                    { 4, "Car 4 Image", "/images/vehicles/Car (4).jpg", 1 },
                    { 5, "Car 5 Image", "/images/vehicles/Car (5).jpg", 1 },
                    { 6, "Car 6 Image", "/images/vehicles/Car (6).jpg", 1 },
                    { 7, "Car 7 Image", "/images/vehicles/Car (7).jpg", 1 },
                    { 8, "Car 8 Image", "/images/vehicles/Car (8).jpg", 1 },
                    { 9, "Car 9 Image", "/images/vehicles/Car (9).jpg", 1 },
                    { 10, "Car 10 Image", "/images/vehicles/Car (10).jpg", 1 }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Model", "VehicleBrandId" },
                values: new object[,]
                {
                    { 1, "Corolla", 1 },
                    { 2, "Focus", 2 },
                    { 3, "Civic", 3 },
                    { 4, "Impala", 4 },
                    { 5, "Altima", 5 },
                    { 6, "Golf", 6 },
                    { 7, "Clio", 7 },
                    { 8, "208", 8 },
                    { 9, "C3", 9 },
                    { 10, "Wrangler", 10 },
                    { 11, "CX-5", 11 }
                });

            migrationBuilder.InsertData(
                table: "VehicleModelVehicleTrims",
                columns: new[] { "VehicleModelId", "VehicleTrimId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 2 },
                    { 3, 4 },
                    { 4, 3 },
                    { 4, 5 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Description", "Label", "Status", "VIN", "VehicleBrandId", "VehicleModelId", "VehicleTrimId", "YearOfProductionId" },
                values: new object[,]
                {
                    { 1, "Vehicle description 1", "Vehicle 1", 1, "1HGCM82633A123456", 1, 4, 1, 1 },
                    { 2, "Vehicle description 2", "Vehicle 2", 0, "1HGCM82633A654321", 2, 2, 1, 2 },
                    { 3, "Vehicle description 3", "Vehicle 3", 0, "1HGCM82633A789456", 3, 3, 2, 3 },
                    { 4, "Vehicle description 4", "Vehicle 4", 1, "1HGCM82633A987654", 4, 4, 3, 4 },
                    { 5, "Vehicle description 5", "Vehicle 5", 2, "1HGCM82633A456789", 5, 5, 4, 5 },
                    { 6, "Vehicle description 6", "Vehicle 6", 1, "1HGCM82633A321654", 6, 6, 5, 6 },
                    { 7, "Vehicle description 7", "Vehicle 7", 1, "1HGCM82633A159753", 7, 7, 6, 7 },
                    { 8, "Vehicle description 8", "Vehicle 8", 2, "1HGCM82633A357951", 8, 8, 7, 8 },
                    { 9, "Vehicle description 9", "Vehicle 9", 0, "1HGCM82633A753159", 9, 9, 8, 9 },
                    { 10, "Vehicle description 10", "Vehicle 10", 1, "1HGCM82633A852963", 10, 10, 9, 10 }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "PurchaseDate", "PurchasePrice", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000.00m, 1 },
                    { 2, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000.00m, 2 },
                    { 3, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 18000.00m, 3 },
                    { 4, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 22000.00m, 4 },
                    { 5, new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 25000.00m, 5 },
                    { 6, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000.00m, 6 },
                    { 7, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 27000.00m, 7 },
                    { 8, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 32000.00m, 8 },
                    { 9, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 29000.00m, 9 }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "Description", "RepairCost", "RepairDate", "VehicleId" },
                values: new object[,]
                {
                    { 1, "Repair description 1", 500.00m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Repair description 2", 700.00m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, "Repair description 3", 600.00m, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 4, "Repair description 4", 800.00m, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 5, "Repair description 5", 900.00m, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 6, "Repair description 6", 1000.00m, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 7, "Repair description 7", 1100.00m, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 8, "Repair description 8", 1200.00m, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "SaleDate", "SalePrice", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000.00m, 5 },
                    { 2, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000.00m, 3 }
                });

            migrationBuilder.InsertData(
                table: "VehicleMedias",
                columns: new[] { "MediaId", "VehicleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_TypeOfMediaId",
                table: "Medias",
                column: "TypeOfMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_VehicleId",
                table: "Purchases",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_VehicleId",
                table: "Repairs",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_VehicleId",
                table: "Sales",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleMedias_MediaId",
                table: "VehicleMedias",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleBrandId",
                table: "VehicleModels",
                column: "VehicleBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModelVehicleTrims_VehicleTrimId",
                table: "VehicleModelVehicleTrims",
                column: "VehicleTrimId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleBrandId",
                table: "Vehicles",
                column: "VehicleBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleModelId",
                table: "Vehicles",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTrimId",
                table: "Vehicles",
                column: "VehicleTrimId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_YearOfProductionId",
                table: "Vehicles",
                column: "YearOfProductionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "VehicleMedias");

            migrationBuilder.DropTable(
                name: "VehicleModelVehicleTrims");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "TypeOfMedias");

            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleTrims");

            migrationBuilder.DropTable(
                name: "YearOfProductions");

            migrationBuilder.DropTable(
                name: "VehicleBrands");
        }
    }
}
