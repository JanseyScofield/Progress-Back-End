namespace Progress.Infrastructure.Entitites
{
    public class ClienteProduto
    {
        public int ID { get; set; }
        public int IdCliente { get; set; }
        public int IdProduto{ get; set; }
        public decimal Valor { get; set; }
    }
}
