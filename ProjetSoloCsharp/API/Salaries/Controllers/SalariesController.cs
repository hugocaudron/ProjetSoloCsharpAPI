using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetSoloCsharp.API.Salaries.Dtos;
using ProjetSoloCsharp.API.Salaries.Extensions;
using ProjetSoloCsharp.API.Salaries.Services;

namespace ProjetSoloCsharp.API.Salaries.Controllers;

[ApiController]
[Route("salaries")]

public class SalariesController : ControllerBase
{
    private readonly ISalariesServices _salariesServices;

    public SalariesController(ISalariesServices salariesServices)
    {
        _salariesServices = salariesServices;
    }
    
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Salarié?>> AddSalaries([FromBody] CreateSalariesDto createSalariesDto)
    {
        var salariesToAdd = createSalariesDto.MapToSalariesModel();
        var isAdded = await _salariesServices.AddSalariesAsync(salariesToAdd);
        return Ok(isAdded);
    }
    
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateSalaries([FromRoute] int id, [FromBody] UpdateSalariesDto updateSalariesDto)
    {
        var salariesToUpdate = updateSalariesDto.MapToSalariesModel();

        var isAdded = await _salariesServices.UpdateSalariesAsync(id, salariesToUpdate, updateSalariesDto.IdServices, updateSalariesDto.IdSite);

        return Ok(isAdded);
    }
    
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteSalaries([FromRoute] int id)
    {
        var isDeleted = await _salariesServices.DeleteSalariesAsync(id);
        return Ok(isDeleted);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllSalariesAsync()
    {
        var salaries = await _salariesServices.GetAllSalariesAsync();
        return Ok(salaries);
    }
    
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> FindSalariesById([FromRoute] int id)
    {
        var salarie = await _salariesServices.GetSalariesByIdAsync(id);
        return Ok(salarie);
    }
}