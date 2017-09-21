using System;
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

    public static IEnumerable<TItem> AllThatSatisfy<TItem>(this IEnumerable<TItem> list, Predicate<TItem> condition)
    {
        foreach (var item in list)
        {
            if (condition(item))
            {
                yield return item;
            }
        }
    }
}