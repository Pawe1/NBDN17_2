using System;

namespace TrainingPrep.DSL
{
    public class CriteriaBuilder<TItem, TProperty> 
    {
        public readonly Func<TItem, TProperty> _propertySelector;

        public CriteriaBuilder(Func<TItem, TProperty> propertySelector)
        {
            _propertySelector = propertySelector;
        }
    }
}