using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Progress.Aplication.UseCases.Clientes.Register;
using Progress.Communication.Requests;
namespace Progress_Back_End.Controllers
{
    [Route("progress/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpPost("registrar")]
        public IActionResult adicionarcliente([FromBody] RequestRegisterClienteJson request)
        {
            var useCases = new RegisterClientesUseCase();
            useCases.Execute(request);
            return Created(string.Empty, request);
        }
    }
}
