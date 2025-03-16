using Microsoft.EntityFrameworkCore;
using ProjetSoloCsharp.API.Sites.DTOs;
using ProjetSoloCsharp.API.Sites.Models;
using ProjetSoloCsharp.Shared.Data;
using ProjetSoloCsharp.Shared.Repository;


namespace ProjetSoloCsharp.API.Sites.Repositories;

public class SiteRepositories : BaseRepository<Site>, ISiteRepositories
{
    public SiteRepositories(ApplicationDbContext context) : base(context)          
    {
    }

    //getall qui renvoie tout les sites
    public Task<List<ReturnSiteDto>> GetAll(CancellationToken cancellationToken = default)
    {
        var sites =  _context.Sites.Select(site => new ReturnSiteDto()
        {
            VilleID = site.Id,
            Ville = site.Ville,
        }).ToListAsync();
        return sites;
    }
}
