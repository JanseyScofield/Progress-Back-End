using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Progress.Aplication.UseCases.ClientesProdutos;
using Progress.Communication.Requests.ClientesProdutos;
using Progress.Communication.Responses.ClientesProdutos;
using Progress.Exception.ExceptionBase;
using Progress.Exception.Exceptions;

namespace Progress_Back_End.Controllers
{
    [Route("progress/cliente-produto")]
    [ApiController]
    public class ClienteProdutoController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseClienteProdutoDetailsJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult RegistrarClienteProduto([FromBody] RequestRegisterClienteProdutoJson request) 
        {
            try
            {
                var useCase = new RegisterClienteProdutoUseCase();
                var response = useCase.Execute(request);
                return Ok(response);
            }
            catch (ClienteNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ProdutoNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
