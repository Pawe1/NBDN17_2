using System;

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
            return new IsPublishedByCriteia(production_studio);
        }

        public static Predicate<Movie> IsNotPublishedBy(ProductionStudio productionStudio)
        {
            return movie => !movie.production_studio.Equals(productionStudio);
        }

        public static Predicate<Movie> IsPublishedAfter(int year)
        {
            return movie => movie.date_published.Year > year;
        }

        public static Predicate<Movie> IsPublishedBetween(int fromYear, int toYear)
        {
            return movie => movie.date_published.Year >= fromYear && movie.date_published.Year <= toYear;
        }

        public static Predicate<Movie> IsOfGenre(Genre genre)
        {
            return movie => movie.genre.Equals(genre);
        }
    }
}