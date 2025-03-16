using ProjetSoloCsharp.API.Admins.DTOs;
using ProjetSoloCsharp.API.Admins.Models;

namespace ProjetSoloCsharp.API.Admins.Services;

public interface IAdminServices
{
    Task<ReturnAdminDto> RegisterAdmin(RegisterDto registerDto); //ajouter un admin
    
    Task<string> LogAdmin(LoginDto loginDto); //se connecter 
    

}