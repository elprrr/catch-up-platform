using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Domain.Repositories;
using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatchUpPlatform.API.News.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Entity Framework repository for favorite source persistence.
/// </summary>
/// <remarks>
///     This repository extends the generic BaseRepository with favorite-source-specific query methods.
///     It provides methods to find favorites by NewsApiKey and by composite key (NewsApiKey + SourceId).
/// </remarks>
/// <param name="context">The EF Core database context.</param>
public class FavoriteSourceRepository(AppDbContext context)
    : BaseRepository<FavoriteSource>(context), IFavoriteSourceRepository
{
    /// <inheritdoc />
    public async Task<IEnumerable<FavoriteSource>> FindByNewsApiKeyAsync(string newsApiKey)
    {
        return await Context.Set<FavoriteSource>().Where(f => f.NewsApiKey == newsApiKey).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<FavoriteSource?> FindByNewsApiKeyAndSourceIdAsync(string newsApiKey, string sourceId)
    {
        return await Context.Set<FavoriteSource>()
            .FirstOrDefaultAsync(f => f.NewsApiKey == newsApiKey && f.SourceId == sourceId);
    }
}