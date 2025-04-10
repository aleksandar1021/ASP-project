using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.RecipeIngredients;
using Recipe.Application.UseCases.Queries.RecipeIngredients;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientsController : ControllerBase
    {
        private UseCaseHandler _commandHandler;
        public RecipeIngredientsController(UseCaseHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] SearchRecipeIngredientsDTO search, [FromServices] IGetRecipeIngredientsQuery query)
           => Ok(_commandHandler.HandleQuery(query, search));

        // POST api/<RecipeIngredientsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateRecipeIngredientDTO dto, [FromServices] ICreateRecipeIngredientCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<RecipeIngredientsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateRecipeIngredientDTO dto, [FromServices] IUpdateRecipeIngredientCommand cmd)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

        // DELETE api/<RecipeIngredientsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRecipeIngredientCommand cmd)
        {
            TableIdDTO dto = new TableIdDTO();
            dto.Id = id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }
    }
}
