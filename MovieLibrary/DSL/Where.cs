using System;

namespace TrainingPrep.DSL
{
    public static class Where<TItem>
    {
        public static DSLEntryPoint<TItem,TProperty> hasAn<TProperty>(Func<TItem, TProperty> propertySelector) 
        {
            return new DSLEntryPoint<TItem,TProperty>(propertySelector);
        }
    }

    public class WhereNonStatic<TItem>
    {
        private Criteria<TItem> criteriaToPass;

        public WhereNonStatic(Criteria<TItem> criteriaToPass)
        {
            this.criteriaToPass = criteriaToPass;
        }

        public DSLEntryPoint<TItem, TProperty> hasAn<TProperty>(Func<TItem, TProperty> propertySelector)
        {
            //Func<TItem, TProperty> mergedPropertySelector = 
            return new DSLEntryPoint<TItem, TProperty>(propertySelector, criteriaToPass);
        }

    }
}

//namespace TrainingPrep.specs
//{
//    public class Where<TItem>
//    {
//        public static DSLEntryPoint<TItem,TProperty> hasAn<TProperty>(Func<TItem, TProperty> propertySelector) 
//        {
//            return new DSLEntryPoint<TItem,TProperty>(propertySelector);
//        }
//    }
//}