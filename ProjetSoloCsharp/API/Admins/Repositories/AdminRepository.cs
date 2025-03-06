using Microsoft.EntityFrameworkCore;
using ProjetSoloCsharp.API.Admins.DTOs;
using ProjetSoloCsharp.API.Admins.Models;
using ProjetSoloCsharp.Shared.Data;
using ProjetSoloCsharp.Shared.Repository;

namespace ProjetSoloCsharp.API.Admins.Repositories;

public class AdminRepository : BaseRepository<Admin>, IAdminRepository
{
    public AdminRepository(ApplicationDbContext context) : base(context)          
    {
    }


    public async Task<ReturnAdminDto?> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await (from admin in _context.Admins  
            where admin.Email == email
            select new ReturnAdminDto
            {
                Email = admin.Email,
            }).FirstOrDefaultAsync(cancellationToken);
    }
}