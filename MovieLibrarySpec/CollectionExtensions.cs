using System.Collections.Generic;

public static class CollectionExtensions
{
    public static void add_all<T>(this ICollection<T> collection, params T[] itemsToAdd)
    {
        foreach (var item in itemsToAdd) collection.Add(item);
    }

    public static int CountAll<T>(this IEnumerable<T> collection)
    {
        int cnt = 0;
        var enumerator = collection.GetEnumerator();
        while (enumerator.MoveNext()) cnt++;
        return cnt;
    }

}