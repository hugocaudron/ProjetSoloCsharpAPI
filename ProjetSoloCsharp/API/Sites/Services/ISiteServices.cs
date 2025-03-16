using ProjetSoloCsharp.API.Sites.DTOs;
using ProjetSoloCsharp.API.Sites.Models;

namespace ProjetSoloCsharp.API.Sites.Services;

public interface ISiteServices
{
    public Task<Site> AddSiteAsync(Site site); //ajout
    
    public Task<Site> GetSiteByIdAsync(int siteId); //avoir par son id
    
    public Task<List<ReturnSiteDto>> GetAllSiteAsync(); //tout avoir
    
    public Task<Site> UpdateSiteAsync(int siteId, Site site); //modifié
    
    public Task<Site> DeleteSiteAsync(int siteId); //supprimer
}