using Desafio_PicPay_Back_end.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_PicPay_Back_end.Data.Maps
{
    public class CarteiraMap : IEntityTypeConfiguration<CarteiraModel>
    {
        public void Configure(EntityTypeBuilder<CarteiraModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.CPFCNPJ).IsRequired().HasMaxLength(20);
            builder.HasIndex(x => x.CPFCNPJ).IsUnique();
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(20);
            builder.Property(x => x.UserType).IsRequired();
        }
    }
}
