using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.Utility.Internal;

public static class AssertionExtensions
{
    public static void ShouldContainOnlyInOrder<T>(this IEnumerable<T> items, params T[] ordered_items)
    {
        AssertionExtensions.ShouldContainOnlyInOrder<T>(items, (IEnumerable<T>)ordered_items);
    }

    public static void ShouldContainOnlyInOrder<T>(this IEnumerable<T> items, IEnumerable<T> ordered_items)
    {
        var source = new List<T>(items);
        if (!Enumerable.Any<T>(Enumerable.Where<T>(ordered_items, (Func<T, int, bool>)((ordered_element, index) => !source[index].Equals((object)ordered_element)))))
            return;
        throw new SpecificationException(string.Format("The set of items should only contain the items in the order {0}\r\nbut it actually contains the items:{1}", ordered_items.EachToUsefulString(), items.EachToUsefulString()));
    }
}
