﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaExemplo.MVC.ViewModels
{
    public class AgendamentoViewModel
    {
        public int Agendamento_id { get; set; }

        public int Paciente_id { get; set; }

        public int Especialidade_id { get; set; }

        public int Professional_id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public int Source_id { get; set; }

        public DateTime Nascimento { get; set; }

        public DateTime DataAgendamento { get; set; }

        public virtual PacienteViewModel Paciente { get; set; }

        public virtual EspecialidadeViewModel Especialidade { get; set; }

        public virtual ProfissionalViewModel Profissional { get; set; }
    }
}