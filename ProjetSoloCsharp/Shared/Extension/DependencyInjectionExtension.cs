using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;
using ProjetSoloCsharp.API.Admins.Repositories;
using ProjetSoloCsharp.API.Admins.Services;
using ProjetSoloCsharp.API.Salaries.Repositories;
using ProjetSoloCsharp.API.Salaries.Services;
using ProjetSoloCsharp.API.Service.Repositories;
using ProjetSoloCsharp.API.Service.Services;
using ProjetSoloCsharp.API.Sites.Repositories;
using ProjetSoloCsharp.API.Sites.Services;
using ProjetSoloCsharp.Shared.Data;

namespace ProjetSoloCsharp.Shared.Extensions;

// Extension pour gérer l'injection de dépendances dans l'application
public static class DependencyInjectionExtensions
{
    public static void InjectDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(); 
        builder.Services.AddHttpContextAccessor(); 
        builder.AddServices(); 
        builder.AddRepositories(); 
        builder.AddJWT(); 
        builder.AddSwagger(); 
        builder.AddEFCoreConfiguration(); 
        builder.ConfigureCors(); 
    }

    // Méthode pour enregistrer les services métiers dans le conteneur d'injection
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISiteServices, SiteServices>();
        builder.Services.AddScoped<IAdminServices, AdminServices>();
        builder.Services.AddScoped<IServiceServices, ServiceServices>();
        builder.Services.AddScoped<ISalariesServices, SalariesServices>();
    }

    // Méthode pour enregistrer les repositories dans le conteneur d'injection
    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISiteRepositories, SiteRepositories>();
        builder.Services.AddScoped<IAdminRepository, AdminRepository>();
        builder.Services.AddScoped<IServiceRepositories, ServiceRepositories>();
        builder.Services.AddScoped<ISalariesRepositories, SalariesRepositories>();
    }

    // Configuration de l'authentification JWT
    public static void AddJWT(this WebApplicationBuilder builder)
    {
        var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ??
                        throw new InvalidOperationException("JWT secret 'JWT_SECRET' not found.");

        var key = Encoding.ASCII.GetBytes(jwtSecret);

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; 
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, 
                    ValidateAudience = false, 
                    ValidateIssuerSigningKey = true, // Vérifier la signature du token
                    IssuerSigningKey = new SymmetricSecurityKey(key) // Clé de signature du token
                };
            });

        builder.Services.AddAuthorization(); // Ajoute les politiques d'autorisation
    }

    // Configuration de Swagger pour la documentation de l'API
    public static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }

    // Configuration d'Entity Framework Core avec MySQL
    public static void AddEFCoreConfiguration(this WebApplicationBuilder builder)
    {
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING")
                               ?? throw new InvalidOperationException(
                                   "Connection string 'DATABASE_CONNECTION_STRING' not found.");
        
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
    
    // Configuration de CORS pour autoriser les requêtes depuis l'application React
    public static void ConfigureCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowReactApp",
                policy =>
                {
                    policy.WithOrigins("http://localhost:3001") // Autorise l'accès depuis l'application React
                        .AllowAnyOrigin() 
                        .AllowAnyMethod() 
                        .AllowAnyHeader(); 
                });
        });
    }
}
