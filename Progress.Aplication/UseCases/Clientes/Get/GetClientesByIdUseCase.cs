using Progress.Exception.Exceptions;
using Progress.Exception;
using Progress.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progress.Communication.Responses.Clientes;

namespace Progress.Aplication.UseCases.Clientes.Get
{
    public class GetClientesByIdUseCase
    {
        public ResponseClienteDetailsJson Execute(int id)
        {
            var dbContext = new ProgressDbContext();
            var cliente = dbContext.Clientes.FirstOrDefault(cliente => cliente.Id == id);

            if (cliente == null)
            {
                throw new ClienteNotFoundException(ResourceErrorMessages.CLIENTE_NAO_ENCONTRADO);
            }

            return new ResponseClienteDetailsJson
            {
                Id = cliente.Id,
                CNPJ = cliente.CNPJ,
                NomeFantasia = cliente.NomeFantasia,
                RazaoSocial = cliente.RazaoSocial,
                Endereco = cliente.Endereco,
                FlagAPrazo = cliente.FlagAPrazo,
                FlagAVista = cliente.FlagAVista,
                FlagNotaFiscal = cliente.FlagNotaFiscal,
                Telefone = cliente.Telefone,
                ProximaVisita = cliente.ProximaVisita
            };
        }

    }
}
