using ProjetSoloCsharp.API.Sites.DTOs;
using ProjetSoloCsharp.Shared.Repository;
using ProjetSoloCsharp.API.Sites.Models;

namespace ProjetSoloCsharp.API.Sites.Repositories;

public interface ISiteRepositories : IBaseRepository<Site>
{
    Task<List<ReturnSiteDto>> GetAll(CancellationToken cancellationToken = default); //getall qui revoie tout les sites 
}