using MMS.BAL.DTOs;
using MMS.DLA.Repositories;
using MMS.DLA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.BAL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }
        public void Add(MovieDto movieDto)
        {
            //Converting MovieDto to Movie
            var movie = new Movie()
            {
                MovieId = movieDto.MovieId,
                Title = movieDto.Title,
                Genre = movieDto.Genre,
                ReleaseDate = movieDto.ReleaseDate ,
                Duration = movieDto.Duration,
                Rating = movieDto.Rating,
                Language = movieDto.Language
            };
            _repository.Add(movie);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<MovieDto> GetAllMovies()
        {
            var movies = _repository.GetAllMovies();
            return movies.Select(m => new MovieDto()
            {
                MovieId = m.MovieId,
                Title= m.Title,
                Genre = m.Genre,
                ReleaseDate=m.ReleaseDate,
                Duration = m.Duration,
                Rating = m.Rating,
                Language=m.Language
            }
                ).ToList();
        }

        public MovieDto GetMovieById(int MovieId)
        {
            var movie = _repository.GetMovieById(MovieId);
            return new MovieDto()
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Genre = movie.Genre,
                ReleaseDate = movie.ReleaseDate,
                Duration = movie.Duration,
                Rating = movie.Rating,
                Language = movie.Language
            };
        }

        public void Update(MovieDto movieDto)
        {
            //converting MovieDto to Movie
            var movie = new Movie()
            {
                MovieId = movieDto.MovieId,
                Title = movieDto.Title,
                Genre = movieDto.Genre,
                ReleaseDate = movieDto.ReleaseDate,
                Duration = movieDto.Duration,
                Rating = movieDto.Rating,
                Language = movieDto.Language
            };
           
            _repository.Update(movie);
        }
    }
}
