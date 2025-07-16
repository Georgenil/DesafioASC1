using DesafioASC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioASC.Persistence.Mapping
{
    public class ReservaMap : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("reserva");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder.Property(c => c.SalaId)
                .HasColumnName("salaId");

            builder.Property(c => c.QuantidadePessoa)
               .HasColumnName("quantidadePessoa")
               .IsRequired();

            builder.Property(c => c.DataHoraCriacao)
                .HasColumnName("dataHoraCriacao")
                .IsRequired();

            builder.Property(c => c.DataHoraFim)
                .HasColumnName("dataHoraFim")
                .IsRequired();

            builder.Property(c => c.DataHoraAtualizacao)
               .HasColumnName("dataHoraAtualizacao");

            builder.HasOne(r => r.Sala)
                 .WithMany(e => e.Reservas)
                 .HasForeignKey(e => e.SalaId)
                 .IsRequired();
        }
    }
}
