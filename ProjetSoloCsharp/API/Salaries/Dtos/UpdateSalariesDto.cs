using System.ComponentModel.DataAnnotations;

namespace ProjetSoloCsharp.API.Salaries.Dtos;

public class UpdateSalariesDto
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

    public int IdServices { get; set; }

    public int IdSite { get; set; } 
}