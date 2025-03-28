namespace Progress.Communication.Requests.ClientesProdutos
{
    public class RequestRegisterClienteProdutoJson
    {
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public decimal Valor { get; set; }
    }
}
