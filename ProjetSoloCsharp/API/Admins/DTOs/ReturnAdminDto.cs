using System.ComponentModel.DataAnnotations;
using ProjetSoloCsharp.Shared.Validators;

namespace ProjetSoloCsharp.API.Admins.DTOs;

public class ReturnAdminDto
{
    [StringLength(255)] [EmailAddress] public required string Email { get; set; }
    
    
    
}