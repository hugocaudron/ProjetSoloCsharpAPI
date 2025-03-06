using System.ComponentModel.DataAnnotations;

namespace ProjetSoloCsharp.API.Service.DTOs;

public class CreateServiceDto
{
    [Required]
    [StringLength(255)]
    public required string Service { get; set; }
    
    public int IdSites { get; set; }

}