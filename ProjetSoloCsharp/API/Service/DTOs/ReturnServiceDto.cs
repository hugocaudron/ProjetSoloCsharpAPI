using System.ComponentModel.DataAnnotations;

namespace ProjetSoloCsharp.API.Service.DTOs;

public class ReturnServiceDto
{
    public int IdService { get; set; }

    [Required]
    [StringLength(255)]
    public string Service { get; set; } = null!;
}