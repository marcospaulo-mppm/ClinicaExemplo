using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClinicaExemplo.Domain.Entities
{
    public class Especialidade
    {
        public int EspecialidadeId { get; set; }

        public string Nome { get; set; }

        //public virtual IEnumerable<Agendamento> Agendamentos { get; set; }
    }

}
