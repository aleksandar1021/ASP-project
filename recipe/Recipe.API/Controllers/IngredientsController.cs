using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Ingredients;
using Recipe.Application.UseCases.Queries.Ingredients;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private UseCaseHandler _commandHandler;
        public IngredientsController(UseCaseHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }


        // GET: api/<IngredientsController>

        [HttpGet]
        public IActionResult Get([FromQuery] NamedSearchDTO search, [FromServices] IGetIngredientsQuery query)
           => Ok(_commandHandler.HandleQuery(query, search));



        // POST api/<IngredientsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] NamedDTO dto, [FromServices] ICreateIngredientCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<IngredientsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateNamedDTO dto, [FromServices] IUpdateIngredientCommand cmd)
        {
            dto.Id = id;    
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

        // DELETE api/<IngredientsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteIngredientCommand cmd)
        {
            TableIdDTO dto = new TableIdDTO();
            dto.Id = id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }
    }
}
