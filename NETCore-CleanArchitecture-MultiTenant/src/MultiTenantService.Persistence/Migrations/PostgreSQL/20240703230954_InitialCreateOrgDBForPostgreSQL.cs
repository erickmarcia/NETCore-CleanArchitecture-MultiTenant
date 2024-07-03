using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MultiTenantService.Persistence.Migrations.PostgreSQL
{
    /// <inheritdoc />
    public partial class InitialCreateOrgDBForPostgreSQL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Organizacion");

            migrationBuilder.EnsureSchema(
                name: "Usuarios");

            migrationBuilder.CreateTable(
                name: "Organizacion",
                schema: "Organizacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaCreacion = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UsuarioActualizacionId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaActualizacion = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UsuarioEliminacionId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaEliminacion = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Password = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    OrganizacionId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaCreacion = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UsuarioActualizacionId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaActualizacion = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UsuarioEliminacionId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaEliminacion = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Organizacion_OrganizacionId",
                        column: x => x.OrganizacionId,
                        principalSchema: "Organizacion",
                        principalTable: "Organizacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Organizacion",
                table: "Organizacion",
                columns: new[] { "Id", "Activo", "FechaActualizacion", "FechaCreacion", "FechaEliminacion", "Nombre", "UsuarioActualizacionId", "UsuarioEliminacionId", "UsuarioId" },
                values: new object[] { 1, true, null, new DateTimeOffset(new DateTime(2024, 7, 3, 17, 9, 54, 385, DateTimeKind.Unspecified).AddTicks(9983), new TimeSpan(0, -6, 0, 0, 0)), null, "Organizacion1", null, null, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                schema: "Usuarios",
                table: "Usuarios",
                columns: new[] { "Id", "Activo", "FechaActualizacion", "FechaCreacion", "FechaEliminacion", "OrganizacionId", "Password", "UserName", "UsuarioActualizacionId", "UsuarioEliminacionId", "UsuarioId" },
                values: new object[] { 1, true, null, new DateTimeOffset(new DateTime(2024, 7, 3, 17, 9, 54, 386, DateTimeKind.Unspecified).AddTicks(116), new TimeSpan(0, -6, 0, 0, 0)), null, 1, "Admin.123", "Admin", null, null, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_OrganizacionId",
                schema: "Usuarios",
                table: "Usuarios",
                column: "OrganizacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "Usuarios");

            migrationBuilder.DropTable(
                name: "Organizacion",
                schema: "Organizacion");
        }
    }
}
