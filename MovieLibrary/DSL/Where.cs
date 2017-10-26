using System;

namespace TrainingPrep.DSL
{
    public class Where<TItem>
    {
        public static DSLEntryPoint<TItem,TProperty> hasAn<TProperty>(Func<TItem, TProperty> propertySelector) 
        {
            return new DSLEntryPoint<TItem,TProperty>(propertySelector);
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