using GymWatch.Infrastructure.DTOs;
using Microsoft.Extensions.Caching.Memory;

namespace GymWatch.Infrastructure.Extensions;

public static class MemoryCacheExtensions
{
    public static void SetJwt(this IMemoryCache memoryCache, Guid? tokenId, JwtDto jwt)
    {
        memoryCache.Set(GetJwtKey(tokenId: tokenId), jwt, TimeSpan.FromSeconds(5));
    }
    
    public static JwtDto GetJwt(this IMemoryCache cache, Guid? tokenId)
    {
        return cache.Get<JwtDto>(GetJwtKey(tokenId: tokenId));
    }

    private static string GetJwtKey(Guid? tokenId)
        => $"jtw-{tokenId}";
}

