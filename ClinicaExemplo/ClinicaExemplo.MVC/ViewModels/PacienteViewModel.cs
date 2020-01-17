using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ClinicaExemplo.MVC.ViewModels
{
    public class PacienteViewModel
    {
        public int Paciente_id { get; set; }

        public string Nome { get; set; }

        public DateTime Nascimento { get; set; }

        public string CPF { get; set; }

        public virtual IEnumerable<AgendamentoViewModel> Agendamentos { get; set; }
    }
}