namespace Progress.Communication.Responses.ClientesProdutos
{
    public class ResponseClienteProdutoDetailsJson
    {
        public int Id { get; set; }
        public string CNPJCliente { get; set; }
        public string RazaoSocialCliente { get; set; }
        public string NomeFantasiaCliente { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal Valor{ get; set; }
    }
}
