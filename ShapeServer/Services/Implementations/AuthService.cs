using ShapeServer.Models.DTO.SignupRequest;

namespace ShapeServer.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ShapeContext _dbContext;

        public AuthService(ShapeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResult<object>> Signup(SignupRequest signupRequest)
        {
            //Check if email already exists

            //Email does not exist, proceed to creation

            //Entity inserted, return success result

            return new ServiceResult<object>(success: true, message: "Account created");
        }
    }
}
