using System.Collections.Generic;

namespace TrainingPrep.collections
{
    public class Alternative<TItem> : Criteria<TItem>
    {
        private readonly List<Criteria<TItem>> _criterias;

        public Alternative(params Criteria<TItem>[] criterias)
        {
            _criterias = new List<Criteria<TItem>>(criterias);
        }

        public bool IsSatisfiedBy(TItem movie)
        {
            foreach (var criteria in _criterias)
            {
                if (criteria.IsSatisfiedBy(movie)) return true;
            }
            return false;
        }
    }
}