using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Users;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserUseCaseController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public UserUseCaseController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchUserUseCasesDTO search, [FromServices] IGetUserUseCasesQuery query)
           => Ok(_useCaseHandler.HandleQuery(query, search));

        // PUT api/<UserUseCaseController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserUseCaseDTO dto, [FromServices] IUpdateUserUseCaseAccessCommand cmd)
        {
            dto.UserId = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

    }
}
