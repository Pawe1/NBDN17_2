using System;

namespace TrainingPrep.DSL
{
    public class DSLEntryPoint<TItem, TProperty> 
    {
        public readonly Func<TItem, TProperty> _propertySelector;
        public bool isNegation = false;

        public DSLEntryPoint(Func<TItem, TProperty> propertySelector)
        {
            _propertySelector = propertySelector;
        }

        private DSLEntryPoint(Func<TItem, TProperty> propertySelector, bool isNegation) : this(propertySelector)
        {
            this.isNegation = isNegation;
        }

        public DSLEntryPoint<TItem, TProperty> Not()
        {
            return new DSLEntryPoint<TItem, TProperty>(_propertySelector, !isNegation);
        }
    }
}