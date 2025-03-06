using ProjetSoloCsharp.API.Salaries.Dtos;
using ProjetSoloCsharp.Shared.Repository;

namespace ProjetSoloCsharp.API.Salaries.Repositories;

public interface ISalariesRepositories : IBaseRepository<Salarié>
{
    Task<List<ReturnSalariesDto>> GetAll(CancellationToken cancellationToken = default);
}