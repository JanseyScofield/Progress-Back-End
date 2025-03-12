using Progress.Exception.ExceptionBase;

namespace Progress.Exception.Exceptions
{
    public class ClienteNotFoundException : ClientesException
    {
        public ClienteNotFoundException(string message) : base(message)
        {
        }
    }
}
