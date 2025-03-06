using ProjetSoloCsharp.API.Salaries.Dtos;
using ProjetSoloCsharp.API.Salaries.Repositories;
using ProjetSoloCsharp.API.Service.DTOs;
using ProjetSoloCsharp.API.Service.Repositories;
using ProjetSoloCsharp.API.Sites.Repositories;

namespace ProjetSoloCsharp.API.Salaries.Services;

public class SalariesServices : ISalariesServices
{
    private readonly ISalariesRepositories _salariesRepositories;
    private readonly IServiceRepositories _serviceRepositories;
    private readonly ISiteRepositories _siteRepositories;

    
    public SalariesServices(IServiceRepositories serviceRepositories, ISiteRepositories siteRepositories, ISalariesRepositories salariesRepositories)
    {
        _serviceRepositories = serviceRepositories;
        _siteRepositories = siteRepositories;
        _salariesRepositories = salariesRepositories;
    }
    
    public async Task<Salarié> AddSalariesAsync(Salarié salarié)
    {
        var siteExists = await _siteRepositories.FindAsync(salarié.IdSite);
        
        if (siteExists == null)
        {
            throw new ArgumentException("Le site avec l'ID spécifié n'existe pas.");
        }
        
        var serviceExists = await _serviceRepositories.FindAsync(salarié.IdServices);
        
        if (serviceExists == null)
        {
            throw new ArgumentException("Le service avec l'ID spécifié n'existe pas.");
        }
        
        return await _salariesRepositories.AddAsync(salarié);
    }
    
    public async Task<Salarié> UpdateSalariesAsync(int salaryId, Salarié salarié, int siteId, int serviceId)
    {
        Salarié salariéDb = await _salariesRepositories.FindAsync(salaryId) ?? throw new KeyNotFoundException("Id not found");

        var site = await _siteRepositories.FindAsync(siteId) ?? throw new KeyNotFoundException("Idsite not found");

        var service = await _serviceRepositories.FindAsync(serviceId) ?? throw new KeyNotFoundException("Idservice not found");

        salariéDb.IdSite = siteId;
        salariéDb.IdServices = serviceId;
        salariéDb.Email = salariéDb.Email;
        salariéDb.Nom = salariéDb.Nom;
        salariéDb.Prénom = salariéDb.Prénom;
        salariéDb.TelFixe = salariéDb.TelFixe;
        salariéDb.TelPortable = salariéDb.TelPortable;

        await _salariesRepositories.UpdateAsync(salariéDb);

        return salariéDb;
    }


    
    public async Task<Salarié> DeleteSalariesAsync(int Id)
    {
        Salarié salarié = await _salariesRepositories.FindAsync(Id) ?? throw new KeyNotFoundException("Id not found");
        
        await _salariesRepositories.DeleteAsync(salarié);

        return salarié;
    }
    
    public async Task<List<ReturnSalariesDto>> GetAllSalariesAsync()
    {
        var salaries = await _salariesRepositories.GetAll(); 

        if (salaries == null || salaries.Count() == 0)
            throw new KeyNotFoundException("No salaries found");

        return salaries;
    }
    
    public async Task<Salarié> GetSalariesByIdAsync(int salaryId)
    {
        Salarié salarié = await _salariesRepositories.FindAsync(salaryId) ?? throw new KeyNotFoundException("Salarie not found");

        return salarié;
    }

}