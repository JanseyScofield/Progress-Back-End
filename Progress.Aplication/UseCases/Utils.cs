using Progress.Exception.ExceptionBase;
using Progress.Exception;

namespace Progress.Aplication.UseCases
{
    public class Utils
    {
        public bool ValidarCNPJ(string CNPJ)
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
            int[] arrayMult = { 6, 5, 4, 3, 2, 9, 8, 7 };
            int soma = 0, restoDiv;
            int iCont, jCont;
            int primeiroDigito, segundoDigito;

            jCont = 1;
            for (iCont = 0; iCont < (CNPJ.Length - 2); iCont++)
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
        public void ValidarCodigoProduto(int id)
        {
            if (id <= 0)
            {
                throw new ProdutosException(ResourceErrorMessages.CODIGO_PRODUTO_INVALIDO);
            }

        }
    }
}
