using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ShapeServer.Helpers;
using ShapeServer.Models.DTO.SignupRequest;

namespace ShapeServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IValidator<SignupRequest> _validator;

        public AuthController(IValidator<SignupRequest> validator)
        {
            _validator = validator;
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> Signup(SignupRequest signupRequest)
        {
            var validationResult = await _validator.ValidateAsync(signupRequest);
            if (!validationResult.IsValid)
            {
                var errors = ValidationError.GetErrors(validationResult.Errors);
                return BadRequest(errors);
            }

            throw new NotImplementedException();
        }
    }
}
