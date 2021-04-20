using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AgendamentoPlanetario.Models;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using FluentEmail.Mailgun;
using FluentEmail.SendGrid;
using FluentEmail.Smtp;

namespace AgendamentoPlanetario.Services
{
    public static class EmailService
    {
        public static async Task SendEmail(Agendamento agendamento)
        {
            var email = Environment.GetEnvironmentVariable("Email");
            var senha = Environment.GetEnvironmentVariable("Senha");
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

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(email, senha)
            };

            using var emailPlanetario = new MailMessage(email, email)
            {
                Subject = $"Novo agendamento para a escola {agendamento.Instituicao}!",
                Body = stringBuilder.ToString()
            };

            await smtp.SendMailAsync(emailPlanetario);

            stringBuilder.Clear();
            stringBuilder.AppendLine($"Seu agendamento foi realizado com sucesso!");
            stringBuilder.AppendLine($"Você escolheu a sessão {agendamento.SessaoEscolhida}.");
            stringBuilder.AppendLine($"O horário escolhido foi {agendamento.DataHoraSessao}.");
            stringBuilder.AppendLine($"O link para o encontro virtual irá ser enviado em breve...");

            using var emailEscola = new MailMessage(email, agendamento.Email)
            {
                Subject = $"Agendamento de sessão virtual realizado com sucesso!",
                Body = stringBuilder.ToString()
            };

            await smtp.SendMailAsync(emailEscola);

        }
    }
}