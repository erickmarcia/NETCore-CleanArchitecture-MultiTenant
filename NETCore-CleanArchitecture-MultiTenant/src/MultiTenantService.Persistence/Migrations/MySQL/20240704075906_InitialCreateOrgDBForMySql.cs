using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiTenantService.Persistence.Migrations.MySQL
{
    /// <inheritdoc />
    public partial class InitialCreateOrgDBForMySql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Organizacion");

            migrationBuilder.EnsureSchema(
                name: "Usuarios");

            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Organizacion",
                schema: "Organizacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FechaCreacion = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UsuarioActualizacionId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    FechaActualizacion = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    UsuarioEliminacionId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    FechaEliminacion = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganizacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FechaCreacion = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UsuarioActualizacionId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    FechaActualizacion = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    UsuarioEliminacionId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    FechaEliminacion = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                schema: "Organizacion",
                table: "Organizacion",
                columns: new[] { "Id", "Activo", "FechaActualizacion", "FechaCreacion", "FechaEliminacion", "Nombre", "UsuarioActualizacionId", "UsuarioEliminacionId", "UsuarioId" },
                values: new object[] { 1, true, null, new DateTimeOffset(new DateTime(2024, 7, 4, 1, 59, 6, 497, DateTimeKind.Unspecified).AddTicks(8773), new TimeSpan(0, -6, 0, 0, 0)), null, "Organizacion1", null, null, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                schema: "Usuarios",
                table: "Usuarios",
                columns: new[] { "Id", "Activo", "FechaActualizacion", "FechaCreacion", "FechaEliminacion", "OrganizacionId", "Password", "UserName", "UsuarioActualizacionId", "UsuarioEliminacionId", "UsuarioId" },
                values: new object[] { 1, true, null, new DateTimeOffset(new DateTime(2024, 7, 4, 1, 59, 6, 497, DateTimeKind.Unspecified).AddTicks(8927), new TimeSpan(0, -6, 0, 0, 0)), null, 1, "Admin.123", "Admin", null, null, new Guid("00000000-0000-0000-0000-000000000000") });

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
