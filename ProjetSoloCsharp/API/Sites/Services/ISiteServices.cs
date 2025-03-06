using ProjetSoloCsharp.API.Sites.DTOs;
using ProjetSoloCsharp.API.Sites.Models;

namespace ProjetSoloCsharp.API.Sites.Services;

public interface ISiteServices
{
    public Task<Site> AddSiteAsync(Site site);
    
    public Task<Site> GetSiteByIdAsync(int siteId);
    
    public Task<List<ReturnSiteDto>> GetAllSiteAsync();
    
    public Task<Site> UpdateSiteAsync(int siteId, Site site);
    
    public Task<Site> DeleteSiteAsync(int siteId);
}