using MMS.BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.BAL.Services
{
    public interface IMovieService
    {
        List<MovieDto> GetAllMovies();

        MovieDto GetMovieById(int MovieId);

        void Add(MovieDto movie);

        void Update(MovieDto movie);

        void Delete(int id);
    }
}
