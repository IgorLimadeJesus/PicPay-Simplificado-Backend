using Desafio_PicPay_Back_end.Models;

namespace Desafio_PicPay_Back_end.Repositorios.Interfaces
{



    public interface ITransacaoRepositorio
    {
        Task<List<TransacaoModel>> GetTrancacoes();
        Task<TransacaoModel> GetTransacaoId(int id);
        Task<TransacaoModel> CreateTransacao(TransacaoModel transacao);
        Task<bool> DeleteTransacao(int id);
    }
}
