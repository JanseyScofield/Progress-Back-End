using Progress.Communication.Requests;
using Progress.Communication.Responses;
using Progress.Exception;
using Progress.Exception.ExceptionBase;
using Progress.Exception.Exceptions;
using Progress.Infrastructure;

namespace Progress.Aplication.UseCases.Clientes.Update
{
    public class UpdateClienteUseCase
    {
        public ResponseClienteDetailsJson Execute(int id, RequestUpdateClienteJson request)
        {
            Validate(request);
        
            var dbContext = new ProgressDbContext();
            var cliente = dbContext.Clientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                throw new ClienteNotFoundException(ResourceErrorMessages.CLIENTE_NAO_ENCONTRADO);
            }
                
            cliente.CNPJ = request.CNPJ;
            cliente.RazaoSocial = request.RazaoSocial;
            cliente.NomeFantasia = request.NomeFantasia;
            cliente.Telefone = request.Telefone;
            cliente.Endereco = request.Endereco;
            cliente.FlagAPrazo = request.FlagAPrazo;
            cliente.FlagAVista = request.FlagAVista;
            cliente.FlagNotaFiscal = request.FlagNotaFiscal;
            cliente.ProximaVisita = request.ProximaVisita;

            dbContext.SaveChanges();

            return new ResponseClienteDetailsJson { 
                Id = cliente.Id,
                CNPJ = cliente.CNPJ,
                NomeFantasia = cliente.NomeFantasia,
                RazaoSocial = cliente.RazaoSocial,
                Endereco = cliente.Endereco,
                Telefone = cliente.Telefone,
                FlagAPrazo = cliente.FlagAPrazo,
                FlagAVista = cliente.FlagAVista,
                FlagNotaFiscal = cliente.FlagNotaFiscal,
                ProximaVisita = cliente.ProximaVisita
            };

        }

        private void Validate(RequestUpdateClienteJson request)
        {
            var utils = new Utils();

            if (!utils.ValidarCNPJ(request.CNPJ))
            {
                throw new ClientesException(ResourceErrorMessages.CNPJ_INVALIDO);
            }

            if (string.IsNullOrWhiteSpace(request.Endereco))
            {
                throw new ClientesException(ResourceErrorMessages.ENDERECO_INVALIDO);
            }

            if (string.IsNullOrWhiteSpace(request.NomeFantasia))
            {
                throw new ClientesException(ResourceErrorMessages.NOME_FANTASIA_INVALIDO);
            }

            if (string.IsNullOrWhiteSpace(request.RazaoSocial))
            {
                throw new ClientesException(ResourceErrorMessages.RAZAO_SOCIAL_INVALIDA);
            }

            if (string.IsNullOrWhiteSpace(request.Telefone) || request.Telefone.Length != 8)
            {
                throw new ClientesException(ResourceErrorMessages.TELEFONE_INVALIDO);
            }

            if (request.FlagAVista > 1 || request.FlagAVista < 0)
            {
                throw new ClientesException(ResourceErrorMessages.FLAG_INVALIDA);
            }

            if (request.FlagAPrazo > 1 || request.FlagAPrazo < 0)
            {
                throw new ClientesException(ResourceErrorMessages.FLAG_INVALIDA);
            }

            if (request.FlagNotaFiscal > 1 || request.FlagNotaFiscal < 0)
            {
                throw new ClientesException(ResourceErrorMessages.FLAG_INVALIDA);
            }

            if (request.ProximaVisita < DateTime.Now)
            {
                throw new ClientesException(ResourceErrorMessages.DATA_PROXIMA_VISITA_INVALIDA);
            }
        }
    }
}
