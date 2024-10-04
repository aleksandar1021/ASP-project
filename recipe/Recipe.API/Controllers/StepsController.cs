using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Steps;
using Recipe.Application.UseCases.Queries.Steps;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepsController : ControllerBase
    {
        private UseCaseHandler _commandHandler;
        public StepsController(UseCaseHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }



        // GET: api/<StepsController>
    
        [HttpGet]
        public IActionResult Get([FromQuery] SearchStepDTO search, [FromServices] IGetStepsQuery query)
           => Ok(_commandHandler.HandleQuery(query, search));



        // POST api/<StepsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateStepDTO dto, [FromServices] ICreateStepCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<StepsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateStepDTO dto, [FromServices] IUpdateStepCommand cmd)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

        // DELETE api/<StepsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteStepCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, id);
            return NoContent();
        }
    }
}
