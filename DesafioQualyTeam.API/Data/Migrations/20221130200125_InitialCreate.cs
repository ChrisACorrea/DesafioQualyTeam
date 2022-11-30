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
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProcessoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CategoriaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProcessoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("600f3fda-d690-4116-b7ab-1c7740fd46c3"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(4789), "Processo_02", new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(4789) },
                    { new Guid("66f30ab7-fc63-4347-9c94-755d8c0f790f"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(4814), "Processo_05", new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(4814) },
                    { new Guid("8a0e1284-8b83-4d75-a5b8-7427ac40f7c0"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(4741), "Processo_01", new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(4741) },
                    { new Guid("b4185d9e-f665-4bee-b764-ade04036354e"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(4807), "Processo_04", new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(4807) },
                    { new Guid("ee5fe867-fe4e-40d3-bda6-9ee6d3d71714"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(4799), "Processo_03", new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(4799) }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Criacao", "Nome", "ProcessoId", "UltimaAtualizacao" },
                values: new object[,]
                {
                    { new Guid("06a28f55-71b2-49c2-a4e1-5a8f5b86496e"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(5260), "Categoria_B_01", new Guid("600f3fda-d690-4116-b7ab-1c7740fd46c3"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(5260) },
                    { new Guid("15cbc4cd-0a1a-4a9a-871a-f1f4a6457ebd"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(5243), "Categoria_A_03", new Guid("8a0e1284-8b83-4d75-a5b8-7427ac40f7c0"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(5243) },
                    { new Guid("73c46241-9209-4a39-81f3-f60419aa4b3d"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(5236), "Categoria_A_02", new Guid("8a0e1284-8b83-4d75-a5b8-7427ac40f7c0"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(5236) },
                    { new Guid("c8a5d4f9-8c5f-4211-8449-375e42c76c30"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(5266), "Categoria_B_02", new Guid("600f3fda-d690-4116-b7ab-1c7740fd46c3"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(5266) },
                    { new Guid("eaa1721b-774b-4312-a984-d105d8d107bb"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(5222), "Categoria_A_01", new Guid("8a0e1284-8b83-4d75-a5b8-7427ac40f7c0"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(5222) },
                    { new Guid("eb172cfd-7e8b-4f20-8ea6-192579bdd074"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(5273), "Categoria_B_03", new Guid("600f3fda-d690-4116-b7ab-1c7740fd46c3"), new DateTime(2022, 11, 30, 17, 1, 24, 585, DateTimeKind.Local).AddTicks(5273) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_DetalhesArquivoId",
                table: "Arquivos",
                column: "DetalhesArquivoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_ProcessoId",
                table: "Categorias",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalhesArquivos_DocumentoId",
                table: "DetalhesArquivos",
                column: "DocumentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_CategoriaId",
                table: "Documentos",
                column: "CategoriaId");

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
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Processos");
        }
    }
}
