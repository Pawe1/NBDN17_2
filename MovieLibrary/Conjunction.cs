using System.Collections.Generic;

namespace TrainingPrep.collections
{
    public class Conjunction<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _leftCriteria;
        private readonly Criteria<TItem> _rightCriteria;

        public Conjunction(Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria)
        {
            _leftCriteria = leftCriteria;
            _rightCriteria = rightCriteria;
        }

        public bool IsSatisfiedBy(TItem movie)
        {
            return _leftCriteria.IsSatisfiedBy(movie) && _rightCriteria.IsSatisfiedBy(movie);
        }
    }
}