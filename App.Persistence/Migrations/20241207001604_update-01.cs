using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "abe_apicultor",
                columns: table => new
                {
                    api_codigo = table.Column<Guid>(type: "uuid", nullable: false),
                    api_nome = table.Column<string>(type: "text", nullable: true),
                    api_cpfcnpj = table.Column<string>(type: "text", nullable: true),
                    api_telefone = table.Column<string>(type: "text", nullable: true),
                    api_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abe_apicultor", x => x.api_codigo);
                });

            migrationBuilder.CreateTable(
                name: "abe_raca",
                columns: table => new
                {
                    rac_codigo = table.Column<Guid>(type: "uuid", nullable: false),
                    rac_descricao = table.Column<string>(type: "text", nullable: true),
                    rac_origem = table.Column<string>(type: "text", nullable: true),
                    rac_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abe_raca", x => x.rac_codigo);
                });

            migrationBuilder.CreateTable(
                name: "abe_unidademedida",
                columns: table => new
                {
                    uni_codigo = table.Column<Guid>(type: "uuid", nullable: false),
                    uni_descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abe_unidademedida", x => x.uni_codigo);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: true),
                    Senha = table.Column<string>(type: "text", nullable: true),
                    Permissao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "abe_apiario",
                columns: table => new
                {
                    apa_codigo = table.Column<Guid>(type: "uuid", nullable: false),
                    apa_descricao = table.Column<string>(type: "text", nullable: true),
                    apa_endereco = table.Column<string>(type: "text", nullable: true),
                    api_codigoresponsavel = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abe_apiario", x => x.apa_codigo);
                    table.ForeignKey(
                        name: "FK_abe_apiario_abe_apicultor_api_codigoresponsavel",
                        column: x => x.api_codigoresponsavel,
                        principalTable: "abe_apicultor",
                        principalColumn: "api_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abe_colmeia",
                columns: table => new
                {
                    col_codigo = table.Column<Guid>(type: "uuid", nullable: false),
                    col_descricao = table.Column<string>(type: "text", nullable: true),
                    col_datainstalacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    col_status = table.Column<string>(type: "text", nullable: true),
                    col_numero = table.Column<int>(type: "integer", nullable: false),
                    col_latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    col_longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    rac_codigo = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abe_colmeia", x => x.col_codigo);
                    table.ForeignKey(
                        name: "FK_abe_colmeia_abe_raca_rac_codigo",
                        column: x => x.rac_codigo,
                        principalTable: "abe_raca",
                        principalColumn: "rac_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abe_tipodeitura",
                columns: table => new
                {
                    tip_codigo = table.Column<Guid>(type: "uuid", nullable: false),
                    tip_descricao = table.Column<string>(type: "text", nullable: true),
                    uni_codigo = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abe_tipodeitura", x => x.tip_codigo);
                    table.ForeignKey(
                        name: "FK_abe_tipodeitura_abe_unidademedida_uni_codigo",
                        column: x => x.uni_codigo,
                        principalTable: "abe_unidademedida",
                        principalColumn: "uni_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abe_log",
                columns: table => new
                {
                    log_codigo = table.Column<Guid>(type: "uuid", nullable: false),
                    log_tabela = table.Column<string>(type: "text", nullable: true),
                    log_operacao = table.Column<string>(type: "text", nullable: true),
                    log_data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    usu_codigo = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abe_log", x => x.log_codigo);
                    table.ForeignKey(
                        name: "FK_abe_log_Usuario_usu_codigo",
                        column: x => x.usu_codigo,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abe_apicultorcolmeia",
                columns: table => new
                {
                    cpi_codigo = table.Column<Guid>(type: "uuid", nullable: false),
                    cpi_principal = table.Column<bool>(type: "boolean", nullable: false),
                    cpi_status = table.Column<bool>(type: "boolean", nullable: false),
                    cpi_datainicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    col_codigo = table.Column<Guid>(type: "uuid", nullable: false),
                    api_codigo = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abe_apicultorcolmeia", x => x.cpi_codigo);
                    table.ForeignKey(
                        name: "FK_abe_apicultorcolmeia_abe_apicultor_api_codigo",
                        column: x => x.api_codigo,
                        principalTable: "abe_apicultor",
                        principalColumn: "api_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_abe_apicultorcolmeia_abe_colmeia_col_codigo",
                        column: x => x.col_codigo,
                        principalTable: "abe_colmeia",
                        principalColumn: "col_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abe_inspecao",
                columns: table => new
                {
                    ins_codigo = table.Column<Guid>(type: "uuid", nullable: false),
                    ins_data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ins_situacao = table.Column<int>(type: "integer", nullable: false),
                    ins_observacao = table.Column<string>(type: "text", nullable: true),
                    api_codigo = table.Column<Guid>(type: "uuid", nullable: false),
                    col_codigo = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abe_inspecao", x => x.ins_codigo);
                    table.ForeignKey(
                        name: "FK_abe_inspecao_abe_apicultor_api_codigo",
                        column: x => x.api_codigo,
                        principalTable: "abe_apicultor",
                        principalColumn: "api_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_abe_inspecao_abe_colmeia_col_codigo",
                        column: x => x.col_codigo,
                        principalTable: "abe_colmeia",
                        principalColumn: "col_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abe_leitura",
                columns: table => new
                {
                    lei_codigo = table.Column<Guid>(type: "uuid", nullable: false),
                    col_codigo = table.Column<Guid>(type: "uuid", nullable: false),
                    tip_codigo = table.Column<Guid>(type: "uuid", nullable: false),
                    lei_data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lei_valor = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abe_leitura", x => x.lei_codigo);
                    table.ForeignKey(
                        name: "FK_abe_leitura_abe_colmeia_col_codigo",
                        column: x => x.col_codigo,
                        principalTable: "abe_colmeia",
                        principalColumn: "col_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_abe_leitura_abe_tipodeitura_tip_codigo",
                        column: x => x.tip_codigo,
                        principalTable: "abe_tipodeitura",
                        principalColumn: "tip_codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_abe_apiario_api_codigoresponsavel",
                table: "abe_apiario",
                column: "api_codigoresponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_abe_apicultorcolmeia_api_codigo",
                table: "abe_apicultorcolmeia",
                column: "api_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_abe_apicultorcolmeia_col_codigo",
                table: "abe_apicultorcolmeia",
                column: "col_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_abe_colmeia_rac_codigo",
                table: "abe_colmeia",
                column: "rac_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_abe_inspecao_api_codigo",
                table: "abe_inspecao",
                column: "api_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_abe_inspecao_col_codigo",
                table: "abe_inspecao",
                column: "col_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_abe_leitura_col_codigo",
                table: "abe_leitura",
                column: "col_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_abe_leitura_tip_codigo",
                table: "abe_leitura",
                column: "tip_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_abe_log_usu_codigo",
                table: "abe_log",
                column: "usu_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_abe_tipodeitura_uni_codigo",
                table: "abe_tipodeitura",
                column: "uni_codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abe_apiario");

            migrationBuilder.DropTable(
                name: "abe_apicultorcolmeia");

            migrationBuilder.DropTable(
                name: "abe_inspecao");

            migrationBuilder.DropTable(
                name: "abe_leitura");

            migrationBuilder.DropTable(
                name: "abe_log");

            migrationBuilder.DropTable(
                name: "abe_apicultor");

            migrationBuilder.DropTable(
                name: "abe_colmeia");

            migrationBuilder.DropTable(
                name: "abe_tipodeitura");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "abe_raca");

            migrationBuilder.DropTable(
                name: "abe_unidademedida");
        }
    }
}
