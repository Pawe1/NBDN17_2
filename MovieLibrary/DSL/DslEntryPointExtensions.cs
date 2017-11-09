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

    public class PropertyCriteria<TItem, TPropoerty>:Criteria<TItem>
    {
        private readonly Func<TItem, TPropoerty> _propertySelector;
        private readonly EqualCriteria<TPropoerty> _innerCriteria;

        public PropertyCriteria(Func<TItem, TPropoerty> propertySelector, EqualCriteria<TPropoerty> innerCriteria)
        {
            _propertySelector = propertySelector;
            _innerCriteria = innerCriteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _innerCriteria.IsSatisfiedBy(_propertySelector(item));
        }
    }

    public class EqualCriteria<TItem> : Criteria<TItem>
    {
        private readonly TItem _value;

        public EqualCriteria(TItem value)
        {
            _value = value;
        }

        public bool IsSatisfiedBy(TItem currentValue)
        {
            return _value.Equals(currentValue);
        }
    }
}