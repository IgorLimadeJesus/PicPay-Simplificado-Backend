using Desafio_PicPay_Back_end.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_PicPay_Back_end.Data.Maps
{
    public class TransacaoMap : IEntityTypeConfiguration<TransacaoModel>
    {
        public void Configure(EntityTypeBuilder<TransacaoModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SenderId)
                   .IsRequired();

            builder.Property(x => x.ReciverId)
                   .IsRequired();

            builder.Property(x => x.Valor)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(x => x.dataTrancacao)
                   .HasColumnName("DataTransacao")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Relacionamento com CarteiraModel (Sender)
            builder.HasOne(t => t.Sender)
                   .WithMany()
                   .HasForeignKey(t => t.SenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento com CarteiraModel (Reciver)
            builder.HasOne(t => t.Reciver)
                   .WithMany()
                   .HasForeignKey(t => t.ReciverId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
