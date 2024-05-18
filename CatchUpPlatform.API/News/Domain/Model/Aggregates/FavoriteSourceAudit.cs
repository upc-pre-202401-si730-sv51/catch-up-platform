using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace CatchUpPlatform.API.News.Domain.Model.Aggregates;

public partial class FavoriteSource : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")]
    public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")]
    public DateTimeOffset? UpdatedDate { get; set; }
}