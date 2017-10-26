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

        public DSLEntryPoint<TItem, TProperty> Not()
        {
            isNegation = !isNegation;
            return this;
        }
    }
}