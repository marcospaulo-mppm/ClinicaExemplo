using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClinicaExemplo.Domain.Entities
{
    public class Profissional
    {
        public int ProfissionalId { get; set; }

        public string Nome { get; set; }

        public int CRM { get; set; }

        public int Ativo { get; set; }

        public int UnidadeId { get; set; }

        public int EspecialidadeId { get; set; }

        //public virtual IEnumerable<Agendamento> Agendamentos { get; set; }

    }
}
