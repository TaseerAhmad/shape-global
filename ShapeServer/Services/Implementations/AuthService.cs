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
            var hasEmailConflict = await _dbContext.Users
                .Where(u => u.Email == signupRequest.Email)
                .AnyAsync();

            if (hasEmailConflict)
            {
                return new ServiceResult<object>(
                    success: false,
                    message: "Email is already registered",
                    error: ServiceError.EmailConflict
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

            return new ServiceResult<object>(success: true, message: "Account created");
        }
    }
}
