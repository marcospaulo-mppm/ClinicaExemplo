using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ClinicaExemplo.Domain.Entities;
using ClinicaExemplo.MVC.ViewModels;

namespace ClinicaExemplo.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AgendamentoViewModel, Agendamento>();
            Mapper.CreateMap<PacienteViewModel, Paciente>();
            Mapper.CreateMap<EspecialidadeViewModel, Especialidade>();
            Mapper.CreateMap<ProfissionalViewModel, Profissional>();
        }
    }
}