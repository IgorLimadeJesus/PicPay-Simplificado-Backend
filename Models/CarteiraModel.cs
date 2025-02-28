using Desafio_PicPay_Back_end.Models.Enum;

namespace Desafio_PicPay_Back_end.Models
{
    public class CarteiraModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPFCNPJ { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public decimal Saldo { get; set; }
        public UserType UserType { get; set; }

        public void DebitarSaldo(decimal valor)
        {
            Saldo -= valor;
        }

        public void CreditarSaldo(decimal valor)
        {
            Saldo += valor;
        }

    }
}
