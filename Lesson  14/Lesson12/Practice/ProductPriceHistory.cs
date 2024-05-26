namespace Practice;

public sealed class ProductPriceHistory(Guid productId)
{
    public Guid ProductId { get; init; } = productId;
    public List<PriceHistoryRecord> History { get; } = [];
}

public sealed record PriceHistoryRecord(DateTime Date, double Price);