namespace TrainingPrep.collections
{
    public abstract class BinaryCriteria<TItem> : Criteria<TItem>
    {
        protected Criteria<TItem> _leftCriteria;
        protected Criteria<TItem> _rightCriteria;

        public BinaryCriteria(Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria)
        {
            _leftCriteria = leftCriteria;
            _rightCriteria = rightCriteria;
        }

        public abstract bool IsSatisfiedBy(TItem movie);
    }
}