using CoinTracker.Domain.Commands.UserCommands.CreateUser;
using CoinTracker.Domain.Queries.UserQueries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CoinTracker.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand request)
        {
            await mediator.Send(request);

            var x = HttpContext.Response.Headers;
            //todo => change for 201 response
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            await mediator.Send(new GetUserQuery { Id = id });

            var x = HttpContext.Response.Headers;
            //todo => change for 201 response
            return Ok();
        }
    }
}
