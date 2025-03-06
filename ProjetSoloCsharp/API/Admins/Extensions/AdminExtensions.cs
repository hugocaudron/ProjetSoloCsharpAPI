using ProjetSoloCsharp.API.Admins.DTOs;
using ProjetSoloCsharp.API.Admins.Models;

namespace ProjetSoloCsharp.API.Admins.Extensions;

public static class AdminExtensions
{
    public static Admin MapToAdminModel(this RegisterDto registerDto)
    {
        return new Admin
        {
            Email = registerDto.Email,
            PasswordHash = registerDto.Password,
            PasswordSalt = registerDto.Password,
        };
    }
    
    public static ReturnAdminDto MapToReturnModel(this Admin admin)
    {
        return new ReturnAdminDto
        {
            Email = admin.Email,
            
        };
    }

}