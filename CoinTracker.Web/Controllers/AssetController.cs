using CoinTracker.Domain.Commands.CreateAssetCommands;
using CoinTracker.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CoinTracker.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly ILogger<AssetController> _logger;
        private readonly IMediator mediator;

        public AssetController(ILogger<AssetController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] CreateAssetCommand request)
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
            await mediator.Send(new GetAssetQuery { Id = id });

            var x = HttpContext.Response.Headers;
            //todo => change for 201 response
            return Ok();
        }
    }
}
