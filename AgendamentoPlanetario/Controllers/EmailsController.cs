using AgendamentoPlanetario.Data;
using AgendamentoPlanetario.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamentoPlanetario.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmailsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{idAgendamento}")]
        public async Task<ActionResult<Email>> GetEmailByAgendamento(int idAgendamento)
        {
            var agendamento = await _context.Agendamentos.FindAsync(idAgendamento);

            if (agendamento == null)
            {
                return NotFound();
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Agendamento da escola: {agendamento.Instituicao}");
            stringBuilder.AppendLine($"Sessão escolhida: {agendamento.SessaoEscolhida}");
            stringBuilder.AppendLine($"Horário escolhido: {agendamento.DataHoraSessao}");
            stringBuilder.AppendLine($"Série/Ano: {agendamento.Serie}");
            stringBuilder.AppendLine($"Quantidade de alunos: {agendamento.Alunos}");
            stringBuilder.AppendLine($"Algumo aluno com deficiência? {agendamento.AlunoDeficiente}");
            stringBuilder.AppendLine($"Nome do professor responsável: {agendamento.Professor}");
            stringBuilder.AppendLine($"Telefone do professor responsável: {agendamento.TelefoneProfessor}");
            stringBuilder.AppendLine($"Email do professor responsável: {agendamento.EmailProfessor}");
            stringBuilder.AppendLine($"Tipo de escola: {agendamento.TipoEscola}");
            stringBuilder.AppendLine($"Telefone da escola: {agendamento.TelefoneEscola}");
            stringBuilder.AppendLine($"Município da escola: {agendamento.Municipio}");
            stringBuilder.AppendLine($"Nome de quem agendou: {agendamento.Nome}");
            stringBuilder.AppendLine($"Email de quem agendou: {agendamento.Email}");
            stringBuilder.AppendLine($"Telefone de quem agendou: {agendamento.Telefone}");

            Email email = new Email();
            email.Mensagem = stringBuilder.ToString();
            return email;
        }
    }
}
