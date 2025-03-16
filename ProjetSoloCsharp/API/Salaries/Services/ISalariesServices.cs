using ProjetSoloCsharp.API.Salaries.Dtos;

namespace ProjetSoloCsharp.API.Salaries.Services;

public interface ISalariesServices
{
    public Task<ReturnSalariesDto> AddSalariesAsync(Salarié salarié); //ajout
    
    public Task<Salarié> GetSalariesByIdAsync(int salaryId); //chercher par id
    
    public Task<List<ReturnSalariesDto>> GetAllSalariesAsync(); //tout avoir
    
    public Task<Salarié> UpdateSalariesAsync(int salaryId, Salarié salarié, int siteId, int idService); //modification
    
    public Task<Salarié> DeleteSalariesAsync(int salaryId); //suppression
}