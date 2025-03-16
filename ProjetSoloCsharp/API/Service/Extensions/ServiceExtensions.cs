using ProjetSoloCsharp.API.Service.DTOs;
using ProjetSoloCsharp.API.Service.Models;

namespace ProjetSoloCsharp.API.Service.Extensions;

public static class ServiceExtensions
{
    public static Models.Service MapToServiceModel(this CreateServiceDto createServiceDto)
    {
        return new Models.Service()
        {
            Service1 = createServiceDto.Service,
        };
    }

    public static Models.Service MapToServiceModel(this UpdateServiceDto updateServiceDto)
    {
        return new Models.Service()
        {
            Service1 = updateServiceDto.Service,
        };
    }
    
    public static ReturnServiceDto MapToReturnServiceDto(this Models.Service service)
    {
        return new ReturnServiceDto()
        {
            Service = service.Service1,
            IdService = service.Id,
        };
    }
}