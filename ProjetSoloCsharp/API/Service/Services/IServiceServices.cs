using ProjetSoloCsharp.API.Salaries.Repositories;
using ProjetSoloCsharp.API.Salaries.Services;
using ProjetSoloCsharp.API.Service.DTOs;
using ProjetSoloCsharp.API.Service.Models;

namespace ProjetSoloCsharp.API.Service.Services;

public interface IServiceServices
{
    public Task<Models.Service> AddServiceAsync(Models.Service service);
    
    public Task<Models.Service> GetServiceByIdAsync(int serviceId);
    
    public Task<List<ReturnServiceDto>> GetAllServiceAsync();
    
    public Task<Models.Service> UpdateServiceAsync(int serviceId, Models.Service service, int siteId);
    
    public Task<Models.Service> DeleteServiceAsync(int serviceId);
}