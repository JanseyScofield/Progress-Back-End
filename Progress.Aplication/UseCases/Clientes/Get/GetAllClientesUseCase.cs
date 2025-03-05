using Progress.Communication.Responses;
using Progress.Infrastructure;

namespace Progress.Aplication.UseCases.Clientes.Get
{
    public class GetAllClientesUseCase
    {
        public ResponseClientesJson Execute()
        {
            var dbContext = new ProgressDbContext();
            var listaClientes = dbContext.Clientes.ToList();
            return new ResponseClientesJson
            {
                Clientes = listaClientes.Select(cliente => new ResponseShortClientesJson
                {
                    CNPJ = cliente.CNPJ,
                    NomeFantasia = cliente.NomeFantasia,
                    Endereco = cliente.Endereco,
                    RazaoSocial = cliente.RazaoSocial,
                    Telefone = cliente.Telefone,
                    ProximaVisita = cliente.ProximaVisita.Date.Date
                }).ToList()
            }; 

        }
    }
}
