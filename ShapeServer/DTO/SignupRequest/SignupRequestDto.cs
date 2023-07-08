using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ShapeServer.DTO.SignupRequest
{
    [BindRequired]
    public record SignupRequestDto(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string ConfirmPassword
        );
}
