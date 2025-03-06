using ProjetSoloCsharp.API.Salaries.Repositories;
using ProjetSoloCsharp.API.Service.Repositories;
using ProjetSoloCsharp.API.Sites.DTOs;
using ProjetSoloCsharp.API.Sites.Models;
using ProjetSoloCsharp.API.Sites.Repositories;

namespace ProjetSoloCsharp.API.Sites.Services;

public class SiteServices : ISiteServices
{ 
    private readonly ISiteRepositories _siteRepository;
    private readonly IServiceRepositories _serviceRepository;

    public SiteServices(ISiteRepositories siteRepositories, IServiceRepositories serviceRepository)
    {
        _siteRepository = siteRepositories;
        _serviceRepository = serviceRepository;

    }
    
    public async Task<Site> AddSiteAsync(Site site)
    {
        return await _siteRepository.AddAsync(site);
    }
    
    public async Task<Site> UpdateSiteAsync(int siteId, Site newSite)
    {
        Site site = await _siteRepository.FindAsync(siteId) ?? throw new KeyNotFoundException("Id not found");
        
        site.Ville = newSite.Ville;
        
        await _siteRepository.UpdateAsync(site);

        return site;
    }
    
    public async Task<Site> DeleteSiteAsync(int siteId)
    {
        Site site = await _siteRepository.FindAsync(siteId) 
                    ?? throw new KeyNotFoundException("Site not found");

        var foundService = await _serviceRepository.GetAll();
        var serviceInSite = foundService.Where(s => s.IdSites == siteId).ToList();

        if (serviceInSite.Any()) 
            throw new InvalidOperationException("Cannot delete site because there are associated service");

        await _siteRepository.DeleteAsync(site);

        return site;
    }

    
    public async Task<Site> GetSiteByIdAsync(int siteId)
    {
        Site site = await _siteRepository.FindAsync(siteId) ?? throw new KeyNotFoundException("Site not found");

        return site;
    }

    public async Task<List<ReturnSiteDto>> GetAllSiteAsync()
    {
        var sites = await _siteRepository.GetAll(); 

        if (sites == null || sites.Count() == 0)
            throw new KeyNotFoundException("No sites found");

        return sites;
    }

}