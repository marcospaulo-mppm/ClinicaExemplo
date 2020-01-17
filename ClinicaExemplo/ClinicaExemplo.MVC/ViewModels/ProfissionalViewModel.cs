using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaExemplo.MVC.ViewModels
{
    public class RespostaProf
    {
        public bool Success { get; set; }
        public List<ProfissionalViewModel> Content { get; set; }
    }

    public class ProfissionalViewModel
    {
        public int Profissional_id { get; set; }

        public string Nome { get; set; }

        public int CRM { get; set; }

        public int Ativo { get; set; }

        public int Unidade_id { get; set; }

        public int Especialidade_id { get; set; }

        public string foto { get; set; }

        public string sexo { get; set; }

        public string documento_conselho { get; set; }

        public virtual IEnumerable<AgendamentoViewModel> Agendamentos { get; set; }

        //public List<EspecialidadeViewModel> especialidades { get; set; }
    }
}