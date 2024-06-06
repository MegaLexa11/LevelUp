namespace Practice;

public interface IProductsStorage
{
    Task Save(IEnumerable<ProductItem> productItems, bool isOverwrite);
    Task Save(ProductItem productItems);

    Task<IEnumerable<ProductItem>> Fetch();
    Task<IEnumerable<ProductItem>> FetchByName(string productName);
    Task<IEnumerable<ProductItem>> FetchByCategory(string productCategory);
}