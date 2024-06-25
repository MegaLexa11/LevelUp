using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Text.RegularExpressions;

namespace PhoneNumberSearcher
{
    [SimpleJob(RuntimeMoniker.Net80, iterationCount: 10, warmupCount: 3, launchCount: 3)]
    [MemoryDiagnoser]

    public class PhoneNumberSearchBenchmark
    {

        string strWithPhones = "+7-906-625-3771sometextsometext+7-922-625-3771te+7-906-611-3711xt+7-906-625-3771dskaldksa+7-111-611-3771sssska+7-906-625-1111";
        [Benchmark]
        public MatchCollection TestPhoneNumberSearch()
        {
            return PhoneNumberSearch.Search(strWithPhones);
        }

        [Benchmark]
        public List<string> TestPhoneNumberSearchOptimized()
        {
            return PhoneNumberSearch.SearchOptimized(strWithPhones);
        }

    }
}
