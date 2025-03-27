using Progress.Exception.ExceptionBase;

namespace Progress.Exception.Exceptions
{
    public class ProdutoNotFoundException : ProdutosException
    {
        public ProdutoNotFoundException(string message) : base(message)
        {
        }
    }
}
