using ProjetSoloCsharp.API.Salaries.Dtos;
using ProjetSoloCsharp.API.Salaries.Repositories;
using ProjetSoloCsharp.API.Service.DTOs;
using ProjetSoloCsharp.API.Service.Repositories;
using ProjetSoloCsharp.API.Sites.Repositories;
using ProjetSoloCsharp.API.Salaries.Extensions;

namespace ProjetSoloCsharp.API.Salaries.Services;

public class SalariesServices : ISalariesServices
{
    private readonly ISalariesRepositories _salariesRepositories;
    private readonly IServiceRepositories _serviceRepositories;
    private readonly ISiteRepositories _siteRepositories;

    
    public SalariesServices(IServiceRepositories serviceRepositories, ISiteRepositories siteRepositories, ISalariesRepositories salariesRepositories)
    {
        _serviceRepositories = serviceRepositories; //repo service
        _siteRepositories = siteRepositories; //repo site
        _salariesRepositories = salariesRepositories; //repo salarie
    }
    
    
    //ajouter un salarié
    public async Task<ReturnSalariesDto> AddSalariesAsync(Salarié salarié)
    {
        if(await _salariesRepositories.AnyAsync(s => s.Email == salarié.Email)) throw new Exception("Email déjà existant"); //vérifie si l'email existe déjà
        
        var siteExists = await _siteRepositories.FindAsync(salarié.IdSite);
        
        if (siteExists == null)
        {
            throw new ArgumentException("Le site avec l'ID spécifié n'existe pas."); //vérifie si le site existe
        }
        
        var serviceExists = await _serviceRepositories.FindAsync(salarié.IdServices);
        
        if (serviceExists == null)
        {
            throw new ArgumentException("Le service avec l'ID spécifié n'existe pas."); //vérifie si le service existe
        }

        var salarieAjoute = await _salariesRepositories.AddAsync(salarié) ?? throw new Exception("Erreur lors de l'ajout du salarié");

        return salarieAjoute.MapToReturnModel();
    }
    
    
    //modification d'un salarié
    public async Task<Salarié> UpdateSalariesAsync(int salaryId, Salarié salarié, int siteId, int serviceId)
    {
        
        Salarié salariéDb = await _salariesRepositories.FindAsync(salaryId) ?? throw new KeyNotFoundException("aucun id trouvé"); //erreur si l'id n'existe pas

        var site = await _siteRepositories.FindAsync(siteId) ?? throw new KeyNotFoundException("aucun idsite trouvé"); //erreur si le site n'est pas trouvé

        var service = await _serviceRepositories.FindAsync(serviceId) ?? throw new KeyNotFoundException("aucun idservice trouvé"); //erreur si le site n'est pas trouvé
        
        
        salariéDb.IdSite = siteId;
        salariéDb.IdServices = serviceId;
        salariéDb.Email = salarié.Email;
        salariéDb.Nom = salarié.Nom;
        salariéDb.Prénom = salarié.Prénom;
        salariéDb.TelFixe = salarié.TelFixe;
        salariéDb.TelPortable = salarié.TelPortable;

        await _salariesRepositories.UpdateAsync(salariéDb);

        return salariéDb;
    }


    //suppression d'un salarié
    public async Task<Salarié> DeleteSalariesAsync(int Id)
    {
        Salarié salarié = await _salariesRepositories.FindAsync(Id) ?? throw new KeyNotFoundException("aucun id trouvé"); //erreur si salarié n'existe pas 
        
        await _salariesRepositories.DeleteAsync(salarié);

        return salarié;
    }
    
    
    //avoir tout les salarié
    public async Task<List<ReturnSalariesDto>> GetAllSalariesAsync()
    {
        var salaries = await _salariesRepositories.GetAll(); 

        return salaries;
    }
    
    
    //avoir un salarié par son id 
    public async Task<Salarié> GetSalariesByIdAsync(int salaryId)
    {
        Salarié salarié = await _salariesRepositories.FindAsync(salaryId) ?? throw new KeyNotFoundException("aucun salarié trouvé");

        return salarié;
    }

}