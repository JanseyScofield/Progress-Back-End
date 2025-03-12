using Progress.Communication.Requests;
using Progress.Communication.Responses;
using Progress.Infrastructure;
using Progress.Infrastructure.Entitites;
using Progress.Exception;
using Progress.Exception.ExceptionBase;

namespace Progress.Aplication.UseCases.Clientes.Register
{
    public class RegisterClientesUseCase
    {
        public ResponseShortClientesJson Execute(RequestRegisterClienteJson request)
        {
            Validate(request);
            var dbContext = new ProgressDbContext();
            var entity = new Cliente
            {
                CNPJ = request.CNPJ,
                Endereco = request.Endereco,
                RazaoSocial = request.RazaoSocial,
                NomeFantasia = request.NomeFantasia,
                Telefone = request.Telefone,
                FlagNotaFiscal = request.FlagNotaFiscal,
                FlagAPrazo = request.FlagAPrazo
            };

            dbContext.Clientes.Add(entity);
            dbContext.SaveChanges();

            return new ResponseShortClientesJson
            {
                CNPJ = entity.CNPJ,
                Endereco = entity.Endereco,
                RazaoSocial =  entity.RazaoSocial,
                NomeFantasia = entity.NomeFantasia,
                Telefone = entity.Telefone,
                ProximaVisita = entity.ProximaVisita.Date
            };
        }

        private void Validate(RequestRegisterClienteJson request)
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
        }

    }
}
