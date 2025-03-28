using Progress.Aplication.UseCases.Clientes.Get;
using Progress.Aplication.UseCases.Produtos.Get;
using Progress.Communication.Responses.ClientesProdutos;
using Progress.Infrastructure;

namespace Progress.Aplication.UseCases.ClientesProdutos.Get
{
    public class GetAllProdutosByClienteCNPJ
    {
        public ResponseProdutosValoresJson Execute(string cnpj)
        {
            try {
                var getCliente = new GetClientesByCNPJUseCase();
                var cliente = getCliente.Execute(cnpj);

                var dbContext = new ProgressDbContext();
                var produtosCliente = dbContext.ClienteProduto.Where(cp => cp.IdCliente == cliente.Id).ToList();

                var response = new ResponseProdutosValoresJson();
                var getProduto = new GetProdutoByIdUseCase();

                foreach (var cp in produtosCliente)
                {
                    var produto = getProduto.Execute(cp.IdProduto);

                    var itemLista = new ResponseProdutoValorJson
                    {
                        NomeProduto = produto.Nome,
                        Descricao = produto.Descricao,
                        Valor = cp.Valor
                    };

                    response.ListaProdutos.Add(itemLista);
                }

                return response;
            }
            catch (ArgumentException) {
                throw;
            }
        } 
    }
}
