using ProjetSoloCsharp.API.Salaries.Dtos;

namespace ProjetSoloCsharp.API.Salaries.Extensions;

public static class SalariesExtensions
{
    
    public static Salarié MapToSalariesModel(this CreateSalariesDto createSalariesDto)
    {
        return new Salarié()
        {
            Email = createSalariesDto.Email,
            Nom = createSalariesDto.Nom,
            Prénom = createSalariesDto.Prénom,
            TelFixe = createSalariesDto.TelFixe,
            TelPortable = createSalariesDto.TelPortable,
            IdServices = createSalariesDto.IdServices,
            IdSite = createSalariesDto.IdSite,
        };
    }
    
    public static ReturnSalariesDto MapToReturnModel(this Salarié salarié)
    {
        return new ReturnSalariesDto()
        {
            IdSalary = salarié.Id,
            Email = salarié.Email,
            Nom = salarié.Nom,
            Prénom = salarié.Prénom,
            TelFixe = salarié.TelFixe,
            TelPortable = salarié.TelPortable,
            IdServices = salarié.IdServices,
            IdSite = salarié.IdSite,
        };
    }
    
    

    public static Salarié MapToSalariesModel(this UpdateSalariesDto updateSalariesDto)
    {
        return new Salarié()
        {
            Email = updateSalariesDto.Email,
            Nom = updateSalariesDto.Nom,
            Prénom = updateSalariesDto.Prénom,
            TelFixe = updateSalariesDto.TelFixe,
            TelPortable = updateSalariesDto.TelPortable,
            IdServices = updateSalariesDto.IdServices,
            IdSite = updateSalariesDto.IdSite,
        };
    }
    
    /*public static ReturnServiceDto MapToReturnServiceDto(this Salarié service)
    {
        return new ReturnServiceDto()
        {
            Service = service.Service1,
        };
    }*/
}