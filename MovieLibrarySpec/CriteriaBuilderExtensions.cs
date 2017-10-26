using System;
using TrainingPrep.specs;

public static class CriteriaBuilderExtensions
{
    public static Criteria<TItem> EqualTo<TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty studio)
    {
        return new AnonymousCriteria<TItem>(m => criteriaBuilder._propertySelector(m).Equals(studio));
    }

    public static Criteria<TItem> GreaterThan<TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty i) where TProperty : IComparable<TProperty>   
    {
        return new AnonymousCriteria<TItem>(m => criteriaBuilder._propertySelector(m).CompareTo(i) >0);
    }
}