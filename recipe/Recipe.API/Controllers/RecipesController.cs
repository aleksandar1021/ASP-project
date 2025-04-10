using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Recipes;
using Recipe.Application.UseCases.Queries.Recipes;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class RecipesController : ControllerBase
    {
        private UseCaseHandler _commandHandler;
        public RecipesController(UseCaseHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }


        // GET: api/<RecipesController>
        [HttpGet]
        public IActionResult Get([FromQuery] RecipeSearchDTO search, [FromServices] IGetRecipesByFilterQuery query)
           => Ok(_commandHandler.HandleQuery(query, search));



        // GET api/<RecipesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetRecipeByIdQuery query)
        {
            TableIdDTO dto = new TableIdDTO();
            dto.Id = id;

            return Ok(_commandHandler.HandleQuery(query, dto));
        }

        // POST api/<RecipesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] RecipeDTO dto, [FromServices] ICreateRecipesCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<RecipesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateRecipeDTO dto, IUpdateRecipeCommand cmd)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

        // DELETE api/<RecipesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRecipeCommand cmd)
        {
            TableIdDTO dto = new TableIdDTO();
            dto.Id = id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }
    }
}
