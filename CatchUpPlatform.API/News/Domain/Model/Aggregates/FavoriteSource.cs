using CatchUpPlatform.API.News.Domain.Model.Commands;

namespace CatchUpPlatform.API.News.Domain.Model.Aggregates;

//*
// FavoriteSource.cs
// <summary>
// Entity class for FavoriteSource
//*/

public class FavoriteSource
{
    public int Id { get; set; }
    public string NewsApiKey { get; set; }
    public string SourceId { get; set; }

    public FavoriteSource(CreateFavoriteSourceCommand command)
    {
        this.NewsApiKey = command.NewsApiKey;
        this.SourceId = command.SourceId;
    }
}