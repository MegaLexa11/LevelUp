
using Homework_5;

var stock = new Stock();

var prod1 = new ProductItem("Product 1", "Good one", "piece", 10, "RUB");
var prod2 = new ProductItem("Product 2", "Good one", "piece", 20, "RUB");
var prod3 = new ProductItem("Product 3", "Good one", "piece", 30, "RUB");
var prod4 = new ProductItem("Product 4", "Good one", "piece", 40, "RUB");
var prod5 = new ProductItem("Product 5", "Good one", "piece", 50, "RUB");

var storage = new Storage("Storage 1", 1, "City N", stock);
var storage2 = new Storage("Storage 2", 2, "City X", stock);

var invoice = new Invoice(storage);
invoice.AddItem(prod1, 2);
invoice.AddItem(prod2, 3);
invoice.AddItem(prod2, 5);

stock.StoreItems(invoice);

var invoice2 = new Invoice(storage);
invoice2.AddItem(prod1, 7);
invoice2.AddItem(prod3, 4);

stock.StoreItems(invoice2);

var invoice3 = new Invoice(storage2);
invoice3.AddItem(prod4, 7);
invoice3.AddItem(prod5, 4);
invoice3.AddItem(prod5, 1);

stock.StoreItems(invoice3);

storage.PrintProducts();
Console.WriteLine();
storage2.PrintProducts();

prod1.Price.UpdatePrice(12);
Console.WriteLine(prod1.Price);
