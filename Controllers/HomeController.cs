using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult ABOBA(string word)
        {
            return Ok(word);
        }
    }
}