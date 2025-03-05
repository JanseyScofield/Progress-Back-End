using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Communication.Requests
{
    public class RequestRegisterClienteJson
    {
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public int FlagNotaFiscal { get; set; }
        public int FlagAVista { get; set; }
        public int FlagAPrazo { get; set; }
    }
}
