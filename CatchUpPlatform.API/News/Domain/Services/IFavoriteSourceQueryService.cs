using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Domain.Model.Queries;

namespace CatchUpPlatform.API.News.Domain.Services;

public interface IFavoriteSourceQueryService
{
    List<FavoriteSource> Handle(GetFavoriteSourcesByNewsApiKeyQuery query);
    FavoriteSource Handle(GetFavoriteSourceByNewsApiKeyAndSourceIdQuery query);
}