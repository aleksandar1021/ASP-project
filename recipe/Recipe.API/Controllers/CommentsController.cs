using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Comments;
using Recipe.Application.UseCases.Queries.Categories;
using Recipe.Application.UseCases.Queries.Comments;
using Recipe.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private UseCaseHandler _commandHandler;
        public CommentsController(UseCaseHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }




        // GET: api/<CommentsController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchCommentsDTO search, [FromServices] IGetCommentsQuery query)
           => Ok(_commandHandler.HandleQuery(query, search));

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetCommentByIdQuery query)
           => Ok(_commandHandler.HandleQuery(query, id));

        // POST api/<CommentsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateCommentDTO dto, [FromServices] ICreateCommentCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<CommentsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCommentDTO dto, [FromServices] IUpdateCommentCommand cmd)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

        // DELETE api/<CommentsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCommentCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, id);
            return NoContent();
        }
    }
}
