using Progress.Aplication.UseCases.Clientes.Get;
using Progress.Aplication.UseCases.Produtos.Get;
using Progress.Communication.Responses.ClientesProdutos;
using Progress.Infrastructure;

namespace Progress.Aplication.UseCases.ClientesProdutos.Get
{
    public class GetAllClientesProdutosUseCase
    {
        public ResponseClientesProdutosJson Execute() {

            try
            {
                var getCliente = new GetClientesByIdUseCase();
                var getProduto = new GetProdutoByIdUseCase();

                var dbContext = new ProgressDbContext();
                var clientesProdutos = dbContext.ClienteProduto.ToList();

                var response = new ResponseClientesProdutosJson();

                foreach (var clienteProduto in clientesProdutos) {
                    var cliente = getCliente.Execute(clienteProduto.IdCliente);
                    var produto = getProduto.Execute(clienteProduto.IdProduto);

                    var itemLista = new ResponseShortClienteProdutoJson {
                        Id = clienteProduto.ID,
                        NomeFantasia = cliente.NomeFantasia,
                        NomeProduto = produto.Nome,
                        Descricao = produto.Descricao,
                        Valor = clienteProduto.Valor
                    };

                    response.ListaClientesProdutos.Add(itemLista);  
                }

                return response;
            }
            catch (ArgumentException) {
                throw;
            }

        }
    }
}
