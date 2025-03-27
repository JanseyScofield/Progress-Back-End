using Progress.Communication.Responses;
using Progress.Exception;
using Progress.Exception.ExceptionBase;
using Progress.Exception.Exceptions;
using Progress.Infrastructure;

namespace Progress.Aplication.UseCases.Produtos.Get
{
    public class GetProdutoByIdUseCase
    {
        public ResponseProdutoDetailsJson Execute(int id)
        {
            Validate(id);
            var dbContext = new ProgressDbContext();
            var produto = dbContext.Produtos.FirstOrDefault(p => p.ID == id);

            if (produto == null)
            {
                throw new ProdutoNotFoundException(ResourceErrorMessages.PRODUTO_NAO_ENCONTRADO);
            }

            return new ResponseProdutoDetailsJson { 
                ID = produto.ID,
                Nome = produto.Nome,
                Descricao = produto.Descricao
            };
        }

        private void Validate(int id)
        {
            if (id <= 0)
            {
                throw new ProdutosException(ResourceErrorMessages.CODIGO_PRODUTO_INVALIDO);
            }
        }
    }
}
