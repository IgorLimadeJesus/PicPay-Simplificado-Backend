using Desafio_PicPay_Back_end.Data;
using Desafio_PicPay_Back_end.Models;
using Desafio_PicPay_Back_end.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio_PicPay_Back_end.Repositorios
{
    public class CarteiraRepositorio : ICarteiraRepositorio
    {

        private readonly PicPayDBContext _dbContext;

        public CarteiraRepositorio(PicPayDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarteiraModel> CriarCarteira(CarteiraModel carteiraModel)
        {
            await _dbContext.carteiras.AddAsync(carteiraModel);
            await _dbContext.SaveChangesAsync();

            return carteiraModel;
        }

        public async Task<CarteiraModel> GetCarteira(int Id)
        {
            return await _dbContext.carteiras.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<bool> deleteCarteira(int Id)
        {
            CarteiraModel carteiraModel = await GetCarteira(Id);

            if (carteiraModel == null)
            {
                throw new Exception($"Carteira não encontrada para o id: {Id} no Banco de dados.");
            }

            _dbContext.carteiras.Remove(carteiraModel);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
