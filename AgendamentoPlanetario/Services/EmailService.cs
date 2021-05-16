using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AgendamentoPlanetario.Models;

namespace AgendamentoPlanetario.Services
{
    public static class EmailService
    {
        public static async Task SendEmail(Agendamento agendamento)
        {
            var email = Environment.GetEnvironmentVariable("Email");
            var senha = Environment.GetEnvironmentVariable("Senha");

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Agendamento da escola: <b>{agendamento.Instituicao}</b><br/>");
            stringBuilder.AppendLine($"Sessão escolhida: <b>{agendamento.SessaoEscolhida}</b><br/>");
            stringBuilder.AppendLine($"Horário escolhido: <b>{agendamento.DataHoraSessao}</b><br/>");
            stringBuilder.AppendLine($"Série/Ano: <b>{agendamento.Serie}</b><br/>");
            stringBuilder.AppendLine($"Quantidade de alunos: <b>{agendamento.Alunos}</b><br/>");
            stringBuilder.AppendLine($"Algumo aluno com deficiência? <b>{agendamento.AlunoDeficiente}</b><br/>");
            stringBuilder.AppendLine($"Nome do professor responsável: <b>{agendamento.Professor}</b><br/>");
            stringBuilder.AppendLine($"Telefone do professor responsável: <b>{agendamento.TelefoneProfessor}</b><br/>");
            stringBuilder.AppendLine($"Email do professor responsável: <b>{agendamento.EmailProfessor}</b><br/>");
            stringBuilder.AppendLine($"Tipo de escola: <b>{agendamento.TipoEscola}</b><br/>");
            stringBuilder.AppendLine($"Telefone da escola: <b>{agendamento.TelefoneEscola}</b><br/>");
            stringBuilder.AppendLine($"Município da escola: <b>{agendamento.Municipio}</b><br/>");
            stringBuilder.AppendLine($"Nome de quem agendou: <b>{agendamento.Nome}</b><br/>");
            stringBuilder.AppendLine($"Email de quem agendou: <b>{agendamento.Email}</b><br/>");
            stringBuilder.AppendLine($"Telefone de quem agendou: <b>{agendamento.Telefone}</b><br/>");

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
                Body = stringBuilder.ToString(),
                IsBodyHtml= true
            };

            await smtp.SendMailAsync(emailPlanetario);

            stringBuilder.Clear();
            stringBuilder.AppendLine("Olá!<br/>");
            stringBuilder.AppendLine("Recebemos seu agendamento de sessão virtual." +
                " Encaminharemos a você o link para acesso à sessão, através deste e-mail, quando o dia escolhido estiver próximo.<br/>");
            stringBuilder.AppendLine("<br/>");
            stringBuilder.AppendLine("Confira alguns dados de seu agendamento:<br/>");
            stringBuilder.AppendLine($"<i>Você escolheu a sessão <b>{agendamento.SessaoEscolhida}</b>.</i><br/>");
            stringBuilder.AppendLine($"<i>A data e horário escolhido foram <b>{agendamento.DataHoraSessao}</b>.</i><br/>");
            stringBuilder.AppendLine("<br/>");
            stringBuilder.AppendLine("Enquanto o dia da sessão não chega, você pode acompanhar nosso trabalho clicando nos links das redes sociais abaixo:<br/>");
            stringBuilder.AppendLine($"<a style={"font-size:15px"} href={"https://www.instagram.com/planetarioufsm/"}>Instagram</a><br/>" +
                $"<a style={"font-size:15px"} href={"https://www.facebook.com/planetarioufsm1/"}>Facebook</a><br/>" +
                $"<a style={"font-size:15px"} href={"https://www.youtube.com/channel/UC91vcCsL5Ja_WtQfcDC997A"}>Youtube</a>");

            using var emailEscola = new MailMessage(email, agendamento.Email)
            {
                Subject = $"Seu agendamento foi realizado com sucesso!",
                Body = stringBuilder.ToString(),
                IsBodyHtml = true
            };

            await smtp.SendMailAsync(emailEscola);

        }
    }
}