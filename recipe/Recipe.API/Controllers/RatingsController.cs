using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Rating;
using Recipe.Application.UseCases.Queries.Rating;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private UseCaseHandler _commandHandler;
        public RatingsController(UseCaseHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }



        // GET: api/<RatingsController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchRatingsDTO search, [FromServices] IGetRatingsQuery query)
           => Ok(_commandHandler.HandleQuery(query, search));



        // POST api/<RatingsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] RatingDTO dto, [FromServices] ICreateRatingCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<RatingsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateRatingDTO dto, [FromServices] IUpdateRatingCommand cmd)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

        // DELETE api/<RatingsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRatingCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, id);
            return NoContent();
        }
    }
}
