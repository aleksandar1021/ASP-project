using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Categories;
using Recipe.Application.UseCases.Queries.Categories;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private UseCaseHandler _commandHandler;
        public CategoriesController(UseCaseHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }


        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get([FromQuery] CategorySearchDTO search, [FromServices] IGetCategoriesQuery query)
           => Ok(_commandHandler.HandleQuery(query, search));

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromQuery] TableIdDTO search, [FromServices] IGetCategoryWithChildrenByIdQuery query)
        {
            search.Id = id;
            return Ok(_commandHandler.HandleQuery(query,search));
        }

        // POST api/<CategoriesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryDTO dto, [FromServices] ICreateCategoryCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<CategoriesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCategoryDTO dto, [FromServices] IUpdateCategoryCommand cmd)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

        // DELETE api/<CategoriesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteCategoryCommand cmd)
        {
            TableIdDTO dto = new TableIdDTO();
            dto.Id = id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }
    }
}
