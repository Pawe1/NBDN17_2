using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace TrainingPrep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return new ReadOnlySet<Movie>(movies);
        }

        public void add(Movie movie)
        {
            if (!movies.Contains(movie))
                movies.Add(movie);
        }
        

      

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            return GetMoviesSortedBy((movie1, movie2) => -(movie1.title.CompareTo(movie2.title)));
        }

        private IEnumerable<Movie> GetMoviesSortedBy(Comparison<Movie> comparison)
        {
            List<Movie> result = new List<Movie>(movies);

            result.Sort(comparison);

            return result;
        }


        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {            
            return movies.ThatSatisfy(new Movie.IsPublishedByAnyCriteria(ProductionStudio.Pixar, ProductionStudio.Disney));
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return movies.ThatSatisfy(Movie.IsNotPublishedBy(ProductionStudio.Pixar));
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return movies.ThatSatisfy(Movie.IsPublishedAfter(year));
        }

        public IEnumerable<Movie> all_movies_published_between_years(int fromYear, int toYear)
        {
            return movies.ThatSatisfy(Movie.IsPublishedBetween(fromYear, toYear));
        }

        
        public IEnumerable<Movie> all_action_movies()
        {
            return movies.ThatSatisfy(Movie.IsOfGenre(Genre.action));
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            return GetMoviesSortedBy((movie1, movie2) => string.Compare(movie1.title, movie2.title, StringComparison.Ordinal));
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            return GetMoviesSortedBy((movie1, movie2) => -movie1.date_published.CompareTo(movie2.date_published));
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            return GetMoviesSortedBy((movie1, movie2) => movie1.date_published.CompareTo(movie2.date_published));

        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            //Studio Ratings (highest to lowest)
            //MGM
            //Pixar
            //Dreamworks
            //Universal
            //Disney
            List<Movie> result = new List<Movie>(movies);
            var productionRating = new Dictionary<ProductionStudio, int>()
            {
                {ProductionStudio.MGM, 10},
                {ProductionStudio.Pixar, 9},
                {ProductionStudio.Dreamworks, 8},
                {ProductionStudio.Universal, 7},
                {ProductionStudio.Disney, 6}
            };
            // result.Sort((movie1, movie2) => string.Compare(nameof(movie1.production_studio), nameof(movie2.production_studio), StringComparison.Ordinal));
            return GetMoviesSortedBy((movie1, movie2) =>
                        {
                            if (productionRating[movie1.production_studio] != productionRating[movie2.production_studio])
                            {
                                var comparedRating = -productionRating[movie1.production_studio] + productionRating[movie2.production_studio];
                                return comparedRating;
                            }
                            else
                                return movie1.date_published.Year - movie2.date_published.Year;
                        }
                    )
            ;

        }

        public IEnumerable<Movie> all_kid_movies_published_after(int year)
        {
            return movies.ThatSatisfy(Movie.IsOfGenre(Genre.kids).And(Movie.IsPublishedAfter(year)));
        }


        public IEnumerable<Movie> all_horror_or_action()
        {
            return  movies.ThatSatisfy(Movie.IsOfGenre(Genre.horror).Or(Movie.IsOfGenre(Genre.action)));
        }
    }
}