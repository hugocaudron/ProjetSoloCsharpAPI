using Microsoft.EntityFrameworkCore;
using ProjetSoloCsharp.API.Service.DTOs;
using ProjetSoloCsharp.API.Service.Models;
using ProjetSoloCsharp.Shared.Data;
using ProjetSoloCsharp.Shared.Repository;

namespace ProjetSoloCsharp.API.Service.Repositories;

public class ServiceRepositories : BaseRepository<Models.Service>, IServiceRepositories
{
    public ServiceRepositories(ApplicationDbContext context) : base(context)          
    {
    }
    
    public Task<List<ReturnServiceDto>> GetAll(CancellationToken cancellationToken = default)
    {
        var services =  _context.Services.Select(service => new ReturnServiceDto()
        {
            Service = service.Service1,
            IdService = service.Id,
            IdSites = service.IdSites,
        }).ToListAsync();
        return services;
    }
}