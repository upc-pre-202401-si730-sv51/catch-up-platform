using CatchUpPlatform.API.News.Domain.Model.Commands;
using CatchUpPlatform.API.News.Interfaces.REST.Resources;

namespace CatchUpPlatform.API.News.Interfaces.REST.Transform;

public static class CreateFavoriteSourceCommandFromResourceAssembler
{
    public static CreateFavoriteSourceCommand ToCommandFromResource(CreateFavoriteSourceResource resource) => 
        new(resource.NewsApiKey, resource.SourceId);
}