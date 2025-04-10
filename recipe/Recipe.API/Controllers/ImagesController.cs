using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Images;
using Recipe.Application.UseCases.Queries.Images;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private UseCaseHandler _commandHandler;
        public ImagesController(UseCaseHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }



        // GET: api/<ImagesController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchImagesDTO search, [FromServices] IGetImagesQuery query)
           => Ok(_commandHandler.HandleQuery(query, search));



        // POST api/<ImagesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateImageDTO dto, [FromServices] ICreateImageCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<ImagesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateImageDTO dto, [FromServices] IUpdateImageCommand cmd)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

        // DELETE api/<ImagesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteImageCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, id);
            return NoContent();
        }
    }
}
