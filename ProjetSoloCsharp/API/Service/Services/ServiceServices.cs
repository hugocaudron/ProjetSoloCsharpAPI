using ProjetSoloCsharp.API.Salaries.Repositories;
using ProjetSoloCsharp.API.Service.DTOs;
using ProjetSoloCsharp.API.Service.Models;
using ProjetSoloCsharp.API.Service.Repositories;
using ProjetSoloCsharp.API.Sites.Models;
using ProjetSoloCsharp.API.Sites.Repositories;

namespace ProjetSoloCsharp.API.Service.Services;

public class ServiceServices : IServiceServices
{
    private readonly IServiceRepositories _serviceRepositories;
    private readonly ISiteRepositories _siteRepositories;
    private readonly ISalariesRepositories _salariesRepositories;

    
    public ServiceServices(IServiceRepositories serviceRepositories, ISiteRepositories siteRepositories, ISalariesRepositories salariesRepositories)
    {
        _serviceRepositories = serviceRepositories;
        _siteRepositories = siteRepositories;
        _salariesRepositories = salariesRepositories;

    }
    
    public async Task<Models.Service> AddServiceAsync(Models.Service service)
    {
        var siteExists = await _siteRepositories.FindAsync(service.IdSites);
        
        if (siteExists == null)
        {
            throw new ArgumentException("Le site avec l'ID spécifié n'existe pas.");
        }
        
        return await _serviceRepositories.AddAsync(service);
    }
    
    public async Task<Models.Service> DeleteServiceAsync(int serviceId)
    {
        Models.Service service = await _serviceRepositories.FindAsync(serviceId) 
                                 ?? throw new KeyNotFoundException("Service not found");

        var foundSalaries = await _salariesRepositories.GetAll();
        var salariesInService = foundSalaries.Where(s => s.IdServices == serviceId).ToList();

        if (salariesInService.Any()) 
            throw new InvalidOperationException("Cannot delete service because there are associated to Salarie");

        await _serviceRepositories.DeleteAsync(service);

        return service;
    }
    
    public async Task<Models.Service> UpdateServiceAsync(int serviceId, Models.Service newService, int siteId)
    {
        Models.Service service = await _serviceRepositories.FindAsync(serviceId) ?? throw new KeyNotFoundException("Id not found");
        
        var site = await _siteRepositories.FindAsync(siteId) ?? throw new KeyNotFoundException("Idsite not found");

        service.Service1 = newService.Service1;
        service.IdSites = newService.IdSites;
        
        await _serviceRepositories.UpdateAsync(service);

        return service;
    }
    
    public async Task<Models.Service> GetServiceByIdAsync(int serviceId)
    {
        Models.Service service = await _serviceRepositories.FindAsync(serviceId) ?? throw new KeyNotFoundException("Service not found");

        return service;
    }
    
    public async Task<List<ReturnServiceDto>> GetAllServiceAsync()
    {
        var services = await _serviceRepositories.GetAll(); 

        if (services == null || services.Count() == 0)
            throw new KeyNotFoundException("No service found");

        return services;
    }

}