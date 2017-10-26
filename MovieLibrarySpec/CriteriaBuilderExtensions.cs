using System;
using TrainingPrep.specs;

public static class CriteriaBuilderExtensions
{
    public static Criteria<TItem> EqualTo<TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty studio)
    {
        return new AnonymousCriteria<TItem>(m => criteriaBuilder._propertySelector(m).Equals(studio));
    }

    public static Criteria<TItem> GreaterThan<TComparableProperty, TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, TComparableProperty i) where TComparableProperty : IComparable<TProperty>   
    {
        return new AnonymousCriteria<TItem>(m => i.CompareTo(criteriaBuilder._propertySelector(m))<0);
    }
}