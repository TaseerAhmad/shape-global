using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ShapeServer.Helpers;
using ShapeServer.Models.DTO.SignupRequest;
using ShapeServer.Services;
using System.Net;

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
                var apiResponse = ApiResponseGenerator.GenerateApiResponse(errors, (int)HttpStatusCode.BadRequest);
                return BadRequest(apiResponse);
            }

            var serviceResult = await _authService.Signup(signupRequest);
            if (!serviceResult.Success)
            {
                switch (serviceResult.ErrorType)
                {
                    case ServiceErrorType.EmailConflict:
                        return Conflict(ApiResponseGenerator.GenerateApiResponse(serviceResult, (int)HttpStatusCode.Conflict));
                }
            }

            return Created(string.Empty, serviceResult.Result);
        }
    }
}
