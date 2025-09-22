using Microsoft.AspNetCore.Mvc;
using Terminals.Web.Models;

namespace Terminals.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TerminalsController : ControllerBase
    {
        private static readonly string[] Terminals = [
            "fb193183-f60a-4b66-939f-d875c7db4074", "5c4eb776-a8cd-467d-9298-d2064f1242f0", "fb4667ca-7efd-47bf-b6cb-0f1a7645fffb", "c010b8f8-5c21-4a70-8437-2b9289b17fd2", "21b4fd88-3599-493c-8989-32524f74ef65", "be1bc225-7986-45cf-aef5-8c12cebe9fd0", "e18ce7db-d0aa-408e-9e21-587764d4f55d", "f7dfb574-6681-4294-9632-01368cc6f259", "a67a6557-0dc5-4902-b061-1144d92f5920", "0c919feb-6ae3-4be3-9369-3f774bf0406e", "9518d0dc-6455-4405-a996-e6e62ed13769", "e4dfa898-a7ec-43b0-bafd-f900a00cbf32", "c6e6c090-a624-4917-9f41-9d743261e24a", "01b7aaf1-8526-4746-b8f8-07b326eb27f2", "d7477314-c1d8-441e-bf51-84be66a5ca80"
            ];

        private readonly ILogger<TerminalsController> _logger;

        public TerminalsController(ILogger<TerminalsController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IEnumerable<Terminal> Get()
        {
            return [.. Terminals.Select(id => new Terminal
            {
                Id = Guid.Parse(id),
            })];
        }
    }
}
