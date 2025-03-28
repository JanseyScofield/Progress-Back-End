using Progress.Communication.Responses.Produtos;
using Progress.Infrastructure;

namespace Progress.Aplication.UseCases.Produtos.Get
{
    public class GetAllProdutosUseCase
    {
        public ResponseProdutosDetailsJson Execute() {

            var dbContext = new ProgressDbContext();
            var listaProdutos = dbContext.Produtos.ToList();

            return new ResponseProdutosDetailsJson
            {
                ListaProdutos = listaProdutos.Select(produto => new ResponseProdutoDetailsJson
                {
                    ID = produto.ID,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao
                }).ToList()
            };
        }
    }
}
