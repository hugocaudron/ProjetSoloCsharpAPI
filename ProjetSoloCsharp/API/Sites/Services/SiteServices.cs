using ProjetSoloCsharp.API.Salaries.Repositories;
using ProjetSoloCsharp.API.Service.Repositories;
using ProjetSoloCsharp.API.Sites.DTOs;
using ProjetSoloCsharp.API.Sites.Models;
using ProjetSoloCsharp.API.Sites.Repositories;

namespace ProjetSoloCsharp.API.Sites.Services;

public class SiteServices : ISiteServices
{ 
    private readonly ISiteRepositories _siteRepository;
    private readonly ISalariesRepositories _salariesRepository;

    public SiteServices(ISiteRepositories siteRepositories, ISalariesRepositories salariesRepository)
    {
        _siteRepository = siteRepositories; //repo des sites
        _salariesRepository = salariesRepository; //repo des salaries

    }
    
    //ajout d'un site
    public async Task<Site> AddSiteAsync(Site site)
    {
        return await _siteRepository.AddAsync(site);
    }
    
    //modification d'un site
    public async Task<Site> UpdateSiteAsync(int siteId, Site newSite)
    {
        Site site = await _siteRepository.FindAsync(siteId) ?? throw new KeyNotFoundException("aucun id trouvé");
        
        site.Ville = newSite.Ville;
        
        await _siteRepository.UpdateAsync(site);

        return site;
    }
    
    //suppression d'un site
    public async Task<Site> DeleteSiteAsync(int siteId)
    {
        Site site = await _siteRepository.FindAsync(siteId) 
                    ?? throw new KeyNotFoundException("Site not found");

        var foundSalaries = await _salariesRepository.GetAll();
        var salariesInSite = foundSalaries.Where(s => s.IdSite == siteId).ToList();

        if (salariesInSite.Any()) 
            throw new InvalidOperationException("impossible de supprimer un site car un salarié y est associer");

        await _siteRepository.DeleteAsync(site);

        return site;
    }

    
    //chercher un site par son id
    public async Task<Site> GetSiteByIdAsync(int siteId)
    {
        Site site = await _siteRepository.FindAsync(siteId) ?? throw new KeyNotFoundException("aucun site trouvé");

        return site;
    }

    //chercher tout les sites 
    public async Task<List<ReturnSiteDto>> GetAllSiteAsync()
    {
        var sites = await _siteRepository.GetAll(); 

        if (sites == null || sites.Count() == 0)
            throw new KeyNotFoundException("aucun site trouvé");

        return sites;
    }

}