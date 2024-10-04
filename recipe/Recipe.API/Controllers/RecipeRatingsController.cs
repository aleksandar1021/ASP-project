using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.RecipeRatings;
using Recipe.Application.UseCases.Queries.RecipeRatings;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeRatingsController : ControllerBase
    {
        private UseCaseHandler _commandHandler;
        public RecipeRatingsController(UseCaseHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        // GET: api/<RecipeRatingsController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchRecipeRatingsDTO search, [FromServices] IGetRecipeRatingsQuery query)
           => Ok(_commandHandler.HandleQuery(query, search));


        // POST api/<RecipeRatingsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateRecipeRatingsDTO dto, [FromServices] ICreateRecipeRatingsCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }


        // DELETE api/<RecipeRatingsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRecipeRatingsCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, id);
            return NoContent();
        }
    }
}
