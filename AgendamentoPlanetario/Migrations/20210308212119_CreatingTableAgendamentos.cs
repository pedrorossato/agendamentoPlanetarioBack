using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgendamentoPlanetario.Migrations
{
    public partial class CreatingTableAgendamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agendamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    telefone = table.Column<string>(type: "text", nullable: false),
                    sessaoescolhida = table.Column<string>(type: "text", nullable: false),
                    datasessao = table.Column<string>(type: "text", nullable: false),
                    horasessao = table.Column<string>(type: "text", nullable: false),
                    instituicao = table.Column<string>(type: "text", nullable: false),
                    municipio = table.Column<string>(type: "text", nullable: false),
                    serie = table.Column<int>(type: "integer", nullable: false),
                    alunos = table.Column<int>(type: "integer", nullable: false),
                    professor = table.Column<string>(type: "text", nullable: false),
                    emailprofessor = table.Column<string>(type: "text", nullable: false),
                    telefoneprofessor = table.Column<string>(type: "text", nullable: false),
                    tipoescola = table.Column<string>(type: "text", nullable: false),
                    telefoneescola = table.Column<string>(type: "text", nullable: false),
                    alunodeficiente = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agendamentos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agendamentos");
        }
    }
}
