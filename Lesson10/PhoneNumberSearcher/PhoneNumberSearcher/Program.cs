using PhoneNumberSearcher;

var someStuff = PhoneNumberSearch.Search("+7-909-123-2345dsadsadsad+7-890-222-1355");
foreach (var s in someStuff)
{
    Console.WriteLine(s);
}
