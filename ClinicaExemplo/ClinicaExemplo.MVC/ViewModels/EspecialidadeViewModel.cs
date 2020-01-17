using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaExemplo.MVC.ViewModels
{
    public class RespostaEsp
    {
        public bool Success { get; set; }
        public List<EspecialidadeViewModel> Content { get; set; }
    }

    public class EspecialidadeViewModel
    {
        public int Especialidade_id { get; set; }

        public string Nome { get; set; }

        public virtual IEnumerable<AgendamentoViewModel> Agendamentos { get; set; }

    }
}