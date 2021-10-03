using Microsoft.AspNetCore.Mvc;

namespace Pictr.Controllers;

[ApiController]
[Route("[controller]")]
public class StatusController : ControllerBase
{
    private readonly ILogger<StatusController> _logger;

    public StatusController(ILogger<StatusController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<string> Get()
    {
        return "Running";
    }
}
