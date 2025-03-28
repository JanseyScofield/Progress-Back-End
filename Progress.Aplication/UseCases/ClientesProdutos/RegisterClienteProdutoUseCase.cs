using Progress.Aplication.UseCases.Clientes.Get;
using Progress.Aplication.UseCases.Produtos.Get;
using Progress.Communication.Requests.ClientesProdutos;
using Progress.Communication.Responses.ClientesProdutos;
using Progress.Infrastructure;
using Progress.Infrastructure.Entitites;
using Progress.Exception;
using Progress.Exception.ExceptionBase;

namespace Progress.Aplication.UseCases.ClientesProdutos
{
    public class RegisterClienteProdutoUseCase
    {
        public ResponseClienteProdutoDetailsJson Execute(RequestRegisterClienteProdutoJson request)
        {
            try
            {
                var getCliente = new GetClientesByIdUseCase();
                var cliente = getCliente.Execute(request.IdCliente);

                var getProduto = new GetProdutoByIdUseCase();
                var produto = getProduto.Execute(request.IdProduto);

                if (request.Valor <= 0) {
                    throw new ClienteProdutoException(ResourceErrorMessages.VALOR_PRODUTO_INVALIDO);
                }

                var dbContext = new ProgressDbContext();
                var entity = new ClienteProduto {
                    IdCliente = cliente.Id,
                    IdProduto = produto.ID,
                    Valor = request.Valor,
                };
                dbContext.ClienteProduto.Add(entity);
                dbContext.SaveChanges();

                return new ResponseClienteProdutoDetailsJson
                {
                    Id = entity.ID,
                    CNPJCliente = cliente.CNPJ,
                    NomeFantasiaCliente = cliente.NomeFantasia,
                    RazaoSocialCliente = cliente.RazaoSocial,
                    NomeProduto = produto.Nome,
                    DescricaoProduto = produto.Descricao,
                    Valor = request.Valor
                };
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}
