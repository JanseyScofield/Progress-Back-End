using Progress.Communication.Responses;
using Progress.Exception;
using Progress.Exception.ExceptionBase;
using Progress.Exception.Exceptions;
using Progress.Infrastructure;

namespace Progress.Aplication.UseCases.Clientes.Get
{
    public class GetClientesByCNPJUseCase
    {
        public ResponseClienteDetailsJson Execute(string cnpj)
        {
            Validate(cnpj);
            var dbContext = new ProgressDbContext();
            var cliente = dbContext.Clientes.FirstOrDefault(cliente => cliente.CNPJ == cnpj);

            if (cliente == null)
            {
                throw new ClienteNotFoundException(ResourceErrorMessages.CLIENTE_NAO_ENCONTRADO);
            }

            return new ResponseClienteDetailsJson
            {
                Id = cliente.Id,
                NomeFantasia = cliente.NomeFantasia,
                RazaoSocial = cliente.RazaoSocial,
                CNPJ = cliente.CNPJ,
                Telefone = cliente.Telefone,
                Endereco = cliente.Endereco,
                FlagAPrazo = cliente.FlagAPrazo,
                FlagAVista = cliente.FlagAVista,
                FlagNotaFiscal = cliente.FlagNotaFiscal,
                ProximaVisita = cliente.ProximaVisita
            };
        }

        private void Validate(string cnpj)
        {
            var utils = new Utils();
            if (!utils.ValidarCNPJ(cnpj))
            {
                throw new ClientesException(ResourceErrorMessages.CNPJ_INVALIDO);
            }
        }
    }
}
