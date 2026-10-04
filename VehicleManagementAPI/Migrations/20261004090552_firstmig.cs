using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VehicleManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class firstmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    MaxSpeed = table.Column<int>(type: "integer", nullable: false),
                    PlateNumber = table.Column<string>(type: "text", nullable: false),
                    FuelLevel = table.Column<double>(type: "double precision", nullable: false,maxLength:100),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VehicleType = table.Column<string>(name: "Vehicle Type", type: "character varying(13)", maxLength: 13, nullable: false),
                    DoorsCount = table.Column<int>(type: "integer", nullable: true),
                    TrunkCapacity = table.Column<double>(type: "double precision", nullable: true),
                    IsAutomatic = table.Column<bool>(type: "boolean", nullable: true),
                    EngineCapacity = table.Column<int>(type: "integer", nullable: true),
                    HasSidecar = table.Column<bool>(type: "boolean", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    CargoCapacity = table.Column<double>(type: "double precision", nullable: true),
                    AxleCount = table.Column<int>(type: "integer", nullable: true),
                    CurrentLoad = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_PlateNumber",
                table: "Vehicles",
                column: "PlateNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
