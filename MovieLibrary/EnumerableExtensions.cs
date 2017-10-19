using System;
using System.Collections.Generic;
using TrainingPrep.collections;

public static class EnumerableExtensions
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
        return AllThatSatisfy(list, new AnonymousCriteria<TItem>(condition));
    }
    public static IEnumerable<TItem> AllThatSatisfy<TItem>(this IEnumerable<TItem> list, Criteria<TItem> criteria)
    {
        foreach (var item in list)
        {
            if (criteria.IsSatisfiedBy(item))
            {
                yield return item;
            }
        }
    }
}