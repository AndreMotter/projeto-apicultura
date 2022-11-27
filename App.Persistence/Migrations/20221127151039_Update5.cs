using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class Update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pessoa_cidade_CidadeId",
                table: "pessoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pessoa",
                table: "pessoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cidade",
                table: "cidade");

            migrationBuilder.RenameTable(
                name: "pessoa",
                newName: "Pessoa");

            migrationBuilder.RenameTable(
                name: "cidade",
                newName: "Cidade");

            migrationBuilder.RenameIndex(
                name: "IX_pessoa_CidadeId",
                table: "Pessoa",
                newName: "IX_Pessoa_CidadeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cidade",
                table: "Cidade",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CodigoAcesso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoAcesso", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Cidade_CidadeId",
                table: "Pessoa",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Cidade_CidadeId",
                table: "Pessoa");

            migrationBuilder.DropTable(
                name: "CodigoAcesso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cidade",
                table: "Cidade");

            migrationBuilder.RenameTable(
                name: "Pessoa",
                newName: "pessoa");

            migrationBuilder.RenameTable(
                name: "Cidade",
                newName: "cidade");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_CidadeId",
                table: "pessoa",
                newName: "IX_pessoa_CidadeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pessoa",
                table: "pessoa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cidade",
                table: "cidade",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoa_cidade_CidadeId",
                table: "pessoa",
                column: "CidadeId",
                principalTable: "cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
