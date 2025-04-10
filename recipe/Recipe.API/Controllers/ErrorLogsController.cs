using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.ErrorLogs;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorLogsController : ControllerBase
    {
        private UseCaseHandler _commandHandler;
        public ErrorLogsController(UseCaseHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        // GET api/<ErrorLogsController>/
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(string id, [FromServices] IGetErrorLogsQuery query)
           => Ok(_commandHandler.HandleQuery(query, id));


    }
}
