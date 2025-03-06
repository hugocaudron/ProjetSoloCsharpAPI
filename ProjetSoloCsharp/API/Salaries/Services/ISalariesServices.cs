using ProjetSoloCsharp.API.Salaries.Dtos;

namespace ProjetSoloCsharp.API.Salaries.Services;

public interface ISalariesServices
{
    public Task<Salarié> AddSalariesAsync(Salarié salarié);
    
    public Task<Salarié> GetSalariesByIdAsync(int salaryId);
    
    public Task<List<ReturnSalariesDto>> GetAllSalariesAsync();
    
    public Task<Salarié> UpdateSalariesAsync(int salaryId, Salarié salarié, int siteId, int idService);
    
    public Task<Salarié> DeleteSalariesAsync(int salaryId);
}