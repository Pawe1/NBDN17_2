using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private IEnumerable<Movie> GetMoviesWithCondition(Predicate<Movie> predicate)
        {
            foreach (var movie in movies)
            {
                if (predicate(movie))
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return GetMoviesWithCondition(movie => movie.production_studio.Equals(ProductionStudio.Pixar));
            //foreach (var movie in movies)
            //{
            //    if (movie.production_studio.Equals(ProductionStudio.Pixar))
            //    {
            //        yield return movie;
            //    }
            //}
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            List<Movie> result = new List<Movie>(movies);

            result.Sort((movie1, movie2) => -(movie1.title.CompareTo(movie2.title)));

            return result;
        }


        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio.Equals(ProductionStudio.Pixar) ||
                    movie.production_studio.Equals(ProductionStudio.Disney))
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (var movie in movies)
            {
                if (!movie.production_studio.Equals(ProductionStudio.Pixar))
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published.Year > year)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int fromYear, int toYear)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published.Year >= fromYear && movie.date_published.Year <= toYear)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            foreach (var movie in movies)
            {
                if (movie.genre.Equals(Genre.kids))
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            foreach (var movie in movies)
            {
                if (movie.genre.Equals(Genre.action))
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            List<Movie> result = new List<Movie>(movies);

            result.Sort((movie1, movie2) => string.Compare(movie1.title, movie2.title, StringComparison.Ordinal));

            return result;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            List<Movie> result = new List<Movie>(movies);

            result.Sort((movie1, movie2) => -movie1.date_published.CompareTo(movie2.date_published));

            return result;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            List<Movie> result = new List<Movie>(movies);

            result.Sort((movie1, movie2) => movie1.date_published.CompareTo(movie2.date_published));

            return result;
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
            result.Sort((movie1, movie2) => movie1.date_published.Year.CompareTo(movie2.date_published.Year));
            result.Sort((movie1, movie2) => -productionRating[movie1.production_studio]
                .CompareTo(productionRating[movie2.production_studio]));
            
            foreach (var movie in result)
            {
                Debug.WriteLine(nameof(movie.production_studio) + " " + movie.title + " " + movie.date_published.Year);
                
            }
            return result;
        }
    }
}