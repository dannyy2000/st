using WebApplication1.data.dto.request;
using WebApplication1.data.dto.response;

namespace WebApplication1.services;

public interface IUserService
{
    Task<UserResponse> Register(CreateUserRequest userRequest);
    Task<UserResponse> Login(CreateUserRequest createUserRequest);
}