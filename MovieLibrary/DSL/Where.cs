using System;

namespace TrainingPrep.DSL
{
    public class Where<TItem>
    {
        public static CriteriaBuilder<TItem,TProperty> hasAn<TProperty>(Func<TItem, TProperty> propertySelector) 
        {
            return new CriteriaBuilder<TItem,TProperty>(propertySelector);
        }
    }
}

//namespace TrainingPrep.specs
//{
//    public class Where<TItem>
//    {
//        public static CriteriaBuilder<TItem,TProperty> hasAn<TProperty>(Func<TItem, TProperty> propertySelector) 
//        {
//            return new CriteriaBuilder<TItem,TProperty>(propertySelector);
//        }
//    }
//}