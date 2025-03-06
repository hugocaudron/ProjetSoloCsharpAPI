using ProjetSoloCsharp.API.Service.DTOs;
using ProjetSoloCsharp.Shared.Repository;
using ProjetSoloCsharp.API.Service.Models;

namespace ProjetSoloCsharp.API.Service.Repositories;

public interface IServiceRepositories : IBaseRepository<Models.Service>
{
    Task<List<ReturnServiceDto>> GetAll(CancellationToken cancellationToken = default);

}