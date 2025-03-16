using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjetSoloCsharp.API.Sites.DTOs;
using ProjetSoloCsharp.API.Sites.Extensions;
using ProjetSoloCsharp.API.Sites.Repositories;
using ProjetSoloCsharp.API.Sites.Models;
using ProjetSoloCsharp.API.Sites.Services;

namespace ProjetSoloCsharp.API.Sites.Controllers;

[ApiController]
[Route("sites")]


public class SiteController : ControllerBase
{
    private readonly ISiteServices _siteServices;

    public SiteController(ISiteServices siteServices)
    {
        _siteServices = siteServices;
    }
    
    [Authorize]//besoins du token pour pouvoir le faire 
    [HttpPost]//Post 
    
    //controller ajout site 
    public async Task<ActionResult<Site?>> AddSite([FromBody] CreateSiteDto createSiteDto)
    {
        var siteToAdd = createSiteDto.MapToSiteModel();
        var isAdded = await _siteServices.AddSiteAsync(siteToAdd);
        return Ok(isAdded);
    }
    
    [Authorize]
    [HttpPut("{id}")]
    
    //controller modification 
    public async Task<IActionResult> UpdateSite([FromRoute] int id, [FromBody] UpdateSiteDto updateSiteDto)
    {
        var siteToUpdate = updateSiteDto.MapToSiteModel();
        var isAdded = await _siteServices.UpdateSiteAsync(id, siteToUpdate);
        return Ok(isAdded);
    }
    
    [Authorize]
    [HttpDelete("{id}")]
    
    //controller suppression
    public async Task<IActionResult> DeleteSite([FromRoute] int id)
    {
        var isDeleted = await _siteServices.DeleteSiteAsync(id);
        return Ok(isDeleted);
    }
    
    [Authorize]
    [HttpGet("{id}")]
    
    //controller trouvé par son id 
    public async Task<IActionResult> FindSiteById([FromRoute] int id)
    {
        var site = await _siteServices.GetSiteByIdAsync(id);
        return Ok(site);
    }
    
    
    //pas de [Authirize] car un visiteur peu le faire 
    [HttpGet]
    
    //controller tout avoir 
    public async Task<IActionResult> GetAllSiteAsync()
    {
        var sites = await _siteServices.GetAllSiteAsync();
        return Ok(sites);
    }


}