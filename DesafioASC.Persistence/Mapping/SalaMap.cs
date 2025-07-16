using DesafioASC.Domain.Entities;
using DesafioASC.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioASC.Persistence.Mapping
{
    public class SalaMap : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable("sala");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder.Property(s => s.Nome)
                .HasColumnName("nome")
                .HasMaxLength(ModelMaxLengthConstants.Nome)
                .IsRequired();

            builder.Property(s => s.CapacidadeMaxima)
                .HasColumnName("capacidadeMaxima")
                .IsRequired();

            builder.Property(c => c.DataHoraCriacao)
                .HasColumnName("dataHoraCriacao")
                .IsRequired();

            builder.Property(c => c.DataHoraAtualizacao)
               .HasColumnName("dataHoraAtualizacao");

            builder.HasMany(s => s.Reservas)
            .WithOne(r => r.Sala)
            .HasForeignKey(r => r.SalaId);
        }
    }
}