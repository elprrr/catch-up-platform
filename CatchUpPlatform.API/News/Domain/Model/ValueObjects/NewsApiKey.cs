namespace CatchUpPlatform.API.News.Domain.Model.ValueObjects;

/// <summary>
///     Value object representing a validated News API key.
/// </summary>
public sealed record NewsApiKey
{
    private const int MaxLength = 255;

    /// <summary>
    ///     Initializes a new <see cref="NewsApiKey"/> with the given raw string value.
    /// </summary>
    /// <param name="value">The raw News API key string. Must be non-null, non-whitespace, and at most 255 characters.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is null, empty, whitespace, or exceeds the maximum length.</exception>
    public NewsApiKey(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("NewsApiKey cannot be null, empty, or whitespace.", nameof(value));

        if (value.Length > MaxLength)
            throw new ArgumentException($"NewsApiKey cannot be longer than {MaxLength} characters.", nameof(value));

        Value = value;
    }

    /// <summary>
    ///     Gets the underlying primitive value.
    /// </summary>
    public string Value { get; }

    /// <inheritdoc />
    public override string ToString() => Value;
}

