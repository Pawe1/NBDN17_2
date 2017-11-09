using System;
using TrainingPrep.collections;
using TrainingPrep.DSL;

public static class CriteriaExtensions
{
    public static Alternative<TItem> Or<TItem>(this Criteria<TItem> leftCriteria, Criteria<TItem> RightCriteria)
    {
        return new Alternative<TItem>(leftCriteria,RightCriteria);
    }

    public static WhereNonStatic<TItem> And<TItem>(this Criteria<TItem> criteria)
    {
        return new WhereNonStatic<TItem>(criteria);
    }

    public static Conjunction<TItem> And<TItem>(this Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria)
    {
        return new Conjunction<TItem>(leftCriteria, rightCriteria);
    }
}