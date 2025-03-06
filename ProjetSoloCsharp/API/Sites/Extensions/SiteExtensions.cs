using ProjetSoloCsharp.API.Sites.DTOs;
using ProjetSoloCsharp.API.Sites.Models;

namespace ProjetSoloCsharp.API.Sites.Extensions;

public static class SiteExtensions
{
    public static Site MapToSiteModel(this CreateSiteDto createSitesDto)
    {
        return new Site()
        {
            Ville = createSitesDto.Ville,
        };
    }

    public static Site MapToSiteModel(this UpdateSiteDto updateSiteDto)
    {
        return new Site()
        {
            Ville = updateSiteDto.Ville,
        };
    }
    
    public static ReturnSiteDto MapToReturnSiteDto(this Site site)
    {
        return new ReturnSiteDto()
        {
            Ville = site.Ville,
        };
    }
}