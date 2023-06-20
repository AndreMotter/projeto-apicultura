using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Cidade_CidadeId",
                table: "Pessoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa");

            migrationBuilder.RenameTable(
                name: "Pessoa",
                newName: "Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_CidadeId",
                table: "Usuario",
                newName: "IX_Usuario_CidadeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Cidade_CidadeId",
                table: "Usuario",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Cidade_CidadeId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Pessoa");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_CidadeId",
                table: "Pessoa",
                newName: "IX_Pessoa_CidadeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Cidade_CidadeId",
                table: "Pessoa",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id");
        }
    }
}
