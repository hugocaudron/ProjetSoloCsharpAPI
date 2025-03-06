using System.ComponentModel.DataAnnotations;

namespace ProjetSoloCsharp.API.Service.DTOs;

public class ReturnServiceDto
{
    public int IdService { get; set; }
    
    public int IdSites { get; set; }

    [Required]
    [StringLength(255)]
    public string Service { get; set; } = null!;
}