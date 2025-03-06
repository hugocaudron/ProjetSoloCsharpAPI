using System.ComponentModel.DataAnnotations;
using ProjetSoloCsharp.Shared.Validators;

namespace ProjetSoloCsharp.API.Admins.DTOs;

public class LoginDto
{
    [StringLength(255)] [EmailAddress] public required string Email { get; set; }
    
    [PasswordValidator] public required string Password { get; set; }
}