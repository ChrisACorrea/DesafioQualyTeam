using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioQualyTeam.API.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Processos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Codigo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Categoria = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProcessoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalhesArquivos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalhesArquivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalhesArquivos_Documentos_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "Documentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Dados = table.Column<byte[]>(type: "longblob", nullable: false),
                    DetalhesArquivoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arquivos_DetalhesArquivos_DetalhesArquivoId",
                        column: x => x.DetalhesArquivoId,
                        principalTable: "DetalhesArquivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Processos",
                columns: new[] { "Id", "Criacao", "Nome", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("600f3fda-d690-4116-b7ab-1c7740fd46c3"), new DateTime(2022, 11, 19, 15, 22, 40, 715, DateTimeKind.Local).AddTicks(787), "Processo_02", new DateTime(2022, 11, 19, 15, 22, 40, 715, DateTimeKind.Local).AddTicks(787) },
                    { new Guid("66f30ab7-fc63-4347-9c94-755d8c0f790f"), new DateTime(2022, 11, 19, 15, 22, 40, 715, DateTimeKind.Local).AddTicks(804), "Processo_05", new DateTime(2022, 11, 19, 15, 22, 40, 715, DateTimeKind.Local).AddTicks(804) },
                    { new Guid("8a0e1284-8b83-4d75-a5b8-7427ac40f7c0"), new DateTime(2022, 11, 19, 15, 22, 40, 715, DateTimeKind.Local).AddTicks(751), "Processo_01", new DateTime(2022, 11, 19, 15, 22, 40, 715, DateTimeKind.Local).AddTicks(751) },
                    { new Guid("b4185d9e-f665-4bee-b764-ade04036354e"), new DateTime(2022, 11, 19, 15, 22, 40, 715, DateTimeKind.Local).AddTicks(800), "Processo_04", new DateTime(2022, 11, 19, 15, 22, 40, 715, DateTimeKind.Local).AddTicks(800) },
                    { new Guid("ee5fe867-fe4e-40d3-bda6-9ee6d3d71714"), new DateTime(2022, 11, 19, 15, 22, 40, 715, DateTimeKind.Local).AddTicks(794), "Processo_03", new DateTime(2022, 11, 19, 15, 22, 40, 715, DateTimeKind.Local).AddTicks(794) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_DetalhesArquivoId",
                table: "Arquivos",
                column: "DetalhesArquivoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalhesArquivos_DocumentoId",
                table: "DetalhesArquivos",
                column: "DocumentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_Codigo",
                table: "Documentos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_ProcessoId",
                table: "Documentos",
                column: "ProcessoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivos");

            migrationBuilder.DropTable(
                name: "DetalhesArquivos");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Processos");
        }
    }
}
