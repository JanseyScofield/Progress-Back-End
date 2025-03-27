using Progress.Aplication.UseCases.Produtos.Get;
using Progress.Communication.Responses;
using Progress.Exception.ExceptionBase;
using Progress.Infrastructure;
using Progress.Infrastructure.Entitites;

namespace Progress.Aplication.UseCases.Produtos.Delete
{
    public class DeleteProdutoUseCase
    {
        public ResponseProdutoDetailsJson Execute(int id) 
        {
            var getProduto = new GetProdutoByIdUseCase();
            try
            {
                var response = getProduto.Execute(id);

                var dbContext = new ProgressDbContext();
                var produto = new Produto { 
                    ID = response.ID,
                    Nome = response.Nome,
                    Descricao = response.Descricao
                };

                dbContext.Produtos.Remove(produto);
                dbContext.SaveChanges();
                return response;
            }
            catch (ProdutosException ex) 
            {
                throw;
            }
            
           
        }
    }
}
