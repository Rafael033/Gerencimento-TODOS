using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TODOS.API.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_historico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_ini = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data_fim = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_historico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prioridade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Solicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_ini = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Fim = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tarefas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoTarefas",
                columns: table => new
                {
                    Tarefa_id = table.Column<int>(type: "int", nullable: false),
                    Historico_id = table.Column<int>(type: "int", nullable: false),
                    tb_tarefasId = table.Column<int>(type: "int", nullable: true),
                    tb_historicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoTarefas", x => new { x.Historico_id, x.Tarefa_id });
                    table.ForeignKey(
                        name: "FK_HistoricoTarefas_tb_historico_tb_historicoId",
                        column: x => x.tb_historicoId,
                        principalTable: "tb_historico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoTarefas_tb_tarefas_tb_tarefasId",
                        column: x => x.tb_tarefasId,
                        principalTable: "tb_tarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tb_tarefas",
                columns: new[] { "Id", "Data_Fim", "Data_ini", "Descricao", "Prioridade", "Responsavel", "Situacao", "Solicitante", "Tipo", "Titulo" },
                values: new object[] { 1, null, new DateTime(2022, 6, 20, 1, 29, 34, 200, DateTimeKind.Local).AddTicks(992), "Function para calcular frete", "Baixa", "rafael.nogueira", "To do", "claudia.silva", "Tarefa", "Desenvolver Function" });

            migrationBuilder.InsertData(
                table: "tb_tarefas",
                columns: new[] { "Id", "Data_Fim", "Data_ini", "Descricao", "Prioridade", "Responsavel", "Situacao", "Solicitante", "Tipo", "Titulo" },
                values: new object[] { 2, null, new DateTime(2022, 6, 20, 1, 29, 34, 200, DateTimeKind.Local).AddTicks(5885), null, "Alta", "rafael.nogueira", "Done", "raquel.souza", "Projeto", "Desenvolver Sistema" });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoTarefas_tb_historicoId",
                table: "HistoricoTarefas",
                column: "tb_historicoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoTarefas_tb_tarefasId",
                table: "HistoricoTarefas",
                column: "tb_tarefasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoTarefas");

            migrationBuilder.DropTable(
                name: "tb_historico");

            migrationBuilder.DropTable(
                name: "tb_tarefas");
        }
    }
}
