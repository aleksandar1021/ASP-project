using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Follows;
using Recipe.Application.UseCases.Queries.Follows;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowsController : ControllerBase
    {
        private UseCaseHandler _commandHandler;
        public FollowsController(UseCaseHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }


        // GET: api/<FollowsController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchFollowsDTO search, [FromServices] IGetFollowsQuery query)
           => Ok(_commandHandler.HandleQuery(query, search));



        // POST api/<FollowsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateFollowDTO dto, [FromServices] ICreateFollowCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }



        // DELETE api/<FollowsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteFollowCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, id);
            return NoContent();
        }
    }
}
