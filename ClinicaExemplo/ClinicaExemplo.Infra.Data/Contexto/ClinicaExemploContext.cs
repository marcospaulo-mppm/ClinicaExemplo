using System.Data.Entity;
using ClinicaExemplo.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using ClinicaExemplo.Infra.Data.EntityConfig;


namespace ClinicaExemplo.Infra.Data.Contexto
{
    public class ClinicaExemploContexto : DbContext

    {
        public ClinicaExemploContexto()
            : base("ClinicaExemploConnection")
        {

        }

        public DbSet<Especialidade> Especialidades { get; set; }

        public DbSet<Agendamento> Agendamentos { get; set; }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Profissional> Profissionais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(250));

            modelBuilder.Configurations.Add(new AgendamentoConfigurations());

        }
    }
}
