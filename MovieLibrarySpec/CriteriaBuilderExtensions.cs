using System;
using System.Collections.Generic;
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

    public static Criteria<TItem> EqualToAny<TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, params TProperty[] allowedValues)
    {
        var values = new List<TProperty>(allowedValues);
        return new AnonymousCriteria<TItem> ( i => values.Contains(criteriaBuilder._propertySelector(i)));
    }
}