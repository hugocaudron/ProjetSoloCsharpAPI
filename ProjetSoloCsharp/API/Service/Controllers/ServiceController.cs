using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetSoloCsharp.API.Service.DTOs;
using ProjetSoloCsharp.API.Service.Extensions;
using ProjetSoloCsharp.API.Service.Models;
using ProjetSoloCsharp.API.Service.Services;
using ProjetSoloCsharp.API.Sites.DTOs;
using ProjetSoloCsharp.API.Sites.Services;

namespace ProjetSoloCsharp.API.Service.Controllers;

[ApiController]
[Route("services")]

public class ServiceController : ControllerBase
{
    private readonly IServiceServices _serviceServices;

    public ServiceController(IServiceServices serviceServices)
    {
        _serviceServices = serviceServices;
    }
    
    [HttpPost]
    [Authorize]//besoins du token 
    
    //controller ajout 
    public async Task<ActionResult<Models.Service?>> AddService([FromBody] CreateServiceDto createServiceDto)
    {
        var serviceToAdd = createServiceDto.MapToServiceModel();
        var isAdded = await _serviceServices.AddServiceAsync(serviceToAdd);
        return Ok(isAdded);
    }
    
    [HttpDelete("{id}")]
    [Authorize]
    
    //controller delete
    public async Task<IActionResult> DeleteService([FromRoute] int id)
    {
        var isDeleted = await _serviceServices.DeleteServiceAsync(id);
        return Ok(isDeleted);
    }
    
    [HttpPut("{id}")]
    [Authorize]
    
    //controller update
    public async Task<IActionResult> UpdateService([FromRoute] int id, [FromBody] UpdateServiceDto updateServiceDto)
    {
        var serviceToUpdate = updateServiceDto.MapToServiceModel();

        var isAdded = await _serviceServices.UpdateServiceAsync(id, serviceToUpdate);

        return Ok(isAdded);
    }
    
    
    [HttpGet("{id}")]
    [Authorize]
    
    //controller trouvé par id 
    public async Task<IActionResult> FindServiceById([FromRoute] int id)
    {
        var service = await _serviceServices.GetServiceByIdAsync(id);
        return Ok(service);
    }

    [HttpGet]
    
    //controller tout avoir
    public async Task<IActionResult> GetAllServiceAsync()
    {
        var sites = await _serviceServices.GetAllServiceAsync();
        return Ok(sites);
    }
}