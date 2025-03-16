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
    private readonly ISalariesRepositories _salariesRepositories;

    
    public ServiceServices(IServiceRepositories serviceRepositories, ISiteRepositories siteRepositories, ISalariesRepositories salariesRepositories)
    {
        _serviceRepositories = serviceRepositories; //repo service 
        _salariesRepositories = salariesRepositories; //repo des salarié

    }
    
    //ajouter un service
    public async Task<Models.Service> AddServiceAsync(Models.Service service)
    {
        return await _serviceRepositories.AddAsync(service);
    }
    
    //supprimer un service
    public async Task<Models.Service> DeleteServiceAsync(int serviceId)
    {
        Models.Service service = await _serviceRepositories.FindAsync(serviceId) //Regarde si le service est trouvé
                                 ?? throw new KeyNotFoundException("Service not found");

        var foundSalaries = await _salariesRepositories.GetAll();
        var salariesInService = foundSalaries.Where(s => s.IdServices == serviceId).ToList();

        if (salariesInService.Any()) //on vérifie si un salarié y est associer 
            throw new InvalidOperationException("impossible de supprimer un service car un salarié y est associer");

        await _serviceRepositories.DeleteAsync(service);

        return service;
    }
    
    //modification service
    public async Task<Models.Service> UpdateServiceAsync(int serviceId, Models.Service newService)
    {
        Models.Service service = await _serviceRepositories.FindAsync(serviceId) //erreur si l'id n'est pas trouvé
                                 ?? throw new KeyNotFoundException("aucun id trouvé"); 
        
        service.Service1 = newService.Service1;
        
        await _serviceRepositories.UpdateAsync(service);

        return service;
    }
    
    //cherche par id
    public async Task<Models.Service> GetServiceByIdAsync(int serviceId)
    {
        Models.Service service = await _serviceRepositories.FindAsync(serviceId) //erreur si l'id n'est pas trouvé
                                 ?? throw new KeyNotFoundException("aucun service trouvé");

        return service;
    }
    
    //cherche tout les service 
    public async Task<List<ReturnServiceDto>> GetAllServiceAsync()
    {
        var services = await _serviceRepositories.GetAll(); 

        if (services == null || services.Count() == 0)
            throw new KeyNotFoundException("aucun service trouvé"); // si service = 0 alors aucun service trouvé

        return services;
    }

}