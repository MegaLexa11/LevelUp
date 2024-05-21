namespace CustomIntersectProject
{
    internal static class CustomIntersect
    {
        public static IEnumerable<T> IntersectArr<T>(this IEnumerable<T> firstArr, IEnumerable<T> secondArr)
        {
            int maxLength = Math.Max(firstArr.Count(), secondArr.Count());
            var dictionary = new Dictionary<T, int>();

            foreach (var item in firstArr)
            {
                AddToDict(item, dictionary);
            }
            foreach (var item in secondArr)
            {
                AddToDict(item, dictionary);
            }

            var result = from pair in dictionary
                            where pair.Value > 1
                            select pair.Key;

            return result;
        }

        private static void AddToDict<T>(T el, Dictionary<T, int> dict)
        {
            if (dict.ContainsKey(el))
            {
                dict[el] += 1;
            }
            else
            {
                dict[el] = 1;
            }
        }
    }

}
