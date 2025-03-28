using Progress.Aplication.UseCases.Clientes.Get;
using Progress.Communication.Responses.Clientes;
using Progress.Exception;
using Progress.Exception.ExceptionBase;
using Progress.Infrastructure;
using Progress.Infrastructure.Entitites;

namespace Progress.Aplication.UseCases.Clientes.Delete
{
    public class DeleteClienteUseCase
    {
        public ResponseClienteDetailsJson Execute(string cnpj)
        {
            var getByCNPJUseCase = new GetClientesByCNPJUseCase();
            try
            {
                var response = getByCNPJUseCase.Execute(cnpj);
                var dbContext = new ProgressDbContext();

                var cliente = new Cliente {
                    Id = response.Id,
                    CNPJ = response.CNPJ,
                    Endereco = response.Endereco,
                    NomeFantasia = response.NomeFantasia,
                    RazaoSocial = response.RazaoSocial,
                    FlagAPrazo = response.FlagAPrazo,
                    FlagAVista = response.FlagAVista,
                    FlagNotaFiscal = response.FlagNotaFiscal,
                    ProximaVisita = response.ProximaVisita,
                    Telefone = response.Telefone
                };

                dbContext.Clientes.Remove(cliente);
                dbContext.SaveChanges();
                return response;

            }
            catch (ClientesException ex)
            {
                throw;
            }

        }

    }
}
