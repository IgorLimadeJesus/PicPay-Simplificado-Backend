using Desafio_PicPay_Back_end.Data.Maps;
using Desafio_PicPay_Back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_PicPay_Back_end.Data
{
    public class PicPayDBContext : DbContext
    {
        public PicPayDBContext(DbContextOptions<PicPayDBContext> options) : base(options)
        {

        }

        public DbSet<CarteiraModel> carteiras { get; set; }
        public DbSet<TransacaoModel> transacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarteiraMap());
            modelBuilder.ApplyConfiguration(new TransacaoMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
