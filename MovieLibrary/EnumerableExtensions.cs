using System.Collections.Generic;
using TrainingPrep.collections;

static internal class EnumerableExtensions
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IList<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}