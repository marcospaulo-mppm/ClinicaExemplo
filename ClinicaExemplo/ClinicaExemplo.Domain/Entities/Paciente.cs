using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaExemplo.Domain.Entities
{
    public class Paciente
    {
        public int PacienteId { get; set; }

        public string Nome { get; set; }

        public DateTime Nascimento { get; set; }

        public string CPF { get; set; } 

        public virtual IEnumerable<Agendamento> Agendamentos { get; set; }

    }
}
