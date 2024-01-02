using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.Entities;
using Business.Models;

namespace Business.Services
{
    public interface IMovieService
    {
        IQueryable<MovieModel> Query();
    }
    public class MovieService : IMovieService
    {
        private readonly Db _db;
        public MovieService(Db db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IQueryable<MovieModel> Query()
        {
            return _db.Movies.OrderBy(a => a.Revenue).Select(a => new MovieModel() { 
            Revenue = a.Revenue,
            DirectorId = a.DirectorId,
            Year = a.Year,
            Name = a.Name
            });
        }
    }
}
