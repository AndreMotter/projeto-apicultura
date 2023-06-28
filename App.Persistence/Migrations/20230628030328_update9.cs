using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricoAcessos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Operacao = table.Column<int>(type: "integer", nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoAcessos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoAcessos_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAcessos_UsuarioId",
                table: "HistoricoAcessos",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoAcessos");
        }
    }
}
