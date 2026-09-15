using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestCleanCode.Controllers;


[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DailyLogController : ControllerBase
{

}
