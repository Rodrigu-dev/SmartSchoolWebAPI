// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartSchool.WebAPI.Data;

namespace SmartSchool.WebAPI.Migrations
{
    [DbContext(typeof(SmartContext))]
    partial class SmartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataMatricula")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Matricula")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("SobreNome")
                        .HasColumnType("longtext");

                    b.Property<bool>("StatusMatricula")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataMatricula = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(4332),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 1,
                            Nome = "Marta",
                            SobreNome = "Kent",
                            StatusMatricula = true,
                            Telefone = "33225555"
                        },
                        new
                        {
                            Id = 2,
                            DataMatricula = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(5844),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 2,
                            Nome = "Paula",
                            SobreNome = "Isabela",
                            StatusMatricula = true,
                            Telefone = "3354288"
                        },
                        new
                        {
                            Id = 3,
                            DataMatricula = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(5858),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 3,
                            Nome = "Laura",
                            SobreNome = "Antonia",
                            StatusMatricula = true,
                            Telefone = "55668899"
                        },
                        new
                        {
                            Id = 4,
                            DataMatricula = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(5863),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 4,
                            Nome = "Luiza",
                            SobreNome = "Maria",
                            StatusMatricula = true,
                            Telefone = "6565659"
                        },
                        new
                        {
                            Id = 5,
                            DataMatricula = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(5868),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 5,
                            Nome = "Lucas",
                            SobreNome = "Machado",
                            StatusMatricula = true,
                            Telefone = "565685415"
                        },
                        new
                        {
                            Id = 6,
                            DataMatricula = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(5877),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 6,
                            Nome = "Pedro",
                            SobreNome = "Alvares",
                            StatusMatricula = true,
                            Telefone = "456454545"
                        },
                        new
                        {
                            Id = 7,
                            DataMatricula = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(5881),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 7,
                            Nome = "Paulo",
                            SobreNome = "José",
                            StatusMatricula = true,
                            Telefone = "9874512"
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.AlunoCurso", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.HasKey("AlunoId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("AlunosCursos");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.AlunoDisciplina", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("Nota")
                        .HasColumnType("int");

                    b.HasKey("AlunoId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("AlunosDisciplinas");

                    b.HasData(
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7224)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7647)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7651)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7652)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7653)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7656)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7658)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7659)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 3,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7660)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7662)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7663)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7665)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7666)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7667)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7668)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7669)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 3,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7670)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7673)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7674)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7675)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 3,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7676)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7677)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2021, 8, 24, 10, 6, 40, 196, DateTimeKind.Local).AddTicks(7678)
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomeCurso")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cursos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NomeCurso = "Tecnologia da informação"
                        },
                        new
                        {
                            Id = 2,
                            NomeCurso = "Sistemas de Informação"
                        },
                        new
                        {
                            Id = 3,
                            NomeCurso = "Ciência da Conputação"
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<int?>("PrerequisitoId")
                        .HasColumnType("int");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("PrerequisitoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplinas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Matemática",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 2,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Matemática",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 3,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Física",
                            ProfessorId = 2
                        },
                        new
                        {
                            Id = 4,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Português",
                            ProfessorId = 3
                        },
                        new
                        {
                            Id = 5,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 6,
                            CargaHoraria = 0,
                            CursoId = 2,
                            Nome = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 7,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 8,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Progamação",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 9,
                            CargaHoraria = 0,
                            CursoId = 2,
                            Nome = "Programação",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 10,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Programação",
                            ProfessorId = 5
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicial")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<int>("Registro")
                        .HasColumnType("int");

                    b.Property<string>("SobreNome")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataInicial = new DateTime(2021, 8, 24, 10, 6, 40, 192, DateTimeKind.Local).AddTicks(7328),
                            Nome = "Lauro",
                            Registro = 1,
                            SobreNome = "Oliveira"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            DataInicial = new DateTime(2021, 8, 24, 10, 6, 40, 192, DateTimeKind.Local).AddTicks(8283),
                            Nome = "Roberto",
                            Registro = 2,
                            SobreNome = "Soares"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            DataInicial = new DateTime(2021, 8, 24, 10, 6, 40, 192, DateTimeKind.Local).AddTicks(8289),
                            Nome = "Ronaldo",
                            Registro = 3,
                            SobreNome = "Marconi"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            DataInicial = new DateTime(2021, 8, 24, 10, 6, 40, 192, DateTimeKind.Local).AddTicks(8290),
                            Nome = "Rodrigo",
                            Registro = 4,
                            SobreNome = "Carvalho"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            DataInicial = new DateTime(2021, 8, 24, 10, 6, 40, 192, DateTimeKind.Local).AddTicks(8292),
                            Nome = "Alexandre",
                            Registro = 5,
                            SobreNome = "Montanha"
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.AlunoCurso", b =>
                {
                    b.HasOne("SmartSchool.WebAPI.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.WebAPI.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.AlunoDisciplina", b =>
                {
                    b.HasOne("SmartSchool.WebAPI.Models.Aluno", "Aluno")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.WebAPI.Models.Disciplina", "Disciplina")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Disciplina", b =>
                {
                    b.HasOne("SmartSchool.WebAPI.Models.Curso", "Curso")
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.WebAPI.Models.Disciplina", "Prerequisito")
                        .WithMany()
                        .HasForeignKey("PrerequisitoId");

                    b.HasOne("SmartSchool.WebAPI.Models.Professor", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Prerequisito");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Aluno", b =>
                {
                    b.Navigation("AlunosDisciplinas");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Curso", b =>
                {
                    b.Navigation("Disciplinas");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Disciplina", b =>
                {
                    b.Navigation("AlunosDisciplinas");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Professor", b =>
                {
                    b.Navigation("Disciplinas");
                });
#pragma warning restore 612, 618
        }
    }
}
