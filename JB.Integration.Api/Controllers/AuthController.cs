using System.Threading.Tasks;
using JB.Integration.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JB.Integration.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] LoginViewModel model)
        {
            if (model == null)
                return BadRequest();

            return Ok(model);
        }
    }
}