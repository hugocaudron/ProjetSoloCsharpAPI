using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetSoloCsharp.API.Admins.DTOs;
using ProjetSoloCsharp.API.Admins.Services;
using ProjetSoloCsharp.API.Sites.DTOs;

namespace ProjetSoloCsharp.API.Admins.Controllers;

[ApiController]
[Route("admins")]

public class AdminController : ControllerBase
{
    private readonly IAdminServices _adminServices;

    public AdminController(IAdminServices adminServices)
    {
        _adminServices = adminServices;
    }
    
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult<ReturnAdminDto>> RegisterCustomer(RegisterDto registerDto)
    {
        return Ok(await _adminServices.RegisterAdmin(registerDto));
    }
    
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult> LogCustomer(LoginDto loginDTO)
    {
        var token = await _adminServices.LogAdmin(loginDTO);
        return Ok(new
        {
            token
        });
    }
    
}