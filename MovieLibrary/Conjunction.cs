using System.Collections.Generic;

namespace TrainingPrep.collections
{
    public class Conjunction<TItem> : Criteria<TItem>
    {
        private readonly List<Criteria<TItem>> _criterias;


        public Conjunction(params Criteria<TItem>[] criterias)
        {
            _criterias = new List<Criteria<TItem>>(criterias);
        }

        public bool IsSatisfiedBy(TItem movie)
        {
            foreach (var criteria in _criterias)
            {
                if (!criteria.IsSatisfiedBy(movie)) return false;
            }
            return true;
        }
    }
}