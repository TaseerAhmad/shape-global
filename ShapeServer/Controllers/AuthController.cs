using Microsoft.AspNetCore.Mvc;
using ShapeServer.DTO.SignupRequest;

namespace ShapeServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("Signup")]
        public async Task<IActionResult> Signup(SignupRequestDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}
