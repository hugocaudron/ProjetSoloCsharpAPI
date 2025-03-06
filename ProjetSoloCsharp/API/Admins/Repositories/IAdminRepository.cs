using ProjetSoloCsharp.API.Admins.DTOs;
using ProjetSoloCsharp.API.Admins.Models;
using ProjetSoloCsharp.Shared.Repository;

namespace ProjetSoloCsharp.API.Admins.Repositories;

public interface IAdminRepository : IBaseRepository<Admin>
{
    Task<ReturnAdminDto?> FindByEmailAsync(string email, CancellationToken cancellationToken = default);

}