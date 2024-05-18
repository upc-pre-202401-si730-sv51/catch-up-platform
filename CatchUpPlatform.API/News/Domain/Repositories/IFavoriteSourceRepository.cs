using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.Shared.Domain.Repositories;

namespace CatchUpPlatform.API.News.Domain.Repositories;

public interface IFavoriteSourceRepository : IBaseRepository<FavoriteSource>
{
    Task<IEnumerable<FavoriteSource>> FindByNewsApiKeyAsync(string newsApiKey);
    Task<FavoriteSource?> FindByNewsApiKeyAndSourceIdAsync(string newsApiKey, string sourceId);
}