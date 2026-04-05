using MMS.DLA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.DLA.Repositories
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();

        Movie GetMovieById(int MovieId);

        void Add(Movie movie);

        void Update(Movie movie);

        void Delete(int id);
    }
}
