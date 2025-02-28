using Desafio_PicPay_Back_end.Models;

namespace Desafio_PicPay_Back_end.Repositorios.Interfaces
{
    public interface ICarteiraRepositorio
    {
        Task<CarteiraModel> GetCarteira(int Id);
        Task<CarteiraModel> CriarCarteira(CarteiraModel carteiraModel);
        Task<bool> deleteCarteira(int Id);
    }
}
