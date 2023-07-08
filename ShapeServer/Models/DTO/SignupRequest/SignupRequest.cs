using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ShapeServer.Models.DTO.SignupRequest
{
    public record SignupRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string ConfirmPassword
        );
}
