using Microsoft.AspNetCore.Mvc;
using Progress.Aplication.UseCases.Produtos.Register;
using Progress.Communication.Requests;
using Progress.Communication.Responses;
using Progress.Exception.ExceptionBase;

namespace Progress_Back_End.Controllers
{
    [Route("progress/produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseProdutoDetailJson),  StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string),  StatusCodes.Status400BadRequest)]
        public IActionResult AdicionarProdutos([FromBody] RequestRegisterProdutoJson request)
        {
            try
            {
                var useCase = new RegisterProdutoUseCase();
                var response = useCase.Execute(request);
                return Created(string.Empty, response);
            }
            catch (ProdutosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
