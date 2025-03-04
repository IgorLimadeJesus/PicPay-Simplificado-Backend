using Desafio_PicPay_Back_end.Models;
using Desafio_PicPay_Back_end.Repositorios;
using Desafio_PicPay_Back_end.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Desafio_PicPay_Back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {

        private readonly ITransacaoRepositorio _transacaoRepositorio;

        public TransacaoController(ITransacaoRepositorio transacaoRepositorio)
        {
            _transacaoRepositorio = transacaoRepositorio;
        }

        [HttpPost]
        public async Task<ActionResult<TransacaoModel>> CreateTransacao([FromBody] TransacaoModel transacaoModel)
        {
            TransacaoModel transacao = await _transacaoRepositorio.CreateTransacao(transacaoModel);
            return Ok(transacao);
        }

        [HttpGet]
        public async Task<ActionResult<List<TransacaoModel>>> GetTransacao()
        {
            List<TransacaoModel> transacaoModel = await _transacaoRepositorio.GetTrancacoes();
            return Ok(transacaoModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TransacaoModel>>> GetTransacaoId(int id)
        {
            TransacaoModel transacao = await _transacaoRepositorio.GetTransacaoId(id);
            return Ok(transacao);
        }

        // DELETE api/<TransacaoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransacaoModel>> Delete(int id)
        {
            bool apagado = await _transacaoRepositorio.DeleteTransacao(id);
            return Ok(apagado);
        }
    }
}
