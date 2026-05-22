using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace CatchUpPlatform.API.News.Domain.Model.Aggregates;

/// <summary>
///     Audit extension for FavoriteSource aggregate.
/// </summary>
/// <remarks>
///     This partial class extends FavoriteSource with audit trail properties.
///     CreatedDate and UpdatedDate are automatically managed by the persistence layer
///     via the IEntityWithCreatedUpdatedDate interceptor.
///     Implements the IEntityWithCreatedUpdatedDate interface to provide these properties.
/// </remarks>
public partial class FavoriteSource : IEntityWithCreatedUpdatedDate
{
    /// <summary>
    ///     Gets the timestamp when this favorite source was created.
    /// </summary>
    /// <remarks>
    ///     Automatically set by the persistence layer. Column name in the database: CreatedAt.
    /// </remarks>
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }

    /// <summary>
    ///     Gets the timestamp when this favorite source was last updated.
    /// </summary>
    /// <remarks>
    ///     Automatically updated by the persistence layer. Column name in the database: UpdatedAt.
    /// </remarks>
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}