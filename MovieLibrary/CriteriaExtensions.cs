using TrainingPrep.collections;

public static class CriteriaExtensions
{
    public static Alternative<TItem> Or<TItem>(this Criteria<TItem> leftCriteria, Criteria<TItem> RightCriteria)
    {
        return new Alternative<TItem>(leftCriteria,RightCriteria);
    }

    public static Conjunction<TItem> And<TItem>(this Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria)
    {
        return new Conjunction<TItem>(leftCriteria, rightCriteria);
    }
}