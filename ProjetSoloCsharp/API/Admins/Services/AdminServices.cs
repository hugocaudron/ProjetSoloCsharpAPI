using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProjetSoloCsharp.API.Admins.DTOs;
using ProjetSoloCsharp.API.Admins.Extensions;
using ProjetSoloCsharp.API.Admins.Models;
using ProjetSoloCsharp.API.Admins.Repositories;
using ProjetSoloCsharp.Shared.Utils;

namespace ProjetSoloCsharp.API.Admins.Services;

public class AdminServices : IAdminServices
{
    private readonly IAdminRepository _adminRepository;
    
    public AdminServices(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }
    
    public async Task<ReturnAdminDto> RegisterAdmin(RegisterDto registerDto)
    {
        if (await _adminRepository.AnyAsync(u => u.Email == registerDto.Email))
            throw new ArgumentException("Email already exists");

        var admin = registerDto.MapToAdminModel();

        var hashedPassword = PasswordUtils.HashPassword(registerDto.Password, out var salt);
        admin.PasswordHash = hashedPassword;
        admin.PasswordSalt = Convert.ToBase64String(salt);
        
        var newAdmin = await _adminRepository.AddAsync(admin);
        var newAdminDetails = await _adminRepository.FindAsync(newAdmin.Id)?? throw new KeyNotFoundException("Id not found");
        
        return newAdminDetails.MapToReturnModel();
    }
    
     public async Task<string> LogAdmin(LoginDto loginDto)
        {
            var foundAdmin = await _adminRepository
                .FirstOrDefaultAsync(a => a.Email == loginDto.Email)?? throw new KeyNotFoundException("Utilisateur introuvable");
            
            var passwordValid = PasswordUtils.VerifyPassword(
                loginDto.Password,
                foundAdmin.PasswordHash,
                Convert.FromBase64String(foundAdmin.PasswordSalt)
            );
            if (!passwordValid) throw new Exception("mauvaismdp");
            // Faire une liste de Claims 
            List<Claim> claims = new List<Claim>
            {
                new(ClaimTypes.Role, "Admin"),
                new("Email", foundAdmin.Email),
            };

            // Signer le token de connexion JWT
            var key = Environment.GetEnvironmentVariable("JWT_SECRET")
                      ?? throw new KeyNotFoundException("JWT_SECRET");
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                SecurityAlgorithms.HmacSha256);

            // On créer un objet de token à partir de la clé de sécurité et l'on y ajoute une expiration, une audience et un issuer de sorte à pouvoir cibler nos clients d'API et éviter les tokens qui trainent trop longtemps dans la nature
            JwtSecurityToken jwt = new JwtSecurityToken(
                claims: claims,
                issuer: "Issuer",
                audience: "Audience",
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(12));

            // Générer le JWT à partir de l'objet JWT 
            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return token;
        }
}