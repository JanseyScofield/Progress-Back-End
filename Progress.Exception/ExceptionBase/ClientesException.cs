using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Exception.ExceptionBase
{
    public class ClientesException : ArgumentException
    {
        public ClientesException(string message) : base(message)
        {

        }
    }
}
