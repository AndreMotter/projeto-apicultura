﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "CodigoAcesso",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CodigoAcesso_UsuarioId",
                table: "CodigoAcesso",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_CodigoAcesso_Usuario_UsuarioId",
                table: "CodigoAcesso",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodigoAcesso_Usuario_UsuarioId",
                table: "CodigoAcesso");

            migrationBuilder.DropIndex(
                name: "IX_CodigoAcesso_UsuarioId",
                table: "CodigoAcesso");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "CodigoAcesso");
        }
    }
}