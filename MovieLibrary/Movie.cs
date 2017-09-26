using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainingPrep.collections
{
    public class Movie : IEquatable<Movie>
    {
        public bool Equals(Movie other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return String.Equals(title, other.title);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((Movie) obj);
        }

        public override int GetHashCode()
        {
            return (title != null ? title.GetHashCode() : 0);
        }

        public static bool operator ==(Movie left, Movie right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Movie left, Movie right)
        {
            return !Equals(left, right);
        }

        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public static Criteria<Movie> IsPublishedBy(ProductionStudio productionStudio)
        {
            return new IsPublishedByCriteria(productionStudio);
        }

        public static Criteria<Movie> IsNotPublishedBy(ProductionStudio productionStudio)
        {
            return new Negate<Movie>(IsPublishedBy(productionStudio));
        }

        public static Predicate<Movie> IsPublishedAfter(int year)
        {
            return movie => movie.date_published.Year > year;
        }

        public static Predicate<Movie> IsPublishedBetween(int fromYear, int toYear)
        {
            return movie => movie.date_published.Year >= fromYear && movie.date_published.Year <= toYear;
        }

        public static Criteria<Movie> IsOfGenre(Genre genre)
        {
            return new IsOfGenreCritiria(genre);
        }

        public class IsPublishedByAnyCriteria : Criteria<Movie>
        {
            private readonly List<ProductionStudio> _studios;

            public IsPublishedByAnyCriteria(params ProductionStudio[] studios)
            {
                _studios = studios.ToList();
            }

            public bool IsSatisfiedBy(Movie movie)
            {
                return _studios.Contains(movie.production_studio);
            }
        }
    }

    public class IsOfGenreCritiria : Criteria<Movie>
    {
        private readonly Genre _genre;

        public IsOfGenreCritiria(Genre genre)
        {
            _genre = genre;
        }

        public bool IsSatisfiedBy(Movie movie)
        {
            return movie.genre == _genre;
        }
    }

    public class Negate<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _criteria;

        public Negate(Criteria<TItem> criteria)
        {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(TItem movie)
        {
            return !_criteria.IsSatisfiedBy(movie);
        }
    }


    public class IsPublishedByCriteria : Criteria<Movie>
    {
        private readonly ProductionStudio _productionStudio;

        public IsPublishedByCriteria(ProductionStudio productionStudio)
        {
            _productionStudio = productionStudio;
        }

        public bool IsSatisfiedBy(Movie movie)
        {
            return movie.production_studio.Equals(_productionStudio);
        }
    }
}