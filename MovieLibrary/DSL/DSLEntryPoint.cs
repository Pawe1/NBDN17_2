using System;
using TrainingPrep.collections;

namespace TrainingPrep.DSL
{
    public class DSLEntryPoint<TItem, TProperty> 
    {
        public readonly Func<TItem, TProperty> _propertySelector;
        public bool isNegation;
        private Criteria<TItem> _criteria;

        public DSLEntryPoint(Func<TItem, TProperty> propertySelector, Criteria<TItem> criteria) : this(propertySelector,false, criteria)
        {
        }

        public DSLEntryPoint(Func<TItem, TProperty> propertySelector) : this(propertySelector,false)
        {
        }

        private DSLEntryPoint(Func<TItem, TProperty> propertySelector, bool isNegation, Criteria<TItem> criteria = null) 
        {
            this.isNegation = isNegation;
            this._propertySelector = propertySelector;
            _criteria = criteria;
        }

        public DSLEntryPoint<TItem, TProperty> Not()
        {
            return new DSLEntryPoint<TItem, TProperty>(_propertySelector, !isNegation);
        }


        public Criteria<TItem> ApplyModifications(Criteria<TItem> resultCriteria)
        {
            if (_criteria != null)
            {
                resultCriteria = new Conjunction<TItem>(resultCriteria, _criteria);

            }
            if (isNegation)
                resultCriteria = new Negate<TItem>(resultCriteria);

            return resultCriteria;
        }
    }
}