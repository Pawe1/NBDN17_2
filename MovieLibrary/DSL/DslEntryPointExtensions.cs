using System;
using System.Collections.Generic;
using TrainingPrep.collections;

namespace TrainingPrep.DSL
{
    public static class DslEntryPointExtensions
    {
        public static Criteria<TItem> EqualTo<TItem, TProperty>(this DSLEntryPoint<TItem, TProperty> dslEntryPoint, TProperty value)
        {
            var resultCriteria = new PropertyCriteria<TItem,TProperty>(dslEntryPoint._propertySelector, new EqualCriteria<TProperty>(value));

            return dslEntryPoint.ApplyModifications(resultCriteria);
        }

        public static Criteria<TItem> GreaterThan<TItem, TProperty>(this DSLEntryPoint<TItem, TProperty> dslEntryPoint, TProperty i) where TProperty : IComparable<TProperty>
        {
            var resultCriteria = new AnonymousCriteria<TItem>(m => dslEntryPoint._propertySelector(m).CompareTo(i) >0);
            return dslEntryPoint.ApplyModifications(resultCriteria);
        }

        public static Criteria<TItem> EqualToAny<TItem, TProperty>(this DSLEntryPoint<TItem, TProperty> dslEntryPoint, params TProperty[] allowedValues)
        {
            var values = new List<TProperty>(allowedValues);
            var resultCriteria = new AnonymousCriteria<TItem> ( i => values.Contains(dslEntryPoint._propertySelector(i)));
            return dslEntryPoint.ApplyModifications(resultCriteria);
        }
    }
}