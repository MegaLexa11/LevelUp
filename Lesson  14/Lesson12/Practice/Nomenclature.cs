namespace Practice;

public sealed class Nomenclature
{
    public ProductItem[] Items { get; private set; } = [];

    public ProductCategory[] Categories { get; private set; } = [];

    public Dictionary<Guid, ProductPriceHistory> PriceHistory { get; private set; } = [];

    public Nomenclature()
    {
        Initialize();
    }

    private void Initialize()
    {
        var toys = new ProductCategory("Игрушки");
        var sports = new ProductCategory("Товары для спорта");
        var office = new ProductCategory("Офисные товары и канцелярия");

        Categories =
        [
            toys,
            sports,
            office
        ];
        
        var elephant = new ProductItem(Guid.NewGuid(), "Слоник", toys);
        var bubbles = new ProductItem(Guid.NewGuid(), "Мыльные пузыри", toys);
    
        var ball = new ProductItem(Guid.NewGuid(), "Футбольный мяч", sports);
        var tennisSet = new ProductItem(Guid.NewGuid(), "Набор для настольного тенниса", sports);
        var boxingGloves = new ProductItem(Guid.NewGuid(), "Перчатки для бокса", sports);

        var pen = new ProductItem(Guid.NewGuid(), "Ручка синяя", office);
        var paper = new ProductItem(Guid.NewGuid(), "Бумага А4 для принтера", office);
        var marker = new ProductItem(Guid.NewGuid(), "Маркер красный", office);
        var stickersSet = new ProductItem(Guid.NewGuid(), "Набор стикеров", office);

        Items = 
        [
            elephant,
            bubbles,
            ball,
            tennisSet,
            boxingGloves,
            pen,
            paper,
            marker,
            stickersSet
        ];

        PriceHistory[elephant.Id] = new ProductPriceHistory(elephant.Id);
        PriceHistory[elephant.Id].History.Add(new PriceHistoryRecord(DateTime.Parse("2024-03-01"), 560.0D));
        PriceHistory[elephant.Id].History.Add(new PriceHistoryRecord(DateTime.Parse("2024-04-01"), 630.0D));
        
        PriceHistory[bubbles.Id] = new ProductPriceHistory(bubbles.Id);
        PriceHistory[bubbles.Id].History.Add(new PriceHistoryRecord(DateTime.Parse("2024-03-01"), 250.0D));
        
        PriceHistory[ball.Id] = new ProductPriceHistory(ball.Id);
        PriceHistory[ball.Id].History.Add(new PriceHistoryRecord(DateTime.Parse("2024-03-01"), 1200.0D));
        PriceHistory[ball.Id].History.Add(new PriceHistoryRecord(DateTime.Parse("2024-04-01"), 1250.0D));
        PriceHistory[ball.Id].History.Add(new PriceHistoryRecord(DateTime.Parse("2024-05-01"), 1410.0D));
        
        PriceHistory[tennisSet.Id] = new ProductPriceHistory(tennisSet.Id);
        
        PriceHistory[boxingGloves.Id] = new ProductPriceHistory(boxingGloves.Id);
        PriceHistory[boxingGloves.Id].History.Add(new PriceHistoryRecord(DateTime.Parse("2024-03-01"), 3600.0D));
        
        PriceHistory[pen.Id] = new ProductPriceHistory(pen.Id);
        PriceHistory[pen.Id].History.Add(new PriceHistoryRecord(DateTime.Parse("2024-03-01"), 80.0D));
        
        PriceHistory[paper.Id] = new ProductPriceHistory(paper.Id);
        PriceHistory[paper.Id].History.Add(new PriceHistoryRecord(DateTime.Parse("2024-03-01"), 80.0D));
        
        PriceHistory[marker.Id] = new ProductPriceHistory(marker.Id);
        
        PriceHistory[stickersSet.Id] = new ProductPriceHistory(stickersSet.Id);
        PriceHistory[stickersSet.Id].History.Add(new PriceHistoryRecord(DateTime.Parse("2024-03-01"), 200.0D));
    }
}