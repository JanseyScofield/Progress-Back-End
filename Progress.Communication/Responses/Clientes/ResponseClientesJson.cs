using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Communication.Responses.Clientes
{
    public class ResponseClientesJson
    {
        public IList<ResponseShortClientesJson> Clientes { get; set; } = [];
    }
}
