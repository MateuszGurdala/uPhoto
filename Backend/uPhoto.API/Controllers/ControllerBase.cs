using Microsoft.AspNetCore.Mvc;

namespace uPhoto.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ControllerBase : Controller
{
}
