using System;
using System.Collections.Generic;
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

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio.Equals(ProductionStudio.Pixar))
                {
                    yield return movie;  
                }
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            List<Movie> allMovies = all_movies().ToList();

            allMovies.Sort(new MyComparer());
            var sortedMovies = allMovies;

            return new ReadOnlySet<Movie>(sortedMovies);
        }

        public class MyComparer : IComparer<Movie>
        {
            public int Compare(Movie x, Movie y)
            {
                return -(x.title.CompareTo(y.title));
            }
        }
    }
}