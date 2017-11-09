using System;
using TrainingPrep.collections;

namespace TrainingPrep.DSL
{
    public class DSLEntryPoint<TItem, TProperty> 
    {
        public readonly Func<TItem, TProperty> _propertySelector;
        public bool isNegation;

        public DSLEntryPoint(Func<TItem, TProperty> propertySelector) : this(propertySelector,false)
        {
        }

        private DSLEntryPoint(Func<TItem, TProperty> propertySelector, bool isNegation) 
        {
            this.isNegation = isNegation;
            this._propertySelector = propertySelector;
        }

        public DSLEntryPoint<TItem, TProperty> Not()
        {
            return new DSLEntryPoint<TItem, TProperty>(_propertySelector, !isNegation);
        }

        public Criteria<TItem> ApplyNegation(Criteria<TItem> resultCriteria)
        {
            if (isNegation)
                resultCriteria = new Negate<TItem>(resultCriteria);
            return resultCriteria;
        }
    }
}