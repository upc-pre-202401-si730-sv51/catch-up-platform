namespace CatchUpPlatform.API.News.Domain.Model.Commands;

public record CreateFavoriteSourceCommand(string NewsApiKey, string SourceId);