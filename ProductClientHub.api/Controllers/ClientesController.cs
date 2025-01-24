using Microsoft.AspNetCore.Mvc;
using ProductClientHub.api.UseCases.Clients.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionBase;


namespace ProductClientHub.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseClienteJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestClientJson request)
        {
            try
            {
                var useCase = new RegisterClientUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (ProductClientHubException error)
            {
                var errors = error.GetErrors();

                return BadRequest(new ResponseErrorMessagesJson(errors));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson("ERROR DESCONHECIDO"));
            }
        }


        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }


    }
}
