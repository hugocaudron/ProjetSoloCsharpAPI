using Microsoft.EntityFrameworkCore;
using ProjetSoloCsharp.API.Salaries.Dtos;
using ProjetSoloCsharp.Shared.Data;
using ProjetSoloCsharp.Shared.Repository;

namespace ProjetSoloCsharp.API.Salaries.Repositories;

public class SalariesRepositories : BaseRepository<Salarié>, ISalariesRepositories
{
    public SalariesRepositories(ApplicationDbContext context) : base(context)          
    {
    }
    
    
    public Task<List<ReturnSalariesDto>> GetAll(CancellationToken cancellationToken = default)
    {
        var salaries =  _context.Salariés.Select(salarie => new ReturnSalariesDto()
        {
            Email = salarie.Email,
            IdSalary = salarie.Id,
            IdServices = salarie.IdServices,
            IdSite = salarie.IdSite,
            Nom = salarie.Nom,
            Prénom = salarie.Prénom,
            TelFixe = salarie.TelFixe,
            TelPortable = salarie.TelPortable,
        }).ToListAsync();
        return salaries;
    }
}