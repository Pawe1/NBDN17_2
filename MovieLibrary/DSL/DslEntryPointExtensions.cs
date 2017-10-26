using System;
using System.Collections.Generic;

namespace TrainingPrep.DSL
{
    public static class DslEntryPointExtensions
    {
        public static Criteria<TItem> EqualTo<TItem, TProperty>(this DSLEntryPoint<TItem, TProperty> dslEntryPoint, TProperty studio)
        {
            return dslEntryPoint.isNegation
                ? new AnonymousCriteria<TItem>(m => !dslEntryPoint._propertySelector(m).Equals(studio))
                : new AnonymousCriteria<TItem>(m => dslEntryPoint._propertySelector(m).Equals(studio));


        }

        public static Criteria<TItem> GreaterThan<TItem, TProperty>(this DSLEntryPoint<TItem, TProperty> dslEntryPoint, TProperty i) where TProperty : IComparable<TProperty>
        {
            return new AnonymousCriteria<TItem>(m => dslEntryPoint._propertySelector(m).CompareTo(i) >0);
        }

        public static Criteria<TItem> EqualToAny<TItem, TProperty>(this DSLEntryPoint<TItem, TProperty> dslEntryPoint, params TProperty[] allowedValues)
        {
            var values = new List<TProperty>(allowedValues);
            return new AnonymousCriteria<TItem> ( i => values.Contains(dslEntryPoint._propertySelector(i)));
        }
    }
}