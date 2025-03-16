using System.ComponentModel.DataAnnotations;

namespace ProjetSoloCsharp.API.Service.DTOs;

public class UpdateServiceDto
{
    [Required]
    [StringLength(255)]
    public string Service { get; set; } = null!;
}