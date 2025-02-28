namespace Desafio_PicPay_Back_end.Models
{
    public class TransferenciaModel
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public CarteiraModel Sender { get; set; }

        public int ReciverId { get; set; }
        public CarteiraModel Reciver { get; set; }
        public decimal Valor { get; set; }

        public DateTime dataTrancacao { get; set; }
    }
}
