using System.Data.Entity.ModelConfiguration;
using ClinicaExemplo.Domain.Entities;

namespace ClinicaExemplo.Infra.Data.EntityConfig
{
    public class AgendamentoConfigurations : EntityTypeConfiguration<Agendamento>
    {

        public AgendamentoConfigurations()
        {
            HasKey(a => a.AgendamentoId);

            Property(a => a.Nome).IsRequired().HasMaxLength(250);

            Property(a => a.EspecialidadeId).IsRequired();

            Property(a => a.ProfessionalId).IsRequired();

            Property(a => a.CPF).IsRequired().HasMaxLength(11);

            Property(a => a.SourceId).IsRequired();

            Property(a => a.Nascimento).IsRequired();

            Property(a => a.DataAgendamento).IsRequired();

            HasRequired(a => a.Paciente)
                .WithMany()
                .HasForeignKey(a => a.PacienteId);

            HasRequired(a => a.Especialidade)
                .WithMany()
                .HasForeignKey(a => a.EspecialidadeId);

            HasRequired(a => a.Profissional)
                .WithMany()
                .HasForeignKey(a => a.ProfessionalId);


        }

    }
}
