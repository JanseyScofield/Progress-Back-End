using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Progress.Aplication.UseCases.Clientes.Register;
using Progress.Communication.Requests;
using Progress.Exception.ExceptionBase;
namespace Progress_Back_End.Controllers
{
    [Route("progress/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpPost("registrar")]
        public IActionResult AdicionarClientes([FromBody] RequestRegisterClienteJson request)
        {
            var useCases = new RegisterClientesUseCase();
            try
            {
                useCases.Execute(request);
                return Created(string.Empty, request);
            }
            catch (ClientesException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) {
                return BadRequest("Erro: " + ex.Message);
            }
        }
    }
}
