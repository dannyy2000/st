using Microsoft.AspNetCore.Mvc;
using WebApplication1.data.dto.request;
using WebApplication1.data.dto.response;
using WebApplication1.services;

namespace WebApplication1.controllers;

[ApiController]
[Route("api/v1/user")]
[Produces("application/json")]
[Consumes("application/json")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<UserResponse>> Create([FromBody] CreateUserRequest createUserRequest)
    {
        var userResponse = await _userService.Register(createUserRequest);
        return CreatedAtAction(nameof(Create), userResponse);
    }

    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<UserResponse>> Login([FromBody] CreateUserRequest createUserRequest)
    {
        var userResponse =await _userService.Login(createUserRequest);
        return CreatedAtAction(nameof(Login), userResponse);
    }
    
}

