using System;
using TrainingPrep.collections;

namespace TrainingPrep.DSL
{
    public class DSLEntryPoint<TItem, TProperty> 
    {
        public readonly Func<TItem, TProperty> _propertySelector;
        public bool isNegation;
        private Criteria<TItem> _previousCriteria;

        public DSLEntryPoint(Func<TItem, TProperty> propertySelector, Criteria<TItem> previousCriteria) : this(propertySelector,false, previousCriteria)
        {
        }

        public DSLEntryPoint(Func<TItem, TProperty> propertySelector) : this(propertySelector,false)
        {
        }

        private DSLEntryPoint(Func<TItem, TProperty> propertySelector, bool isNegation, Criteria<TItem> previousCriteria = null) 
        {
            this.isNegation = isNegation;
            this._propertySelector = propertySelector;
            _previousCriteria = previousCriteria;
        }

        public DSLEntryPoint<TItem, TProperty> Not()
        {
            return new DSLEntryPoint<TItem, TProperty>(_propertySelector, !isNegation);
        }


        public Criteria<TItem> ApplyModifications(Criteria<TItem> resultCriteria)
        {
            if (isNegation)
                resultCriteria = new Negate<TItem>(resultCriteria);

            if (_previousCriteria != null)
            {
                resultCriteria = new Conjunction<TItem>(resultCriteria, _previousCriteria);

            }
            
            return resultCriteria;
        }
    }
}