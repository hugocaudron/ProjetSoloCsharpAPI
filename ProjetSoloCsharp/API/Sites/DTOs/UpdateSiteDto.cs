using System.ComponentModel.DataAnnotations;

namespace ProjetSoloCsharp.API.Sites.DTOs;

public class UpdateSiteDto
{
    [Required]
    [StringLength(255)]
    public required string Ville { get; set; }
}