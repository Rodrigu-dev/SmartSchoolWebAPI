﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.WebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SobreNome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataMatricula = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    StatusMatricula = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeCurso = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Registro = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SobreNome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataInicial = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    PrerequisitoId = table.Column<int>(type: "int", nullable: true),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Nota = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataFim", "DataMatricula", "DataNascimento", "Matricula", "Nome", "SobreNome", "StatusMatricula", "Telefone" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(4332), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", true, "33225555" },
                    { 2, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(5844), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", true, "3354288" },
                    { 3, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(5858), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", true, "55668899" },
                    { 4, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(5863), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", true, "6565659" },
                    { 5, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(5868), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", true, "565685415" },
                    { 6, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(5877), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", true, "456454545" },
                    { 7, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(5881), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", true, "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "NomeCurso" },
                values: new object[,]
                {
                    { 1, "Tecnologia da informação" },
                    { 2, "Sistemas de Informação" },
                    { 3, "Ciência da Conputação" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicial", "Nome", "Registro", "SobreNome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2021, 8, 24, 10, 6, 40, 192, DateTimeKind.Local).AddTicks(7328), "Lauro", 1, "Oliveira", null },
                    { 2, true, null, new DateTime(2021, 8, 24, 10, 6, 40, 192, DateTimeKind.Local).AddTicks(8283), "Roberto", 2, "Soares", null },
                    { 3, true, null, new DateTime(2021, 8, 24, 10, 6, 40, 192, DateTimeKind.Local).AddTicks(8289), "Ronaldo", 3, "Marconi", null },
                    { 4, true, null, new DateTime(2021, 8, 24, 10, 6, 40, 192, DateTimeKind.Local).AddTicks(8290), "Rodrigo", 4, "Carvalho", null },
                    { 5, true, null, new DateTime(2021, 8, 24, 10, 6, 40, 192, DateTimeKind.Local).AddTicks(8292), "Alexandre", 5, "Montanha", null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Matemática", null, 1 },
                    { 2, 0, 3, "Matemática", null, 1 },
                    { 3, 0, 3, "Física", null, 2 },
                    { 4, 0, 1, "Português", null, 3 },
                    { 5, 0, 1, "Inglês", null, 4 },
                    { 6, 0, 2, "Inglês", null, 4 },
                    { 7, 0, 3, "Inglês", null, 4 },
                    { 8, 0, 1, "Progamação", null, 5 },
                    { 9, 0, 2, "Programação", null, 5 },
                    { 10, 0, 3, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7652), null },
                    { 4, 5, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7665), null },
                    { 2, 5, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7656), null },
                    { 1, 5, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7651), null },
                    { 7, 4, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7677), null },
                    { 6, 4, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7673), null },
                    { 5, 4, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7666), null },
                    { 4, 4, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7663), null },
                    { 1, 4, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7647), null },
                    { 7, 3, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7676), null },
                    { 5, 5, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7667), null },
                    { 6, 3, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7670), null },
                    { 7, 2, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7675), null },
                    { 6, 2, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7669), null },
                    { 3, 2, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7659), null },
                    { 2, 2, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7653), null },
                    { 1, 2, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7224), null },
                    { 7, 1, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7674), null },
                    { 6, 1, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7668), null },
                    { 4, 1, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7662), null },
                    { 3, 1, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7658), null },
                    { 3, 3, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7660), null },
                    { 7, 5, null, new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7678), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
