using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ShapeServer.Helpers;
using ShapeServer.Models.DTO.SignupRequest;
using ShapeServer.Services;

namespace ShapeServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IValidator<SignupRequest> _validator;
        private readonly IAuthService _authService;

        public AuthController(IValidator<SignupRequest> validator, IAuthService authService)
        {
            _validator = validator;
            _authService = authService;
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

            var serviceResult = await _authService.Signup(signupRequest);
            if (!serviceResult.Success)
            {
                switch (serviceResult.Error)
                {
                    case ServiceError.EmailConflict: return Conflict(new { Email = serviceResult.Message });
                }
            }

            return Created(string.Empty, true);
        }
    }
}
