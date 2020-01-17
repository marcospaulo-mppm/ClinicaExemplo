
using System.Collections.Generic;
using ClinicaExemplo.Domain.Entities;

namespace ClinicaExemplo.Application.Interface
{
    public interface IAgendamentoAppService : IAppServiceBase<Agendamento>
    {
        IEnumerable<Agendamento> ObterAgendamentoPaciente();
    }
}
