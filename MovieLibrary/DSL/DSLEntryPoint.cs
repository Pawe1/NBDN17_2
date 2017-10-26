using System;

namespace TrainingPrep.DSL
{
    public class DSLEntryPoint<TItem, TProperty> 
    {
        public readonly Func<TItem, TProperty> _propertySelector;
        public bool isNegation = false;

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
    }
}