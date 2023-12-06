using System.Net;
using WebApplication1.data.dto.request;
using WebApplication1.data.dto.response;
using WebApplication1.data.models;
using WebApplication1.exceptions;

namespace WebApplication1.services;

public class UserService : IUserService
{

    private readonly StockDbContext _context;
    private readonly EmailService _emailService;

    public UserService(StockDbContext context, EmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    public async Task<UserResponse> Register(CreateUserRequest userRequest)
    {
        try
        {
            if (_context.Users.Any(u => u.Email == userRequest.Email))
            {
                throw new UserException("User with this email already exists.");
            }


            var newUser = new User
            {
                Name = userRequest.Name,
                Email = userRequest.Email,
                Password = userRequest.Password
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            string otp = GenerateOTP();
            Console.WriteLine($"This is your OTP: {otp}");

            EmailNotificationRequest emailNotificationRequest = new EmailNotificationRequest
            {
                Recipients = userRequest.Email,
                Text = $"Your OTP is {otp}"
            };


            _emailService.SendRegistrationEmail(emailNotificationRequest);


            var userResponse = MapToUserResponse(newUser);
            return userResponse;
        }
        catch (UserException e)
        {
            Console.WriteLine($"User registration failed: {e.Message}");
            
            throw;
        }
    }

    public Task<UserResponse> Login(CreateUserRequest createUserRequest)

    {
        try
        {
            var existingUser = _context.Users.SingleOrDefault(u => u.Email == createUserRequest.Email);

            if (existingUser == null)
            {
                throw new UserException("User not found");
            }

            if (existingUser.Password != createUserRequest.Password)
            {
                throw new UserException("password does not match");
            }

            var userResponse = MapToLoggedUserResponse(existingUser);

            return Task.FromResult(userResponse);
        }
        catch (UserException e)
        {
            Console.WriteLine($"User Login failed: {e.Message}");

            throw;
        }
    }



    private UserResponse MapToUserResponse(User user)
        {
            UserResponse userResponse = new UserResponse
            {
                Id = user.Id,
                IsSuccessful = true,
                Message = "User Created Successfully"
            };
            return userResponse;
        }
        
        private string GenerateOTP()
        {
                
            Random random = new Random();
            int otpNumber = random.Next(100000, 999999);
            return otpNumber.ToString();
        }
        
        private UserResponse MapToLoggedUserResponse(User user)
        {
            UserResponse userResponse = new UserResponse
            {
                Id = user.Id,
                IsSuccessful = true,
                Message = "User Logged Successfully"
            };
            return userResponse;
        }
    }

    