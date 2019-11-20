using System.Threading.Tasks;
using JB.Integration.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JB.Integration.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProfileController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new ProfileViewModel()
            {
                UserName = "JohnnBlade"
            };
            return Ok(model);
        }
    }
}