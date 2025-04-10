using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Users;
using Recipe.Application.UseCases.Queries.AuditLogs;
using Recipe.Application.UseCases.Queries.Categories;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UseCaseHandler _commandHandler;
        public UsersController(UseCaseHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] UserSearchDTO search, [FromServices] IGetUsersQuery query)
           => Ok(_commandHandler.HandleQuery(query, search));



        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDTO dto, [FromServices] ICreateUserCommand cmd)
        {
            _commandHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<UsersController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserDTO dto, [FromServices] IUpdateUserCommand cmd)
        {
            dto.UserId = id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

        // PUT api/<UsersController>/5
        [Authorize]
        [HttpPut("{id}/Admin")]
        public IActionResult PutAdmin(int id, [FromBody] UpdateUserDTO dto, [FromServices] IUpdateAllUserCommand cmd)
        {
            dto.UserId = id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

        // Patch api/<UsersController>/
        [Authorize]
        [HttpPatch("{id}/Deactivate")]
        public IActionResult DeactivateUser(int id, [FromBody] TableIdDTO dto, [FromServices] IDeactivateUserCommand cmd)
        {
            dto.Id=id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

        // Patch api/<UsersController>/5
        [Authorize]
        [HttpPatch("{id}/Activate")]
        public IActionResult ActivateUser(int id, [FromBody] TableIdDTO dto, [FromServices] IActivateUserCommand cmd)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand cmd)
        {
            TableIdDTO dto = new TableIdDTO();
            dto.Id = id;
            _commandHandler.HandleCommand(cmd, dto);
            return NoContent();
        }
    }
}
