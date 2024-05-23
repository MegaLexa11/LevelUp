namespace CustomIntersectProject
{
    internal static class CustomIntersect
    {
        public static IEnumerable<T> Intersect<T>(this IEnumerable<T> firstEnum, IEnumerable<T> secondEnum)
        {
            var dictionary = new Dictionary<T, int>();

            foreach (var item in firstEnum)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary[item] = 1;
                }
            }
            foreach (var item in secondEnum)
            {
                if (dictionary.ContainsKey(item) && dictionary[item] == 1)
                {
                    dictionary[item] += 1;
                    yield return item;
                }
            }
        }
    }

}
