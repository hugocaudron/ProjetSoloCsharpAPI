using System.ComponentModel.DataAnnotations;
using ProjetSoloCsharp.API.Service.DTOs;
using ProjetSoloCsharp.API.Sites.DTOs;

namespace ProjetSoloCsharp.API.Salaries.Dtos;

public class ReturnSalariesDto
{
    [Required]
    [StringLength(255)]
    public string Nom { get; set; } = null!;
    
    [Required]
    [StringLength(255)]
    public string Prénom { get; set; } = null!;
    
    [Required]
    public int TelFixe { get; set; }

    [Required]
    public int TelPortable { get; set; }

    [StringLength(255)] 
    [EmailAddress]
    public required string Email { get; set; } = null!;

    public int IdSite { get; set; }

    public int IdServices { get; set; }
    
    public int IdSalary { get; set; }
    
    public ReturnSiteDto? Site { get; set; }
    
    public ReturnServiceDto? Service { get; set; }
}