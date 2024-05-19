int[] numbers = [10, 50, 100, 200];
var border = 50;

var lessThan100 = numbers.Where(item => item <= border);
border = 100;

// lessThan100 = lessThan100.Where(item => item > 10);

var result = lessThan100.ToArray(); // материализация запроса - ToArray, ToList...
foreach (var item in result)
{
    Console.WriteLine(item); // ВОПРОС - что выведется в консоль?
}