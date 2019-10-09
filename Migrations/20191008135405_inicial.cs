using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Campeonato.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_fase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Categoria = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_fase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_goleiro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Categoria = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_goleiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_time",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Categoria = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Escudo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_time", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rel_time_jogador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TimeId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rel_time_jogador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rel_time_jogador_tbl_time_TimeId",
                        column: x => x.TimeId,
                        principalTable: "tbl_time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_jogo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FaseId = table.Column<int>(nullable: true),
                    Data_Hora = table.Column<DateTime>(nullable: false),
                    Time_1Id = table.Column<int>(nullable: true),
                    Goleiro_1Id = table.Column<int>(nullable: true),
                    Resultado_1 = table.Column<int>(nullable: true),
                    Time_2Id = table.Column<int>(nullable: true),
                    Goleiro_2Id = table.Column<int>(nullable: true),
                    Resultado_2 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_jogo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_jogo_tbl_fase_FaseId",
                        column: x => x.FaseId,
                        principalTable: "tbl_fase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_jogo_tbl_goleiro_Goleiro_1Id",
                        column: x => x.Goleiro_1Id,
                        principalTable: "tbl_goleiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_jogo_tbl_goleiro_Goleiro_2Id",
                        column: x => x.Goleiro_2Id,
                        principalTable: "tbl_goleiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_jogo_tbl_time_Time_1Id",
                        column: x => x.Time_1Id,
                        principalTable: "tbl_time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_jogo_tbl_time_Time_2Id",
                        column: x => x.Time_2Id,
                        principalTable: "tbl_time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rel_jogo_gols",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JogoId = table.Column<int>(nullable: true),
                    JogadorId = table.Column<int>(nullable: true),
                    Gols = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rel_jogo_gols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rel_jogo_gols_rel_time_jogador_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "rel_time_jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rel_jogo_gols_tbl_jogo_JogoId",
                        column: x => x.JogoId,
                        principalTable: "tbl_jogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rel_jogo_gols_JogadorId",
                table: "rel_jogo_gols",
                column: "JogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_rel_jogo_gols_JogoId",
                table: "rel_jogo_gols",
                column: "JogoId");

            migrationBuilder.CreateIndex(
                name: "IX_rel_time_jogador_TimeId",
                table: "rel_time_jogador",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_jogo_FaseId",
                table: "tbl_jogo",
                column: "FaseId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_jogo_Goleiro_1Id",
                table: "tbl_jogo",
                column: "Goleiro_1Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_jogo_Goleiro_2Id",
                table: "tbl_jogo",
                column: "Goleiro_2Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_jogo_Time_1Id",
                table: "tbl_jogo",
                column: "Time_1Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_jogo_Time_2Id",
                table: "tbl_jogo",
                column: "Time_2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rel_jogo_gols");

            migrationBuilder.DropTable(
                name: "rel_time_jogador");

            migrationBuilder.DropTable(
                name: "tbl_jogo");

            migrationBuilder.DropTable(
                name: "tbl_fase");

            migrationBuilder.DropTable(
                name: "tbl_goleiro");

            migrationBuilder.DropTable(
                name: "tbl_time");
        }
    }
}
