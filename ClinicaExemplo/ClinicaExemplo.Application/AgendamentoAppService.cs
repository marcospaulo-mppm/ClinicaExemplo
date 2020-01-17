using System.Collections.Generic;
using ClinicaExemplo.Application.Interface;
using ClinicaExemplo.Domain.Entities;
using ClinicaExemplo.Domain.Interfaces.Services;
using ClinicaExemplo.Domain.Services;

namespace ClinicaExemplo.Application
{
    public class AgendamentoAppService : AppServiceBase<Agendamento>, IAgendamentoAppService
    {
        private readonly AgendamentoService _agendamentoService;

        public AgendamentoAppService(AgendamentoService agendamentoService)
            : base(agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        public IEnumerable<Agendamento> ObterAgendamentoPaciente()
        {
            throw new System.NotImplementedException();
        }
    } 
}
