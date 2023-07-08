using ShapeServer.Models.DTO.SignupRequest;

namespace ShapeServer.Services
{
    public interface IAuthService
    {
        Task<ServiceResult<object>> Signup(SignupRequest signupRequest);
    }
}
