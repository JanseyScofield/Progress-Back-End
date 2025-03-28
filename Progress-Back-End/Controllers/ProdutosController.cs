using Microsoft.AspNetCore.Mvc;
using Progress.Aplication.UseCases.Produtos.Delete;
using Progress.Aplication.UseCases.Produtos.Get;
using Progress.Aplication.UseCases.Produtos.Register;
using Progress.Communication.Requests.Produtos;
using Progress.Communication.Responses.Produtos;
using Progress.Exception.ExceptionBase;
using Progress.Exception.Exceptions;

namespace Progress_Back_End.Controllers
{
    [Route("progress/produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        [Route("registrar")]
        [ProducesResponseType(typeof(ResponseProdutoDetailsJson),  StatusCodes.Status201Created)]
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

        [HttpGet]
        [ProducesResponseType(typeof(ResponseProdutosDetailsJson), StatusCodes.Status200OK)]
        public IActionResult ListarProdutos()
        {
            try
            {
                var useCase = new GetAllProdutosUseCase();
                var response = useCase.Execute();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseProdutoDetailsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult BuscarProdutoId(int id) 
        {
            try {
                var useCase = new GetProdutoByIdUseCase();
                var response = useCase.Execute(id);
                return Ok(response);
            }
            catch (ProdutoNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ProdutosException ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseProdutoDetailsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult DeletarProduto(int id) 
        {
            try
            {
                var useCase = new DeleteProdutoUseCase();
                var response = useCase.Execute(id);
                return Ok(response);
            }
            catch (ProdutoNotFoundException ex) 
            {
                return NotFound(ex.Message);
            }
            catch (ProdutosException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
