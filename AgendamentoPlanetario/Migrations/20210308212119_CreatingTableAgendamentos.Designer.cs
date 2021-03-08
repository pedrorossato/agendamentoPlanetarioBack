﻿// <auto-generated />
using AgendamentoPlanetario.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgendamentoPlanetario.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210308212119_CreatingTableAgendamentos")]
    partial class CreatingTableAgendamentos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AgendamentoPlanetario.Models.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AlunoDeficiente")
                        .HasColumnType("text")
                        .HasColumnName("alunodeficiente");

                    b.Property<int>("Alunos")
                        .HasColumnType("integer")
                        .HasColumnName("alunos");

                    b.Property<string>("DataSessao")
                        .HasColumnType("text")
                        .HasColumnName("datasessao");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("EmailProfessor")
                        .HasColumnType("text")
                        .HasColumnName("emailprofessor");

                    b.Property<string>("HoraSessao")
                        .HasColumnType("text")
                        .HasColumnName("horasessao");

                    b.Property<string>("Instituicao")
                        .HasColumnType("text")
                        .HasColumnName("instituicao");

                    b.Property<string>("Municipio")
                        .HasColumnType("text")
                        .HasColumnName("municipio");

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<string>("Professor")
                        .HasColumnType("text")
                        .HasColumnName("professor");

                    b.Property<int>("Serie")
                        .HasColumnType("integer")
                        .HasColumnName("serie");

                    b.Property<string>("SessaoEscolhida")
                        .HasColumnType("text")
                        .HasColumnName("sessaoescolhida");

                    b.Property<string>("Telefone")
                        .HasColumnType("text")
                        .HasColumnName("telefone");

                    b.Property<string>("TelefoneEscola")
                        .HasColumnType("text")
                        .HasColumnName("telefoneescola");

                    b.Property<string>("TelefoneProfessor")
                        .HasColumnType("text")
                        .HasColumnName("telefoneprofessor");

                    b.Property<string>("TipoEscola")
                        .HasColumnType("text")
                        .HasColumnName("tipoescola");

                    b.HasKey("Id");

                    b.ToTable("agendamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
