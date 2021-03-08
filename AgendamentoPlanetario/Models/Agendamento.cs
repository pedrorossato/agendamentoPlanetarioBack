using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoPlanetario.Models
{
    [Table("agendamentos")]
    public class Agendamento
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("nome")]
        public string Nome { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
        
        [Column("telefone")]
        public string Telefone { get; set; }
        
        [Column("sessaoescolhida")]
        public string SessaoEscolhida { get; set; }
        
        [Column("datasessao")]
        public string DataSessao { get; set; }
        
        [Column("horasessao")]
        public string HoraSessao { get; set; }
        
        [Column("instituicao")]
        public string Instituicao { get; set; }
        
        [Column("municipio")]
        public string Municipio { get; set; }
        
        [Column("serie")]
        public int Serie { get; set; }
        
        [Column("alunos")]
        public int Alunos { get; set; }
        
        [Column("professor")]
        public string Professor { get; set; }
        
        [Column("emailprofessor")]
        public string EmailProfessor { get; set; }
        
        [Column("telefoneprofessor")]
        public string TelefoneProfessor { get; set; }
        
        [Column("tipoescola")]
        public string TipoEscola { get; set; }
        
        [Column("telefoneescola")]
        public string TelefoneEscola { get; set; }
        
        [Column("alunodeficiente")]
        public string AlunoDeficiente { get; set; }

    }
}
