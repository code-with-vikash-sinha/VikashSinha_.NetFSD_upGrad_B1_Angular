using MMS.DLA.Entities;
using MMS.DLA.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.DLA.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext movieDbContext;

        public MovieRepository(MovieDbContext movieDbContext)
        {
            this.movieDbContext = movieDbContext;
        }
        public void Add(Movie movie)
        {
            movieDbContext.Movies.Add(movie);
            movieDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = movieDbContext.Movies.Find(id);
            if (movie != null) {
                movieDbContext.Movies.Remove(movie);
                movieDbContext.SaveChanges();
            }
        }

        public List<Movie> GetAllMovies()
        {
            var movies = movieDbContext.Movies.ToList();
            return movies;
        }

        public Movie GetMovieById(int MovieId)
        {
            var movie = movieDbContext.Movies.SingleOrDefault(m => m.MovieId == MovieId);      
            return movie ;
        }


        public void Update(Movie movie)
        {
            movieDbContext.Movies.Update(movie);
            movieDbContext.SaveChanges();
        }
    }
}
