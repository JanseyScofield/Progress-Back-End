using Microsoft.AspNetCore.Mvc;
using Progress.Aplication.UseCases.Clientes.Delete;
using Progress.Aplication.UseCases.Clientes.Get;
using Progress.Aplication.UseCases.Clientes.Register;
using Progress.Communication.Requests;
using Progress.Communication.Responses;
using Progress.Exception.ExceptionBase;
using Progress.Exception.Exceptions;

namespace Progress_Back_End.Controllers
{
    [Route("progress/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpPost("registrar")]
        [ProducesResponseType(typeof(RequestRegisterClienteJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult AdicionarClientes([FromBody] RequestRegisterClienteJson request)
        {
            var useCases = new RegisterClientesUseCase();
            try
            {
                var clienteAdicionado = useCases.Execute(request);
                return Created(string.Empty, clienteAdicionado);
            }
            catch (ClientesException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) {
                return BadRequest("Erro: " + ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseClientesJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult ListarClientes()
        {
            var useCase = new GetAllClientesUseCase();
            try
            {
                var response = useCase.Execute();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        [Route ("{cnpj}")]
        [ProducesResponseType(typeof(ResponseClienteDetailsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult BuscarClienteCNPJ(string cnpj)
        {
            var useCase = new GetClientesByCNPJUseCase();
            try
            {
                var response = useCase.Execute(cnpj);
                return Ok(response);
            }
            catch (ClienteNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ClientesException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete]
        [Route("{cnpj}")]
        [ProducesResponseType(typeof(ResponseClienteDetailsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult DeletarClienteCNPJ(string cnpj)
        {
            var useCase = new DeleteClienteUseCase();
            try
            {
                var response = useCase.Execute(cnpj);
                return Ok(response);
            }
            catch (ClienteNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ClientesException ex)
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
