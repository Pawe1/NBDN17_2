using System;
using System.Collections.Generic;
using TrainingPrep.collections;

namespace TrainingPrep.DSL
{
    public static class DslEntryPointExtensions
    {
        public static Criteria<TItem> EqualTo<TItem, TProperty>(this DSLEntryPoint<TItem, TProperty> dslEntryPoint, TProperty studio)
        {
            var resultCriteria = new AnonymousCriteria<TItem>(m => dslEntryPoint._propertySelector(m).Equals(studio));

            return dslEntryPoint.ApplyNegation(resultCriteria);
        }

        public static Criteria<TItem> GreaterThan<TItem, TProperty>(this DSLEntryPoint<TItem, TProperty> dslEntryPoint, TProperty i) where TProperty : IComparable<TProperty>
        {
            var resultCriteria = new AnonymousCriteria<TItem>(m => dslEntryPoint._propertySelector(m).CompareTo(i) >0);
            return dslEntryPoint.ApplyNegation(resultCriteria);
        }

        public static Criteria<TItem> EqualToAny<TItem, TProperty>(this DSLEntryPoint<TItem, TProperty> dslEntryPoint, params TProperty[] allowedValues)
        {
            var values = new List<TProperty>(allowedValues);
            var resultCriteria = new AnonymousCriteria<TItem> ( i => values.Contains(dslEntryPoint._propertySelector(i)));
            return dslEntryPoint.ApplyNegation(resultCriteria);
        }
    }
}