using System.Collections.Generic;

namespace TrainingPrep.collections
{
    public class Conjunction<TItem> : BinaryCriteria<TItem>
    {
        public Conjunction(Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria) : base(leftCriteria, rightCriteria)
        {
        }

        public override bool IsSatisfiedBy(TItem movie)
        {
            return _leftCriteria.IsSatisfiedBy(movie) && _rightCriteria.IsSatisfiedBy(movie);
        }
    }
}