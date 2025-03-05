using Progress.Communication.Requests;
using Progress.Infrastructure;
using Progress.Infrastructure.Entitites;

namespace Progress.Aplication.UseCases.Clientes.Register
{
    public class RegisterClientesUseCase
    {
        public void Execute(RequestRegisterClienteJson request)
        {
            Validate(request);
            var dbContext = new ProgressDbContext();
            var entity = new Cliente
            {
                CNPJ = request.CNPJ,
                CEP = request.CEP,
                RazaoSocial = request.RazaoSocial,
                NomeFantasia = request.NomeFantasia,
                Telefone = request.Telefone,
                FlagNotaFiscal = request.FlagNotaFiscal,
                FlagAPrazo = request.FlagAPrazo,
                FlagAVista = request.FlagAVista,
                ProximaVisita = request.ProximaVisita
            };

            dbContext.Clientes.Add(entity);
            dbContext.SaveChanges();
        }

        public void Validate(RequestRegisterClienteJson request)
        {
            //
        }
    }
}
