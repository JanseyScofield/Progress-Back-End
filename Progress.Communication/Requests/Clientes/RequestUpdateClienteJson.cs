﻿namespace Progress.Communication.Requests.Clientes
{
    public class RequestUpdateClienteJson
    {
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public int FlagNotaFiscal { get; set; }
        public int FlagAVista { get; set; }
        public int FlagAPrazo { get; set; }
        public DateTime ProximaVisita { get; set; }
        
    }
}
