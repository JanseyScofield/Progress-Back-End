using Progress.Communication.Requests;
using Progress.Infrastructure;
using Progress.Infrastructure.Entitites;
using Progress.Exception;
using Progress.Exception.ExceptionBase;

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
                Endereco = request.Endereco,
                RazaoSocial = request.RazaoSocial,
                NomeFantasia = request.NomeFantasia,
                Telefone = request.Telefone,
                FlagNotaFiscal = request.FlagNotaFiscal,
                FlagAPrazo = request.FlagAPrazo
            };

            dbContext.Clientes.Add(entity);
            dbContext.SaveChanges();
        }

        private void Validate(RequestRegisterClienteJson request)
        {
            if (!ValidarCNPJ(request.CNPJ))
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
                throw new ClientesException(ResourceErrorMessages.ENDERECO_INVALIDO);
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

        private bool ValidarCNPJ(string CNPJ)
        {
            if (CNPJ.Length != 14)
            {
                return false;
            }
            if (CNPJ.All(d => d == CNPJ[0]))
            {
                return false;
            }

            const int constanteCalculo = 11; 
            int[] arrayMult = {6, 5, 4, 3, 2, 9, 8, 7}; 
            int soma = 0, restoDiv;
            int iCont, jCont;
            int primeiroDigito, segundoDigito;

            jCont = 1;
            for(iCont = 0; iCont < (CNPJ.Length - 2); iCont++)
            {
                soma += (CNPJ[iCont] - '0') * arrayMult[jCont];
                jCont++;

                if (jCont >= arrayMult.Length)
                {
                    jCont = 0;
                }
            }

            restoDiv = soma % constanteCalculo;
            primeiroDigito = restoDiv < 2 ? 0 : constanteCalculo - restoDiv;

            if (primeiroDigito != (CNPJ[12] - '0'))
            {
                return false;
            }

            soma = jCont = 0;

            for (iCont = 0; iCont < (CNPJ.Length - 1); iCont++)
            {
                soma += (CNPJ[iCont] - '0') * arrayMult[jCont];
                jCont++;

                if (jCont >= arrayMult.Length)
                {
                    jCont = 0;
                }
            }

            restoDiv = soma % constanteCalculo;
            segundoDigito = restoDiv < 2 ? 0 : constanteCalculo - restoDiv;

            return segundoDigito == (CNPJ[13] - '0');
        }
    }
}
