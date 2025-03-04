using Desafio_PicPay_Back_end.Models;
using Desafio_PicPay_Back_end.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_PicPay_Back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarteiraController : ControllerBase
    {
        private readonly ICarteiraRepositorio _carteiraRepositorio;
        public CarteiraController(ICarteiraRepositorio carteiraRepositorio)
        {
            _carteiraRepositorio = carteiraRepositorio;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CarteiraModel>>> GetCarteiraId(int id)
        {
            CarteiraModel carteira = await _carteiraRepositorio.GetCarteira(id);
            return Ok(carteira);
        }

        [HttpPost]
        public async Task<ActionResult<CarteiraModel>> CriarCarteira([FromBody] CarteiraModel carteiraModel)
        {
            CarteiraModel carteira = await _carteiraRepositorio.CriarCarteira(carteiraModel);
            return Ok(carteira);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CarteiraModel>> DeleteCarteira(int id)
        {
            bool apagado = await _carteiraRepositorio.deleteCarteira(id);
            return Ok(apagado);
        }

    }
}
