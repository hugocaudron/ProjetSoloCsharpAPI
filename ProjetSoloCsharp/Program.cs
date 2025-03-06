using DotNetEnv;
using ProjetSoloCsharp.Shared.Extensions;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.InjectDependencies();

var app = builder.Build();


// Configurer le pipeline HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Activation de l'authentification et de l'autorisation
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();