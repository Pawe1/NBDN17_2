using System;

namespace TrainingPrep.DSL
{
    public class DSLEntryPoint<TItem, TProperty> 
    {
        public readonly Func<TItem, TProperty> _propertySelector;

        public DSLEntryPoint(Func<TItem, TProperty> propertySelector)
        {
            _propertySelector = propertySelector;
        }
    }
}