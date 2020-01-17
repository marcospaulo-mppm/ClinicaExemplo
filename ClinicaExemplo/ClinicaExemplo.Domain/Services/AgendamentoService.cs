using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaExemplo.Domain.Entities;
using ClinicaExemplo.Domain.Interfaces;
using ClinicaExemplo.Domain.Interfaces.Services;

namespace ClinicaExemplo.Domain.Services
{
    public class AgendamentoService : ServiceBase<Agendamento>, IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository)
            : base(agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }
    }
}
