using Microsoft.AspNetCore.Mvc;

namespace SmartClean.Api.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    protected ActionResult<T> HandleResult<T>(T result)
    {
        if (result == null)
            return NotFound();
        
        return Ok(result);
    }

    protected ActionResult HandleResult(bool success)
    {
        if (!success)
            return BadRequest();
        
        return Ok();
    }
}
