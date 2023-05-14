using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sep4");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pg_catalog.adminpack", ",,");

            migrationBuilder.CreateTable(
                name: "users",
                schema: "sep4",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "iotdevice",
                schema: "sep4",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("iotdevice_pkey", x => x.id);
                    table.ForeignKey(
                        name: "iotdevice_user_id_fkey",
                        column: x => x.user_id,
                        principalSchema: "sep4",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "measurement",
                schema: "sep4",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<int>(type: "integer", nullable: false),
                    time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    humidity = table.Column<int>(type: "integer", nullable: false),
                    co2 = table.Column<int>(type: "integer", nullable: false),
                    temperature = table.Column<int>(type: "integer", nullable: false),
                    device_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("measurement_pkey", x => x.id);
                    table.ForeignKey(
                        name: "measurement_device_id_fkey",
                        column: x => x.device_id,
                        principalSchema: "sep4",
                        principalTable: "iotdevice",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "preset",
                schema: "sep4",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    min_humidity = table.Column<int>(type: "integer", nullable: false),
                    max_humidity = table.Column<int>(type: "integer", nullable: false),
                    min_co2 = table.Column<int>(type: "integer", nullable: false),
                    max_co2 = table.Column<int>(type: "integer", nullable: false),
                    min_temperature = table.Column<int>(type: "integer", nullable: false),
                    max_temperature = table.Column<int>(type: "integer", nullable: false),
                    device_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("preset_pkey", x => x.id);
                    table.ForeignKey(
                        name: "preset_device_id_fkey",
                        column: x => x.device_id,
                        principalSchema: "sep4",
                        principalTable: "iotdevice",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_iotdevice_user_id",
                schema: "sep4",
                table: "iotdevice",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_measurement_device_id",
                schema: "sep4",
                table: "measurement",
                column: "device_id");

            migrationBuilder.CreateIndex(
                name: "IX_preset_device_id",
                schema: "sep4",
                table: "preset",
                column: "device_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "measurement",
                schema: "sep4");

            migrationBuilder.DropTable(
                name: "preset",
                schema: "sep4");

            migrationBuilder.DropTable(
                name: "iotdevice",
                schema: "sep4");

            migrationBuilder.DropTable(
                name: "users",
                schema: "sep4");
        }
    }
}
