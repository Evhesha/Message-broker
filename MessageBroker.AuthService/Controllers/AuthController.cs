using MessageBroker.AuthService.Abstractions;
using MessageBroker.AuthService.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MessageBroker.AuthService.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    
}