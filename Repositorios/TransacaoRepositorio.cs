using Desafio_PicPay_Back_end.Data;
using Desafio_PicPay_Back_end.Models;
using Desafio_PicPay_Back_end.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio_PicPay_Back_end.Repositorios
{
    public class TransacaoRepositorio : ITransacaoRepositorio
    {
        private readonly PicPayDBContext _dbContext;

        public TransacaoRepositorio(PicPayDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TransacaoModel> CreateTransacao(TransacaoModel transacao)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var sender = await _dbContext.carteiras.FirstOrDefaultAsync(x => x.Id == transacao.SenderId);
                var reciver = await _dbContext.carteiras.FirstOrDefaultAsync(x => x.Id == transacao.ReciverId);

                if (sender == null || reciver == null)
                {
                    throw new Exception("Carteira não encontrada");
                }

                if (sender.Saldo < transacao.Valor)
                {
                    throw new Exception("Saldo Insuficiente");
                }

                sender.Saldo -= transacao.Valor;
                reciver.Saldo += transacao.Valor;

                var novaTransacao = new TransacaoModel
                {
                    SenderId = sender.Id,
                    ReciverId = reciver.Id,
                    Valor = transacao.Valor,
                };

                _dbContext.carteiras.Update(sender);
                _dbContext.carteiras.Update(reciver);

                await _dbContext.transacao.AddAsync(novaTransacao);
                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return novaTransacao;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception($"Erro ao processar a transação: {ex.Message}");
            }
        }

        public async Task<bool> DeleteTransacao(int id)
        {
            TransacaoModel transacao = await GetTransacaoId(id);

            if (transacao == null)
            {
                throw new Exception($"Usuario para o ID: {id} não encontrado");
            }

            _dbContext.transacao.Remove(transacao);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<TransacaoModel>> GetTrancacoes()
        {
           return await _dbContext.transacao.ToListAsync();
        }

        public async Task<TransacaoModel> GetTransacaoId(int id)
        {
            return await _dbContext.transacao.FirstOrDefaultAsync(x => x.Id == id);

        }
    }
}
