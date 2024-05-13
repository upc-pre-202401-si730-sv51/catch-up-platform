using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.News.Domain.Model.Commands;

namespace CatchUpPlatform.API.News.Domain.Services;

public interface IFavoriteSourceCommandService
{
    FavoriteSource Handle(CreateFavoriteSourceCommand command);
}