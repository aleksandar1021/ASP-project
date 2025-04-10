using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.AuditLogs;
using Recipe.Implementation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        private UseCaseHandler _commandHandler;
        public AuditLogController(UseCaseHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }


        // GET: api/<AuditLogController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] AuditLogSearchDTO search, [FromServices] IGetAuditLogQuery query)
            => Ok(_commandHandler.HandleQuery(query, search));


    }
}
