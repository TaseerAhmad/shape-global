using Microsoft.EntityFrameworkCore;
using ShapeServer.Helpers;
using ShapeServer.Models;
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
            var errors = new Lazy<Dictionary<string, string[]>>();

            var hasEmailConflict = await _dbContext.Users
                .Where(u => u.Email == signupRequest.Email)
                .AnyAsync();

            if (hasEmailConflict)
            {
                var conflictMessage = "Email is already registered";
                errors.Value.Add(nameof(signupRequest.Email), new[] { conflictMessage });

                return new ServiceResult<object>(
                    success: false,
                    resultTitle: "Entry failed because the resource that already exists.",
                    message: conflictMessage,
                    errorType: ServiceErrorType.EmailConflict,
                    errors: errors.Value
                    );
            }

            var newUser = new User
            {
                Email = signupRequest.Email,
                FirstName = signupRequest.FirstName,
                LastName = signupRequest.LastName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(signupRequest.Password)
            };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();

            return new ServiceResult<object>(
                success: true,
                resultTitle: "Resource created.",
                message: "Account created",
                result: true);
        }
    }
}
