
using Homework_5;

var prod1 = new ProductItem("Product 1", "Good one", "piece");
var prod2 = new ProductItem("Product 2", "Good one", "piece");
var prod3 = new ProductItem("Product 3", "Good one", "piece");
var prod4 = new ProductItem("Product 4", "Good one", "piece");
var prod5 = new ProductItem("Product 5", "Good one", "piece");

var storage = new Storage("Storage 1", 1, "City N");
var storage2 = new Storage("Storage 2", 2, "City X");

var stock = new Stock(20);

var invoice = new Invoice(storage);
invoice.AddToInvoice(prod1, 2);
invoice.AddToInvoice(prod2, 3);
invoice.AddToInvoice(prod2, 5);

stock.StoreItems(invoice);

var invoice2 = new Invoice(storage);
invoice2.AddToInvoice(prod1, 7);
invoice2.AddToInvoice(prod3, 4);

stock.StoreItems(invoice2);

var invoice3 = new Invoice(storage2);
invoice3.AddToInvoice(prod4, 7);
invoice3.AddToInvoice(prod5, 4);
invoice3.AddToInvoice(prod5, 1);

stock.StoreItems(invoice3);


ProductInStorageMonitoring.PrintProducts();
