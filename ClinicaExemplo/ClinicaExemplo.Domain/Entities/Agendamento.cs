using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClinicaExemplo.Domain.Entities
{
    public class Agendamento
    {
        public int AgendamentoId { get; set; }

        public int PacienteId { get; set; }

        public int EspecialidadeId { get; set; }

        public int ProfessionalId { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public int SourceId { get; set; }

        public DateTime Nascimento { get; set; }

        public DateTime DataAgendamento { get; set; }

        public virtual Paciente Paciente { get; set; }

        public virtual Especialidade Especialidade { get; set; }

        public virtual Profissional Profissional { get; set; }

        public bool PacienteCPF(Agendamento paciente)
        {
            return paciente.CPF != null;
        }
    }
}
