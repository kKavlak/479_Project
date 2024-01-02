using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using DataAccess.Contexts;


namespace Business.Services
{
    public interface IMovieGenreService
    {
        IQueryable<MovieGenreModel> Query();  
    }
    public class MovieGenreService : IMovieGenreService
    {
        private readonly Db _db;

        public MovieGenreService(Db db) {
            _db = db ?? throw new ArgumentNullException(nameof(db));

        }

        public IQueryable<MovieGenreModel> Query()
        {
            return _db.MovieGenres.OrderBy(a => a.GenreId).ThenBy(a => a.MovieId).Select(a => new MovieGenreModel()
            {
                MovieId = a.MovieId,
                GenreId = a.GenreId,
            });
        }
    }
}
